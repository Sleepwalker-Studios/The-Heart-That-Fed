using Godot;
using System;

public partial class Pan : Camera2D
{
	public bool wait;
	public bool quit;
	public bool start;
	public Vector2 pos;
	public float pan;
	public Timer _delay;
	public Timer _quit;
	public Timer _wait;
	
	public override void _Ready()
	{
		_delay = GetTree().Root.GetNode<Timer>("Control/Timer");
		_quit = GetTree().Root.GetNode<Timer>("Control/Timer2");
		_wait = GetTree().Root.GetNode<Timer>("Control/Timer3");
		_wait.Start();
		_delay.Start();
		_delay.Timeout += OnTimeout;
		_wait.Timeout += OnWaitTimeout;
		_quit.Timeout += OnQuitTimeout;
		_quit.Start();
		pos = Position;
	}
	
	public override void _Process(double delta)
	{
		if(start)
		{
			pan += (float)(0.0005 * delta);
			pan = Mathf.Clamp(pan, 0f, 1f);
			pos.Y = Mathf.Lerp(pos.Y, 190f, pan);
			Position = pos;
			if(wait)
			{
				Zoom = Zoom.Lerp(new Vector2(8,8), (float)(0.25 * delta));
			}
		}
		if(pan >= 1f)
		{
			_quit.Start();
		}
		if(quit)
		{
			GetTree().ChangeSceneToFile("res://Credits.tscn");
		}
	}
	
	public void OnTimeout()
	{
		start = true;
	}
	public void OnQuitTimeout()
	{
		quit = true;
	}
	
	public void OnWaitTimeout()
	{
		wait = true;
	}
}
