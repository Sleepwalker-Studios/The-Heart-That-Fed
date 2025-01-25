using Godot;
using System;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		Button button = GetTree().Root.GetNode<Button>("Control/MarginContainer/VBoxContainer/Play");
		button.Pressed += OnPlayPressed;
	}
	void OnPlayPressed()
	{
		GetTree().ChangeSceneToFile("res://Base.tscn");
	}
}
