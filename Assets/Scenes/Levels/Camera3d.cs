using Godot;
using System;

public partial class Camera3d : Camera3D
{
	private float _top = 2.228f;
	private float _bottom = -0.35f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if ((GlobalPosition.Y >  0.454f) && (GlobalPosition.Y < 1.241f))
		{
			GlobalPosition = new Vector3(GetParent().GetParent().GetNode<Player>("Player").GlobalPosition.X / 500, -(GetParent().GetParent().GetNode<Player>("Player").GlobalPosition.Y / 1000), GlobalPosition.Z);
		} else
		{
			GlobalPosition = new Vector3(GetParent().GetParent().GetNode<Player>("Player").GlobalPosition.X / 500, GlobalPosition.Y, GlobalPosition.Z);
		}
		
	}
}
