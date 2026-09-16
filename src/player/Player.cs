using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

    public override void _Ready()
    {
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
    }

	public override void _PhysicsProcess(double delta)
	{
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
		if (velocity.Y > 0 && Rotation < Mathf.Pi / 4)
		{
			Rotate(velocity.Y / 100 * Mathf.Pi / 64);
		}
		if (velocity.Y < 0 && Rotation > -Mathf.Pi / 4)
		{
			Rotate(velocity.Y / 100 * Mathf.Pi / 64);
		}
		MoveAndSlide();
	}
}
