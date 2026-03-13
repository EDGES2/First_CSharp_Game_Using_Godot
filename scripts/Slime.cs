using System;
using Godot;

namespace MyGame.Enemy.GreenSlime;

public partial class Slime : Node2D
{
	[Export] public float speed = 60.0f;    // We use [Export] to show this property in godot
											//  "Inspector" panel

	private int _direction = 1; // 1 = Right, -1 = Left

	private RayCast2D _rayCastRight;
	private RayCast2D _rayCastLeft;
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		// Cache references to the nodes
		_rayCastRight = GetNode<RayCast2D>("RayCastRight");
		_rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _Process(double delta)
	{
		// Check for wall collisions using RayCasts
		if (_rayCastRight.IsColliding())
		{
			_direction = -1;
			_animatedSprite.FlipH = true;
		}

		if (_rayCastLeft.IsColliding())
		{
			_direction = 1;
			_animatedSprite.FlipH = false;
		}

		Vector2 position = Position;
		position.X += _direction * speed * (float)delta;    //We use (float) convertion type because
															//  "speed" variable defined as float.
															//And in C# there could be the issue with
															//  multiplying double with float, because
															//  double is 64-bit, and float is 32-bit
		Position = position;
	}
}
