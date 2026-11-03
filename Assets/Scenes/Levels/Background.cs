using Godot;
using System;

public partial class Background : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GlobalPosition = GetParent().GetNode<Player>("Player").GetNode<Camera2d>("Camera2D").GlobalPosition;
	}
}
