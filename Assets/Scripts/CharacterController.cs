using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private TransactionManager transaction;

    private PlayerActions actions;

    [Header("Interaction")]
    public float baseInteractionRadius;
    public float yellRadiusIncrease;
    public float ambientRadiusDecrease;
    public LayerMask customerMask;
    public LayerMask policeMask;
    public LayerMask itemMask;
    public Transform interactionVisual;

    [Header("Items")]
    public Transform itemContainer;
    private GameObject currentItem;

    public float currentInteractionRadius
    {
        get;
        private set;
    }

    private GameObject currentCustomer;
    private bool inTransaction;

    public enum State
    {
        Idle,
        Active
    }
    public State currentState;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        transaction = GetComponent<TransactionManager>();
        Instance = this;

        currentState = State.Active;
        actions = PlayerActions.BindAll();

        currentInteractionRadius = baseInteractionRadius;
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
                if (newCustomer != null)
                {
                    currentCustomer = newCustomer;
                    transaction.StartTransaction(currentCustomer);
                    inTransaction = true;
                }
            }
            else
            {
                if (currentCustomer != null && Vector3.Distance(transform.position, currentCustomer.transform.position) >= baseInteractionRadius)
                {
                    currentCustomer = null;
                    inTransaction = false;
                    transaction.CompleteCurrentTransaction();
					Destroy(currentItem);
					currentItem = null;
                }
            }
            if (inTransaction)
            {
                if (actions.Yell0.WasPressed)
                {
                    currentInteractionRadius += yellRadiusIncrease;
                    transaction.ChooseOption(0);
                }
                if (actions.Yell1.WasPressed)
                {
                    currentInteractionRadius += yellRadiusIncrease;
                    transaction.ChooseOption(1);
                }
                if (actions.Yell2.WasPressed)
                {
                    currentInteractionRadius += yellRadiusIncrease;
                    transaction.ChooseOption(2);
                }
                if (actions.Yell3.WasPressed)
                {
                    currentInteractionRadius += yellRadiusIncrease;
                    transaction.ChooseOption(3);
                }
            }
        }
    }
    private void UpdateInteractionRadius()
    {
        interactionVisual.transform.localScale = Vector3.one * currentInteractionRadius;
        if (currentInteractionRadius > baseInteractionRadius)
        {
            currentInteractionRadius -= ambientRadiusDecrease;
        }
    }
    private void UpdateHeldItem()
    {
        if (currentItem == null)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, baseInteractionRadius, itemMask);
			GameObject newItem = null;
            float currentDistance = baseInteractionRadius;
            foreach (Collider hit in hits)
            {
                float dist = Vector3.Distance(transform.position, hit.transform.position);
                if (dist <= currentDistance)
                {
                    newItem = hit.gameObject;
                    currentDistance = dist;
                }
            }
			if(newItem != null)
			{
				currentItem = newItem;
				currentItem.transform.position = itemContainer.position;
				currentItem.transform.SetParent(itemContainer);
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

    private void AggravatePolice()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, currentInteractionRadius, policeMask);
        foreach (Collider hit in hits)
        {
            hit.GetComponent<PoliceController>().Aggravate();
        }
    }
}
