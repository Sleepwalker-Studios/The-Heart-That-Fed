using Godot;
using System;

public partial class MilitaryPanel : PopupPanel
{
	private PackedScene _scene;
	private Node _instance;
	public Control _control;
	public override void _Ready()
	{
		_control = GetTree().Root.GetNode<Control>("Node2D/Control");
		_scene = (PackedScene)GD.Load("res://Military.tscn");
	}
	
	public override void _Process(double delta)
	{
		if(Global.mcheck)
		{
			CloseMilitary();
		}
	}
	
	public void ShowMilitary()
	{
		_control.SetProcess(false);
		_instance = _scene.Instantiate();
		AddChild(_instance);
		Popup();
	}
	
	public void CloseMilitary()
	{
		_control.SetProcess(true);
		Global.resume = true;
		_instance.QueueFree();
		_instance = null;
		Hide();
	}
}
