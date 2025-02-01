using Godot;
using System;

public partial class ProloguePanel : PopupPanel
{
	private PackedScene _scene;
	private Node _instance;
	public Control _control;
	public override void _Ready()
	{
		_control = GetTree().Root.GetNode<Control>("Node2D/Control");
		_scene = (PackedScene)GD.Load("res://Prologue.tscn");
	}
	
	public override void _Process(double delta)
	{
		if(Global.pd)
		{
			ClosePrologue();
			GD.Print("ugh");
		}
	}
	
	public void ShowPrologue()
	{
		_control.SetProcess(false);
		_instance = _scene.Instantiate();
		AddChild(_instance);
		Popup();
	}
	
	public void ClosePrologue()
	{
		_control.SetProcess(true);
		_instance.QueueFree();
		_instance = null;
		Hide();
	}
}
