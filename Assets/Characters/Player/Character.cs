using Godot;
using System;

public partial class Character : Sprite2D
{
	
	private Player _player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetParent<Camera2d>().GetParent<Player>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (!((_player.LinearVelocity.Y > -0.01) && (_player.LinearVelocity.Y < 0.01)))
		{
			CreateTween().TweenProperty(this, "position", new Vector2(Position.X, -54.554f), 0.5f)
	 			.SetTrans(Tween.TransitionType.Sine)
	 			.SetEase(Tween.EaseType.Out);
		} else
		{
			CreateTween().TweenProperty(this, "position", new Vector2(Position.X, -57.857f), 0.5f)
	 			.SetTrans(Tween.TransitionType.Elastic)
	 			.SetEase(Tween.EaseType.Out);
		}
		
		if ((!(Input.IsKeyPressed(Key.Left))) && (!(Input.IsKeyPressed(Key.Right))))
		{
			CreateTween().TweenProperty(this, "position", new Vector2(-77.852f, Position.Y), 0.5f)
	 			.SetTrans(Tween.TransitionType.Sine)
	 			.SetEase(Tween.EaseType.Out);
		} else
		{
			if (!(Input.IsKeyPressed(Key.Right)))
			{
				CreateTween().TweenProperty(this, "position", new Vector2(-90.996f, Position.Y), 0.5f)
	 				.SetTrans(Tween.TransitionType.Sine)
	 				.SetEase(Tween.EaseType.Out);
			}
			
			if (!(Input.IsKeyPressed(Key.Left)))
			{
				CreateTween().TweenProperty(this, "position", new Vector2(-59.653f, Position.Y), 0.5f)
	 				.SetTrans(Tween.TransitionType.Sine)
	 				.SetEase(Tween.EaseType.Out);
			}
		}
	}
}
