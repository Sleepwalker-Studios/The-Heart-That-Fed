using Godot;
using System;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		Button playButton = GetTree().Root.GetNode<Button>("Control/MarginContainer/VBoxContainer/Play");
		playButton.Pressed += OnPlayPressed;

		Button quitButton = GetTree().Root.GetNode<Button>("Control/MarginContainer/VBoxContainer/Quit");
		quitButton.Pressed += OnQuitPressed;
		
		Button optionsButton = GetTree().Root.GetNode<Button>("Control/MarginContainer/VBoxContainer/Options");
		optionsButton.Pressed += OnOptionsPressed; 
	}

	void OnPlayPressed()
	{
		GetTree().ChangeSceneToFile("res://Prologue.tscn");
	}

	void OnQuitPressed()
	{
		GetTree().Quit();
	}

	void OnOptionsPressed()
	{
		GetTree().ChangeSceneToFile("res://OptionMenu.tscn");
	}
}
