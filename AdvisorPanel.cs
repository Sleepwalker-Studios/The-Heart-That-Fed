using Godot;
using System;

public partial class AdvisorPanel : PopupPanel
{
	private PackedScene _scene;
	private Node _instance;
	public Control _control;
	public override void _Ready()
	{
		_control = GetTree().Root.GetNode<Control>("Node2D/Control");
		_scene = (PackedScene)GD.Load("res://Advisor.tscn");
	}
	
	public override void _Process(double delta)
	{
		if(Global.meetnum == 1)
		{
			if(Global.meet1check)
			{
				CloseAdvisor();
				Global.meetnum++;
			}
		}
		if(Global.meetnum == 2)
		{
			if(Global.meet2check)
			{
				CloseAdvisor();
				Global.meetnum++;
			}
		}
		if(Global.meetnum == 3)
		{
			if(Global.meet3check)
			{
				CloseAdvisor();
				Global.meetnum++;
			}
		}
	}
	
	public void ShowAdvisor()
	{
		_control.SetProcess(false);
		_instance = _scene.Instantiate();
		AddChild(_instance);
		Popup();
	}
	
	public void CloseAdvisor()
	{
		_instance.QueueFree();
		_instance = null;
		Hide();
		_control.SetProcess(true);
		Global.resume = true;
	}
}
