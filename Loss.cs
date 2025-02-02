using Godot;
using System;

public partial class Loss : Control
{
	public Label _dialogue;
	public override void _Ready()
	{
		_dialogue = GetTree().Root.GetNode<Label>("CanvasLayer/Control/Label");
	}
	
	public override void _Process(double delta)
	{
		var pos = _dialogue.GlobalPosition;
		
		if(pos.Y > 20)
		{
			pos.Y -= 0.5f;
			_dialogue.GlobalPosition = pos;
		}
		if(pos.Y <= 20)
		{
			pos.Y = 20;
			_dialogue.GlobalPosition = pos;
			if(Input.IsActionPressed("ui_next"))
			{
				GetTree().ChangeSceneToFile("res://Main.tscn");
			}
		}
	}
}
