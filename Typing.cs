using Godot;
using System;

public partial class Typing : Label
{
	public Timer _timer;
	public override void _Ready()
	{
		_timer = GetTree().Root.GetNode<Timer>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel2/Label/Timer");
		_timer.Timeout += OnTimeout;
		Global.starttyping = false;
		Global.typing = true;
		VisibleCharacters = 0;
		_timer.Start();
	}
	public override void _Process(double delta)
	{
		if(Global.starttyping)
		{
			Global.starttyping = false;
			Global.typing = true;
			VisibleCharacters = 0;
			_timer.Start();
		}
	}
	public void OnTimeout()
	{
		VisibleCharacters++;
		if(VisibleCharacters >= Text.Length)
		{
			_timer.Stop();
			Global.typing = false;
		}
	}
}
