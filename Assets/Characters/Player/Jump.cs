using Godot;
using System;

public partial class Jump : AudioStreamPlayer2D
{
	public bool _play = false;
	private bool _played = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (_play == true)
		{
			if (_played == false)
			{
				Play();
				_played = true;
			}
		} else _played = false;
		
	}
}
