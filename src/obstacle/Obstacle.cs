using Godot;
using System;
using System.Diagnostics;

public partial class Obstacle : Area2D
{

	private const float SPEED = 1f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += new Vector2(-1, 0) * 300 * (float) delta;
	}

	public void OnBodyEntered(Node2D body)
	{
		Debug.Print("Collisione!!");
	}
}
