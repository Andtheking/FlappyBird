using Godot;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

public partial class Main : Node2D
{
	[Export]
	private Timer ObstacleSpawn { get; set; }

	[Export]
	private PackedScene ObstacleScene { get; set; }

	[Export]
	private Marker2D ObstacleSpawnPoint { get; set; }

	[Export]
	private Player Player { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnObstacleSpawnTimeout()
	{
		Obstacle newObstacleUp = ObstacleScene.Instantiate<Obstacle>();
		Obstacle newObstacleDown = ObstacleScene.Instantiate<Obstacle>();
		
		newObstacleUp.Position = new(ObstacleSpawnPoint.Position.X, ObstacleSpawnPoint.Position.Y + 100);
		newObstacleUp.Rotate(Mathf.Pi);
		newObstacleDown.Position = new(ObstacleSpawnPoint.Position.X, 400);

		AddChild(newObstacleUp);
		AddChild(newObstacleDown);
	}

	private void OnPlayerHit()
	{
		GetNode<Parallax2D>("Parallax2D").Autoscroll = new(0, 0);
		GetTree().SetGroup("obstacles", Node.PropertyName.ProcessMode, (int) ProcessModeEnum.Disabled);
		ObstacleSpawn.Stop();
	}
}
