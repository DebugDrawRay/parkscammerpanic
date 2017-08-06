using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerActions : PlayerActionSet 
{
	public PlayerTwoAxisAction Move;
	public PlayerAction MoveUp;
	public PlayerAction MoveDown;
	public PlayerAction MoveLeft;
	public PlayerAction MoveRight;

	public PlayerAction Yell0;
	public PlayerAction Yell1;	
	public PlayerAction Yell2;
	public PlayerAction Yell3;

	public PlayerActions()
	{
		MoveUp = CreatePlayerAction("Move Up");
		MoveDown = CreatePlayerAction("Move Down");
		MoveLeft = CreatePlayerAction("Move Left");
		MoveRight = CreatePlayerAction("Move Right");
		Move = CreateTwoAxisPlayerAction(MoveLeft, MoveRight, MoveDown, MoveUp);

		Yell0 = CreatePlayerAction("Yell 0");
		Yell1 = CreatePlayerAction("Yell 1");
		Yell2 = CreatePlayerAction("Yell 2");
		Yell3 = CreatePlayerAction("Yell 3");
	}

	public static PlayerActions BindAll()
	{
		PlayerActions actions = new PlayerActions();
		actions.MoveUp.AddDefaultBinding(Key.W);
		actions.MoveDown.AddDefaultBinding(Key.S);
		actions.MoveLeft.AddDefaultBinding(Key.A);
		actions.MoveRight.AddDefaultBinding(Key.D);

		actions.MoveUp.AddDefaultBinding(InputControlType.LeftStickUp);
		actions.MoveDown.AddDefaultBinding(InputControlType.LeftStickDown);
		actions.MoveLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
		actions.MoveRight.AddDefaultBinding(InputControlType.LeftStickRight);

		actions.Yell0.AddDefaultBinding(Key.UpArrow);
		actions.Yell1.AddDefaultBinding(Key.LeftArrow);
		actions.Yell2.AddDefaultBinding(Key.DownArrow);
		actions.Yell3.AddDefaultBinding(Key.RightArrow);		
		
		actions.Yell0.AddDefaultBinding(InputControlType.Action4);
		actions.Yell1.AddDefaultBinding(InputControlType.Action3);
		actions.Yell2.AddDefaultBinding(InputControlType.Action1);
		actions.Yell3.AddDefaultBinding(InputControlType.Action2);
		return actions;
	}
}
