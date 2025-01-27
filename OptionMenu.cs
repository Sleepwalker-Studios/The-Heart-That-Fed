using Godot;
using System;

public partial class OptionMenu : Control
{
	public override void _Ready()
	{
		Button BackButton = GetTree().Root.GetNode<Button>("Control/MarginContainer/VBoxContainer/Back");
		BackButton.Pressed += OnBackPressed;
	}

	void OnBackPressed()
	{
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
};
