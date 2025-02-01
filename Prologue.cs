using Godot;
using System;

public partial class Prologue : Control
{
	public string[] prologue = new string[3]{"In the Nineteenth Dynasty of Egypt, 13th Century BC, pharaoh Seti I passed his throne onto his son", 
												"whose ruthlessness and pride were matched only by his hunger to become Egypt's greatest ruler.", 
												"You may have heard his name before, but I will let him tell you himself..."};
	public int i;
	public Label _dialogue;
	public override void _Ready()
	{
		_dialogue = GetTree().Root.GetNode<Label>("Node2D/ProloguePanel/CanvasLayer/Control/Panel2/Label");
	}
	
	public override void _Process(double delta)
	{
		_dialogue.Text = prologue[i];
		if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
		{
			Global.starttyping = true;
			i++;
		}
		if(i > 2)
		{
			Global.pd = true;
		}
	}
	
}
