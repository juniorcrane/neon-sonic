using Godot;
using System;

public partial class Player : RigidBody2D
{
	public float _speed = 0;
	
	private bool _rightStarted = false;
	private bool _leftStarted = true;
	
	public bool _skid = false;
	public int _direction = 0;
	
	public bool _jumping = false;
	public float _jumpY = 0;
	public bool _canJump = true;
	public bool _initialJump = false;
	
	public int _currentCard = 1;
	public bool _swapped = false;
	
	public bool _lookingDown = false;
	public bool _lookingUp = false;
	
	public bool _stepPlayed = false;
	
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		if (LinearVelocity.Y < 0.01f)
		{
			if (_stepPlayed == false)
			{
				GetNode<AudioStreamPlayer2D>("Fall").Play();
				_stepPlayed = true;
			}
		} else _stepPlayed = false;
		
		if (Input.IsKeyPressed(Key.C))
		{
			if (_swapped == false)
			{
				GetNode<AudioStreamPlayer2D>("Swap").Play();
				_currentCard += 1;
				_swapped = true;
			}
		} else _swapped = false;
		
		if (_currentCard > 3)
		{
			_currentCard = 1;
		}
		
		if (GlobalPosition.Y > 194.0)
		{
			GlobalPosition = new Vector2(0, 0);
		}
		
		GlobalRotation = 0;
		
		if (Input.IsKeyPressed(Key.Right))
		{
			if (LinearVelocity.X < -100)
			{
				_skid = true;
			} else _skid = false;
			
			_direction = 0;
			if (LinearVelocity.X < 400)
			{
				LinearVelocity = new Vector2(LinearVelocity.X + 5f, LinearVelocity.Y);
			} else LinearVelocity = new Vector2(LinearVelocity.X + 1f, LinearVelocity.Y);
		}
		
		if (Input.IsKeyPressed(Key.Left))
		{
			if (LinearVelocity.X > 100)
			{
				_skid = true;
			} else _skid = false;
			
			_direction = 1;
			if (LinearVelocity.X > -400)
			{
				LinearVelocity = new Vector2(LinearVelocity.X - 5f, LinearVelocity.Y);
			} else LinearVelocity = new Vector2(LinearVelocity.X - 1f, LinearVelocity.Y);
		}
		
		if ((LinearVelocity.Y < 0.1) && (LinearVelocity.Y > -0.1))
		{
			if (Input.IsKeyPressed(Key.Up))
			{
				_lookingUp = true;
			} else _lookingUp = false;
			
			if (Input.IsKeyPressed(Key.Down))
			{
				_lookingDown = true;
			} else _lookingDown = false;
		} else
		{
			_lookingDown = false;
			_lookingDown = false;
		}
		
		Translate(new Vector2(0, -_jumpY));
		
		if ((LinearVelocity.Y < 0.1) && (LinearVelocity.Y > -0.1) && (!(Input.IsKeyPressed(Key.Z))))
		{
			_canJump = true;
		} else _canJump = false;
		
		if ((Input.IsKeyPressed(Key.Z)) && (LinearVelocity.Y < 0.1) && (LinearVelocity.Y > -0.1))
		{
			_jumping = true;
		}
		
		if (_jumping == true)
		{
			if (_initialJump == false)
			{
				_jumpY = 8f;
				_initialJump = true;
			}
			
			if (_jumpY <= 0)
			{
				_jumping = false;
			}
			
			if (!(Input.IsKeyPressed(Key.Z)))
			{
				if (_jumpY > 0)
				{
					_jumpY -= 0.3f;
				}
			} else _jumpY -= 0.08f;
		} else 
		{
			_jumpY = 0;
			_initialJump = false;
		}
	}
}
