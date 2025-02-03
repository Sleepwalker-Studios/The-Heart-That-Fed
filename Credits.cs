using Godot;
using System;

public partial class Credits : Control
{
	public float idk = 0.35f;
	public Label _dialogue;
	public ColorRect _cr;
	public AnimatedSprite2D _bg;
	public override void _Ready()
	{
		_bg = GetTree().Root.GetNode<AnimatedSprite2D>("CanvasLayer/ColorRect/AnimatedSprite2D");
		_bg.Play("bg");
		_cr = GetTree().Root.GetNode<ColorRect>("CanvasLayer/ColorRect");
		_dialogue = GetTree().Root.GetNode<Label>("CanvasLayer/Control/Label");
		_dialogue.Text = "\n\n\nCONGRATULATIONS\n\nReigned for 66 years\nExploited " + Global.exploit + " subjects\nKilled and replaced "
						 + Global.killed + " workers\nStarved " + Global.starved + 
						" people\n\n\nNothing beside remains.\n\n\n\n\n\n\n\n\n--CREDITS--\n\nWritten, Designed & Directed by:\nWTV\n\nProgrammed by:\nJeremy Poulin & Hayat Ahmad\n\nDrawn & Animated by:\nDimsun\n\nScored by:\nOtter Eve\n\nInspired by Percy Shelley's Ozymandias\n\n\n\n\n\n\n\n\nA game by Sleepwalker Studios";
	}
	
	public override void _Process(double delta)
	{
		var pos = _dialogue.GlobalPosition;
		
		if(pos.Y > -2100)
		{
			pos.Y -= 0.5f;
			_dialogue.GlobalPosition = pos;
		}
		if(pos.Y <= -2100)
		{
			idk += 0.001f;
			pos.Y = -2100;
			_dialogue.GlobalPosition = pos;
			_cr.Color = new Color(0,0,0,idk);
			if(idk >= 1)
			{
				GetTree().ChangeSceneToFile("res://Main.tscn");
			}
		}
		
	}

}
