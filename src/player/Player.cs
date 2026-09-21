using Godot;
using System;

public partial class Player : CharacterBody2D
{	
	[Signal]
	public delegate void HitEventHandler();

	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	private bool alive = true;

    public override void _Ready()
    {
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
    }

    public override void _Process(double delta)
    {
		if (Velocity.Y > 0 && Rotation < Mathf.Pi / 4)
		{
			Rotate(Velocity.Y / 100 * Mathf.Pi / 64);
		}
		if (Velocity.Y < 0 && Rotation > -Mathf.Pi / 4)
		{
			Rotate(Velocity.Y / 100 * Mathf.Pi / 64);
		}
    }

	public override void _PhysicsProcess(double delta)
	{
		if (!alive) return;

		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("jump"))
		{
			velocity.Y = JumpVelocity;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void Die() {
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
		ProcessMode = ProcessModeEnum.Disabled;
	}
}
