using System;
using Godot;

namespace MyGame.Player;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 130.0f;
	[Export] public float JumpVelocity = -300.0f;

	private AnimatedSprite2D _playerSprite;

	public override void _Ready()
	{
		_playerSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		//Direction facing
		float direction = Input.GetAxis("move_left", "move_right");
		if (direction > 0)
			_playerSprite.FlipH = false;
		else if (direction < 0)
			_playerSprite.FlipH = true;


		//Animations
		if (IsOnFloor())
		{
			if (direction == 0)
				_playerSprite.Play("idle");
			else
				_playerSprite.Play("run");
		}
		else _playerSprite.Play("jump");

		//Movement handling
		Vector2 velocity = Velocity;
		if (!IsOnFloor())
			velocity += GetGravity() * (float)delta;    //We use (float) convertion type because
														//  "speed" variable defined as float.
														//And in C# there could be the issue with
														//  multiplying double with float, because
														//  double is 64-bit, and float is 32-bit

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;
		if (direction != 0)
			velocity.X = direction * Speed;
		else
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);    // We use it to add some control
																	//  feeling into movement.
																	//So character doesn't stop
                                                                    //  instantly
        Velocity = velocity;
		MoveAndSlide(); //Without this function we can't use "IsOnFloor()". This function also
						//  implements sliding physics
	}
}
