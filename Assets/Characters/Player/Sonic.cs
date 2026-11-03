using Godot;
using System;

public partial class Sonic : AnimatedSprite2D
{
	private Player _player;
	
	private bool _played = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetParent<Player>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (_player._lookingUp == true)
		{
			Play("Look Up");
		}
		
		if (_player._lookingDown == true)
		{
			Play("Crouch");
		}
		
		if (_player._direction == 0)
		{
			FlipH = false;
		} else FlipH = true;
		
		if ((_player.LinearVelocity.X > 1) && (_player.LinearVelocity.X < 300) && (_player._skid == false) && (_player._jumping == false))
		{
			SpeedScale = (_player.LinearVelocity.X / 300) * 3;
			Play("Jog");
		}
		
		if ((_player.LinearVelocity.X >= 300) && (_player._skid == false) && (_player._jumping == false))
		{
			SpeedScale = (_player.LinearVelocity.X / 400) / 1.15f;
			Play("Run");
		}
		
		if ((_player.LinearVelocity.X < -1) && (_player.LinearVelocity.X > -300) && (_player._skid == false) && (_player._jumping == false))
		{
			SpeedScale = (_player.LinearVelocity.X / 300) * 3;
			if (_player.LinearVelocity.Y < 0.01)
			{
				Play("Jog");
			}
		}
		
		if ((_player.LinearVelocity.X <= -300) && (_player._skid == false) && (_player._jumping == false))
		{
			SpeedScale = (_player.LinearVelocity.X / 400) / 1.15f;
			if (_player.LinearVelocity.Y < 0.01)
			{
				Play("Run");
			}
			
		}
		
		if ((_player.LinearVelocity.X <= 1) && (_player.LinearVelocity.X >= -1) && (_player._skid == false) && (_player._jumping == false) && (_player._lookingDown == false) && (_player._lookingUp == false))
		{
			SpeedScale = 1f;
			if (_player.LinearVelocity.Y < 0.01)
			{
				Play("Idle");
			}
		}
		
		if ((_player._skid == true) && (_player._jumping == false))
		{
			SpeedScale = 1f;
			Play("Skid");
			GetNode<Skid>("Skid")._play = true;
		} else GetNode<Skid>("Skid")._play = false;
		
		if (_player._jumping == true)
		{
			SpeedScale = 1f;
			Play("Jump");
			GetNode<Jump>("Jump")._play = true;
		} else GetNode<Jump>("Jump")._play = false;
	}
}
