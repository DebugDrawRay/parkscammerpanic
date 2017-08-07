using System.Collections;
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
    public float escapeInteractionRadius;

    public float yellRadiusIncrease;
    public float ambientRadiusDecrease;

    public LayerMask customerMask;
    public LayerMask policeMask;
    public LayerMask itemMask;
    public LayerMask escapeMask;
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
    public int ambientMoneyLoss = 1;
    public float timeToMoneyLoss = 1;
    private float currentTimeToLoss;
    public int maxFailures = 3;
    private int currentFailures;

    [Header("Yell")]
    public GameObject yellVisual;
    public float yellTime;
    public Ease yellEase;
    public float yellLocationRadius = 1;

    [Header("Cage")]
    public GameObject cage;

    [Header("Sounds")]
    public AudioClip alert;
    public AudioClip damage;
    public AudioClip pickup;
    public AudioClip loss;
    public AudioClip profit;

    private GameObject currentCustomer;
    private bool inTransaction;

    //Escaping stuff
    public float leaveAnimTime;
    public Ease leaveEase;
    private float _escapeCountdown = 0;
    private float _escapeCountdownMax = 3;
    private bool _escaping = false;

    private bool _innocent = true;
    public bool Innocent
    {
        get
        {
            return _innocent; 
        }
    }

    public enum State
    {
        None,
        Idle,
        Active
    }
    private State _currentState;
    private State previousState = State.None;

    public Transform visual;
    private Sequence walkAnim;

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
    private void Start()
    {
        walkAnim = DOTween.Sequence();
        walkAnim.Append(visual.DOLocalMove(visual.transform.localPosition + visual.transform.up / 4, .1f));
        walkAnim.Append(visual.DOLocalMove(visual.transform.localPosition - visual.transform.up / 4, .1f));
        walkAnim.SetLoops(-1);
        walkAnim.Pause();
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
                if (actions.Submit.WasPressed)
                {
                    UIManager.Instance.HideStartScreen();
                }
                break;
            case State.Active:
                TransactionListener();
                AggravatePolice();
                UpdateInteractionRadius();
                UpdateHeldItem();
                CheckForThePolice();
                CheckForEscape();
                UpdateMoney();
                CheckCustomer();
                break;
        }
    }
    private void RunFixedStates()
    {
        switch (currentState)
        {
            case State.Idle:
                walkAnim.Pause();
                break;
            case State.Active:
                MovementListener();
                break;
        }
    }
    private void CheckCustomer()
    {
        if (inTransaction && currentCustomer != null && currentFailures >= maxFailures)
        {
            transaction.CompleteCurrentTransaction();
            currentCustomer.GetComponent<CustomerController>().GiveItem(new GameObject(), true);
            currentCustomer.GetComponent<CustomerController>().dollarSign.gameObject.SetActive(false);
            inTransaction = false;
            currentCustomer = null;
            currentFailures = 0;
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
            if (walkAnim.IsPlaying())
            {
                walkAnim.Pause();
            }
            if (currentSpeed > 0)
            {
                currentSpeed -= moveAccel;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, Mathf.Infinity);
            }
        }
        else
        {
            if (!walkAnim.IsPlaying())
            {
                walkAnim.Play();
            }

            currentDirection = move;
            currentSpeed += moveAccel;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
            visual.transform.forward = currentDirection.normalized;
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
                    if (_innocent)
                    {
                        _innocent = false;
                    }

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
                    currentFailures = 0;
                }
            }
            if (inTransaction)
            {
                currentCustomer.GetComponent<CustomerController>().UpdateDollarSign(transaction.GetTransactionValue());
                if (actions.Yell0.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(0));
                    if (WordDatabase.GetWordValue(transaction.ChooseOption(0)) < 0 && transaction.GetTransactionValue() < 0)
                    {
                        currentFailures++;
                    }
                    else
                    {
                        currentFailures--;
                        currentFailures = Mathf.RoundToInt(Mathf.Clamp(currentFailures, 0, Mathf.Infinity));
                    }
                }
                if (actions.Yell1.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(1));
                    if (WordDatabase.GetWordValue(transaction.ChooseOption(0)) < 0 && transaction.GetTransactionValue() < 0)
                    {
                        currentFailures++;
                    }
                    else
                    {
                        currentFailures--;
                        currentFailures = Mathf.RoundToInt(Mathf.Clamp(currentFailures, 0, Mathf.Infinity));
                    }
                }
                if (actions.Yell2.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(2));
                    if (WordDatabase.GetWordValue(transaction.ChooseOption(0)) < 0 && transaction.GetTransactionValue() < 0)
                    {
                        currentFailures++;
                    }
                    else
                    {
                        currentFailures--;
                        currentFailures = Mathf.RoundToInt(Mathf.Clamp(currentFailures, 0, Mathf.Infinity));
                    }
                }
                if (actions.Yell3.WasPressed)
                {
                    Yell(currentCustomer, transaction.ChooseOption(3));
                    if (WordDatabase.GetWordValue(transaction.ChooseOption(0)) < 0 && transaction.GetTransactionValue() < 0)
                    {
                        currentFailures++;
                    }
                    else
                    {
                        currentFailures--;
                        currentFailures = Mathf.RoundToInt(Mathf.Clamp(currentFailures, 0, Mathf.Infinity));
                    }
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
                AudioController.Instance.Play(pickup);
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
    private bool acosted = false;
    private void CheckForThePolice()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, caughtInteractionRadius, policeMask);
        if (hits.Length > 0 && !acosted && !_innocent)
        {
            if (GameManager.Instance.Score >= hits[0].GetComponent<PoliceController>().moneyToTake)
            {
                StartCoroutine(LoseMoney_Coroutine(hits[0].GetComponent<PoliceController>()));
            }
            else
            {
                StartCoroutine(EndGame_Lose_Coroutine());
            }
            acosted = true;
        }
    }

    private void CheckForEscape()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, escapeInteractionRadius, escapeMask);
        if (hits.Length > 0)
        {
            Debug.Log("ESCAPE DETECED");
            if (_escaping)
            {
                if (_escapeCountdown <= 0)
                {
                    Debug.Log("Youve Escaped!");
                    StartCoroutine(EndGame_Win_Coroutine());
                }
                else
                {
                    UIManager.Instance.UpdateEscapeText("Escaping in " + Mathf.Ceil(_escapeCountdown).ToString());
                    _escapeCountdown -= Time.deltaTime;
                }
            }
            else
            {
                _escaping = true;
                _escapeCountdown = _escapeCountdownMax;
            }
        }
        else
        {
            if (_escaping)
            {
                UIManager.Instance.HideEscapeText();
                _escaping = false;
            }
        }
    }

    IEnumerator EndGame_Lose_Coroutine()
    {
        currentState = State.Idle;
        PoliceController.Open();
        GameObject newCage = Instantiate(cage, transform.position + (transform.up * 20), Quaternion.identity);
        bool cageWait = false;
        newCage.transform.SetParent(visual);
        newCage.transform.DOLocalMove(visual.localPosition, .5f).OnComplete(() => cageWait = true).SetEase(Ease.Linear);
        yield return new WaitUntil(() => cageWait == true);
        AudioController.Instance.Play(damage);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.GameOver();
    }

    IEnumerator EndGame_Win_Coroutine()
    {
        GameManager.Instance.PauseGame();
        UIManager.Instance.UpdateEscapeText("YOU'VE ESCAPED!");
        rigid.isKinematic = true;
        transform.DOMove(transform.position + (transform.up * 30), leaveAnimTime).SetEase(leaveEase);
        yield return new WaitForSeconds(2f);
        UIManager.Instance.HideEscapeText();
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.GameOver();
    }

    IEnumerator LoseMoney_Coroutine(PoliceController police)
    {
        currentState = State.Idle;
        PoliceController.Open();
        yield return new WaitForSeconds(2f);
        GameManager.Instance.AddToScore(-police.moneyToTake);
        LoseMoney(police.gameObject, police.moneyToTake);
        yield return new WaitForSeconds(2f);
        PoliceController.ResetAll();
        yield return new WaitForSeconds(1f);
        currentState = State.Active;
        acosted = false;
    }

    private void AggravatePolice()
    {
        if (!_innocent)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, currentInteractionRadius, policeMask);
            foreach (Collider hit in hits)
            {
                if (hit.GetComponent<PoliceController>()._currentState != PoliceController.State.Chase)
                {
                    hit.GetComponent<PoliceController>().Aggravate();
                    AudioController.Instance.Play(alert);
                }
            }
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
        yell.transform.DOMove(to, yellTime).OnComplete(() => DestroyYell(yell.gameObject)).SetEase(yellEase);

        AudioController.Instance.Play(WordDatabase.GetWordAudioClip(word));
    }

    private void RecieveMoney(CustomerController customer, float value)
    {
        Vector3 rand = Random.insideUnitSphere * yellLocationRadius;
        Vector3 from = customer.transform.position + rand;
        from.y = Mathf.Clamp(from.y, customer.transform.position.y, Mathf.Infinity);
        TextMeshPro yell = Instantiate(yellVisual, from, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        yell.text = "+$" + (value * GameSettings.ValueToMoney).ToString();
        if (value > 0)
        {
            yell.color = Color.green;
            AudioController.Instance.Play(profit);

        }
        else
        {
            yell.color = Color.red;
            AudioController.Instance.Play(loss);

        }
        Vector3 to = transform.position + rand;
        to.y = Mathf.Clamp(to.y, transform.position.y, Mathf.Infinity);
        yell.transform.DOMove(to, yellTime).OnComplete(() => DestroyYell(yell.gameObject)).SetEase(yellEase);
    }

    private void LoseMoney(GameObject customer, float amount)
    {
        AudioController.Instance.Play(loss);
        currentInteractionRadius += yellRadiusIncrease;

        Vector3 rand = Random.insideUnitSphere * yellLocationRadius;
        Vector3 from = transform.position + rand;
        from.y = Mathf.Clamp(from.y, transform.position.y, Mathf.Infinity);
        TextMeshPro yell = Instantiate(yellVisual, from, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        yell.text = "-$" + (amount * GameSettings.ValueToMoney).ToString();

        yell.color = Color.red;

        Vector3 to = customer.transform.position + rand;
        to.y = Mathf.Clamp(to.y, customer.transform.position.y, Mathf.Infinity);
        yell.transform.DOMove(to, yellTime).OnComplete(() => DestroyYell(yell.gameObject)).SetEase(yellEase);
    }

    private void DestroyYell(GameObject yellObj)
    {
        Destroy(yellObj.transform.parent.gameObject);
    }
}
