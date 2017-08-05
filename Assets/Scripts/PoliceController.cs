using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceController : AiController 
{
	private CharacterController player
	{
		get
		{
			return CharacterController.Instance;
		}
	}

	public enum State
	{
		Idle,
		Patrol,
		Chase
	}
	private State currentState;

	private void Start()
	{
		Initialize();
	}
	public void Aggravate()
	{
		currentState = State.Chase;
	}
	private void Update()
	{
		RunStates();
	}
	private void RunStates()
	{
		switch(currentState)
		{
			case State.Idle:
			UpdateWander();
			break;
			case State.Chase:
			ChasePlayer();
			break;
		}
	}
	private void ChasePlayer()
	{
		agent.SetDestination(player.transform.position);
	}

}
