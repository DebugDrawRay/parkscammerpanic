using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
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
        currentState = State.Active;
        actions = PlayerActions.BindAll();
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
        GameObject newCustomer = GetClosestCustomer();
		if(newCustomer != currentCustomer)
		{
			currentCustomer = newCustomer;
			transaction.StartTransaction(currentCustomer);
			inTransaction = true;
		}
        if (currentCustomer == null && inTransaction)
		{
			transaction.CompleteCurrentTransaction();
			inTransaction = false;
		}
        if(inTransaction)
		{
            if (actions.Yell0.WasPressed)
            {
                transaction.ChooseOption(0);
            }
            if (actions.Yell1.WasPressed)
            {
                transaction.ChooseOption(1);
            }
            if (actions.Yell2.WasPressed)
            {
                transaction.ChooseOption(2);
            }
            if (actions.Yell3.WasPressed)
            {
                transaction.ChooseOption(3);
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
			//implement police aggro
        }
	}
}
