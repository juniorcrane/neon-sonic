using Godot;
using System;

public partial class Card3 : AnimatedSprite2D
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
		if (_player._currentCard == 3)
		{
			ZIndex = 2;
			CreateTween().TweenProperty(this, "position", new Vector2(109.638f, -50.247f), 0.5f)
	 			.SetTrans(Tween.TransitionType.Expo)
	 			.SetEase(Tween.EaseType.Out);
		}
		
		if (_player._currentCard == 2)
		{
			ZIndex = 1;
			CreateTween().TweenProperty(this, "position", new Vector2(156.147f, -50.247f), 0.5f)
	 			.SetTrans(Tween.TransitionType.Expo)
	 			.SetEase(Tween.EaseType.Out);
		}
		
		if (_player._currentCard == 1)
		{
			ZIndex = 0;
			CreateTween().TweenProperty(this, "position", new Vector2(201.203f, -50.04f), 0.5f)
	 			.SetTrans(Tween.TransitionType.Expo)
	 			.SetEase(Tween.EaseType.Out);
		}
	}
}
