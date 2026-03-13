using System;
using Godot;

namespace MyGame.KillZone;

public partial class KillZone : Area2D
{
	private Timer _timer;

	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
	}

	private void OnBodyEntered(Node2D body)
	{

		Engine.TimeScale = 0.5;
		GD.Print("You died");
		body.GetNodeOrNull<CollisionShape2D>("CollisionShape2D")?.QueueFree();

		_timer.Start();
	}
	private void OnTimerTimeout()
	{
		Engine.TimeScale = 1.0;
		GetTree().ReloadCurrentScene();
	}
}
