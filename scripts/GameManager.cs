using System;
using Godot;

namespace MyGame.GameManagerNamespace;

public partial class GameManager : Node
{
	private Label _scoreLabel;
	public override void _Ready()
	{
		_scoreLabel = GetNode<Label>("%ScoreLabel");
		_scoreLabel.Text = $"Score: {score}";
	}
	private int score = 0;
	public void AddPoint()
	{
		score += 1;
		_scoreLabel.Text = $"Score: {score}";
	}
}
