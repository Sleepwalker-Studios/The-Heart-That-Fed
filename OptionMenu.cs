using Godot;
using System;

public partial class OptionMenu : Control
{
	public override void _Ready()
	{
		Button BackButton = GetTree().Root.GetNode<Button>("Control/CanvasLayer/Back");
		BackButton.Pressed += OnBackPressed;
	}

	void OnBackPressed()
	{
		GD.Print("Back button pressed!"); // Add this line
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
}
