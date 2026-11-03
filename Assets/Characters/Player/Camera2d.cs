using Godot;
using System;

public partial class Camera2d : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Position = new Vector2((GetParent<Player>().LinearVelocity.X / 500f) * 145f, -19.585f);
	}
}
