using Godot;
using System;

public partial class Prologue : Control
{
	public string[] prologue = new string[0]{};
	public int i;
	public Label _dialogue;
	public override void _Ready()
	{
		_dialogue = GetTree().Root.GetNode<Label>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel2/Label");
	}
	
	public override void _Process(double delta)
	{
		_dialogue.Text = prologue[i];
		if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
		{
			Global.starttyping = true;
			i++;
		}
		if(i > 5)
		{
			//close
		}
	}
	
}
