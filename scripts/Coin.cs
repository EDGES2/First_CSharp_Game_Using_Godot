using System;
using Godot;
using MyGame.GameManagerNamespace;

namespace MyGame.Coin;

public partial class Coin : Area2D
{
	private GameManager _gameManager;
	private AnimationPlayer _pickUpAnimation;
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("%GameManager");
		_pickUpAnimation = GetNode<AnimationPlayer>("PickUpAnimation");
	}
	private void OnBodyEntered(Node2D body)
	{
		_gameManager.AddPoint();
		_pickUpAnimation.Play("pickup");
	}
}
