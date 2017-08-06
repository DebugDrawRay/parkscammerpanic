using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;

    [Header("Movement")]
    public float moveAccel;
    public float maxSpeed;
    private float currentSpeed;
    private Vector3 currentDirection;

    private Rigidbody rigid;
    private TransactionManager transaction
    {
        get
        {
            return TransactionManager.Instance;
        }
    }

    private PlayerActions actions;

    [Header("Interaction")]
    public float baseInteractionRadius;
    public float itemInteractionRadius;
    public float caughtInteractionRadius;
    public float yellRadiusIncrease;
    public float ambientRadiusDecrease;
    public LayerMask customerMask;
    public LayerMask policeMask;
    public LayerMask itemMask;
    public Transform interactionVisual;

    public float currentInteractionRadius
    {
        get;
        private set;
    }

    [Header("Items")]
    public Transform itemContainer;
    private GameObject currentItem;

    [Header("Transaction")]
    public float ambientMoneyLoss = 1;
    public float timeToMoneyLoss = 1;
    private float currentTimeToLoss;

    [Header("Yell")]
    public GameObject yellVisual;
    public float yellTime;
    public Ease yellEase;
    public float yellLocationRadius = 1;

    private GameObject currentCustomer;
    private bool inTransaction;

    public enum State
    {
        None,
        Idle,
        Active
    }
    private State _currentState;
    private State previousState = State.None;
    public State currentState
    {
        get { return _currentState; }
        set
        {
            previousState = _currentState;
            _currentState = value;
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        Instance = this;

        currentState = State.Idle;
        actions = PlayerActions.BindAll();

        currentInteractionRadius = baseInteractionRadius;
        currentTimeToLoss = timeToMoneyLoss;
    }
    private void OnEnable()
    {
        GameManager.GameStateChanged += OnGameStateChanged;
    }
    private void OnDisable()
    {
        GameManager.GameStateChanged -= OnGameStateChanged;
    }
    private void Update()
    {
        RunStates();
    }
    private void FixedUpdate()
    {
        RunFixedStates();
    }

    private void RunStates()
    {
        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Active:
                TransactionListener();
                AggravatePolice();
                UpdateInteractionRadius();
                UpdateHeldItem();
                CheckForThePolice();
                UpdateMoney();
                break;
        }
    }
    private void RunFixedStates()
    {
        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Active:
                MovementListener();
                break;
        }
    }
    private void UpdateMoney()
    {
        if (inTransaction && GameManager.Instance.Score > 0)
        {
            if (currentTimeToLoss > 0)
            {
                currentTimeToLoss -= Time.deltaTime;
            }
            else
            {
                GameManager.Instance.AddToScore(-ambientMoneyLoss);
                currentTimeToLoss = timeToMoneyLoss;
            }
        }
    }
    private void MovementListener()
    {
        Vector3 move = actions.Move.Value;
        move.z = move.y;
        move.y = 0;
        if (move == Vector3.zero)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= moveAccel;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, Mathf.Infinity);
            }
        }
        else
        {
            currentDirection = move;
            currentSpeed += moveAccel;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }
        Vector3 movement = currentDirection * currentSpeed;
        rigid.MovePosition(transform.position + (movement * Time.deltaTime));
    }

    private void TransactionListener()
    {
        if (currentItem != null)
        {
            if (!inTransaction)
            {
                GameObject newCustomer = GetClosestCustomer();
                if (newCustomer != null && !newCustomer.GetComponent<CustomerController>().hasItem)
                {
                    currentCustomer = newCustomer;
                    currentCustomer.GetComponent<CustomerController>().SetState(CustomerController.State.Attentive);

                    transaction.StartTransaction(currentCustomer);
                    inTransaction = true;
                    currentCustomer.GetComponent<CustomerController>().dollarSign.gameObject.SetActive(true);
                }
            }
            else
            {
                if (currentCustomer != null && Vector3.Distance(transform.position, currentCustomer.transform.position) >= baseInteractionRadius)
                {
                    float transVal = transaction.CompleteCurrentTransaction();
                    if (transVal > 0)
                    {
                        currentCustomer.GetComponent<CustomerController>().GiveItem(currentItem);
                        currentItem = null;
                    }
                    RecieveMoney(currentCustomer.GetComponent<CustomerController>(), transVal);

                    currentCustomer.GetComponent<CustomerController>().SetState(CustomerController.State.Active);
                    currentCustomer.GetComponent<CustomerController>().dollarSign.gameObject.SetActive(false);
                    inTransaction = false;
                    currentCustomer = null;
                }
            }
            if (inTransaction)
            {
                currentCustomer.GetComponent<CustomerController>().UpdateDollarSign(transaction.GetTransactionValue());
                if (actions.Yell0.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(0));
                }
                if (actions.Yell1.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(1));
                }
                if (actions.Yell2.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(2));
                }
                if (actions.Yell3.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(3));
                }
            }
        }
    }
    private void UpdateInteractionRadius()
    {
        interactionVisual.transform.localScale = Vector3.one * currentInteractionRadius;
        if (currentInteractionRadius > baseInteractionRadius && !inTransaction)
        {
            currentInteractionRadius -= ambientRadiusDecrease;
        }
    }
    private void UpdateHeldItem()
    {
        if (currentItem == null)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, itemInteractionRadius, itemMask);
            GameObject newItem = null;
            float currentDistance = itemInteractionRadius;
            foreach (Collider hit in hits)
            {
                float dist = Vector3.Distance(transform.position, hit.transform.position);
                if (dist <= currentDistance)
                {
                    newItem = hit.gameObject;
                    currentDistance = dist;
                }
            }
            if (newItem != null)
            {
                currentItem = newItem;
                currentItem.transform.position = itemContainer.position;
                currentItem.transform.SetParent(itemContainer);
                SpawnManager.Instance.RemovedItem();
            }
        }
    }
    private GameObject GetClosestCustomer()
    {
        GameObject customer = null;

        Collider[] hits = Physics.OverlapSphere(transform.position, baseInteractionRadius, customerMask);
        float currentDistance = baseInteractionRadius;
        foreach (Collider hit in hits)
        {
            float dist = Vector3.Distance(transform.position, hit.transform.position);
            if (dist <= currentDistance)
            {
                customer = hit.gameObject;
                currentDistance = dist;
            }
        }
        return customer;
    }
    //WOO WOO
    private void CheckForThePolice()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, caughtInteractionRadius, policeMask);
        if (hits.Length > 0)
        {
            if (GameManager.Instance.Score >= hits[0].GetComponent<PoliceController>().moneyToTake)
            {
                GameManager.Instance.AddToScore(-hits[0].GetComponent<PoliceController>().moneyToTake);
                LoseMoney(hits[0].gameObject, -hits[0].GetComponent<PoliceController>().moneyToTake);
                PoliceController.ResetAll();
            }
            else
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    private void AggravatePolice()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, currentInteractionRadius, policeMask);
        foreach (Collider hit in hits)
        {
            hit.GetComponent<PoliceController>().Aggravate();
        }
    }

    private void OnGameStateChanged(GameState gameState)
    {
        Debug.Log("Character : State Change");
        switch (gameState)
        {
            case GameState.Paused:
                currentState = State.Idle;
                break;
            case GameState.Playing:
                currentState = State.Active;
                break;
            default:
                currentState = State.Idle;
                break;
        }
    }

    private void Yell(GameObject customer, int word)
    {
        Debug.Log(word);
        currentInteractionRadius += yellRadiusIncrease;

        Vector3 rand = Random.insideUnitSphere * yellLocationRadius;
        Vector3 from = transform.position + rand;
        from.y = Mathf.Clamp(from.y, transform.position.y, Mathf.Infinity);
        TextMeshPro yell = Instantiate(yellVisual, from, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        yell.text = WordDatabase.GetWordText(word);
        if (WordDatabase.GetWordValue(word) < 0)
        {
            yell.color = Color.red;
        }
        else
        {
            yell.color = Color.green;
        }
        Vector3 to = customer.transform.position + rand;
        to.y = Mathf.Clamp(to.y, customer.transform.position.y, Mathf.Infinity);
        yell.transform.DOMove(to, yellTime).OnComplete(() => Destroy(yell)).SetEase(yellEase);
    }

    private void RecieveMoney(CustomerController customer, float value)
    {
        Vector3 rand = Random.insideUnitSphere * yellLocationRadius;
        Vector3 from = customer.transform.position + rand;
        from.y = Mathf.Clamp(from.y, customer.transform.position.y, Mathf.Infinity);
        TextMeshPro yell = Instantiate(yellVisual, from, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        yell.text = "$" + (value * GameSettings.ValueToMoney).ToString();
        if (value > 0)
        {
            yell.color = Color.green;
        }
        else
        {
            yell.color = Color.red;
        }
        Vector3 to = transform.position + rand;
        to.y = Mathf.Clamp(to.y, transform.position.y, Mathf.Infinity);
        yell.transform.DOMove(to, yellTime).OnComplete(() => Destroy(yell)).SetEase(yellEase);
    }

    private void LoseMoney(GameObject customer, float amount)
    {
        currentInteractionRadius += yellRadiusIncrease;

        Vector3 rand = Random.insideUnitSphere * yellLocationRadius;
        Vector3 from = transform.position + rand;
        from.y = Mathf.Clamp(from.y, transform.position.y, Mathf.Infinity);
        TextMeshPro yell = Instantiate(yellVisual, from, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        yell.text = "$" + (amount*GameSettings.ValueToMoney).ToString();

        yell.color = Color.red;

        Vector3 to = customer.transform.position + rand;
        to.y = Mathf.Clamp(to.y, customer.transform.position.y, Mathf.Infinity);
        yell.transform.DOMove(to, yellTime).OnComplete(() => Destroy(yell)).SetEase(yellEase);
    }

}
