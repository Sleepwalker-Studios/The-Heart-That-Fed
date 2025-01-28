using Godot;
using System;

public partial class MinigamePanel : PopupPanel
{
	private PackedScene _mscene;
	private Node _minstance;
	public override void _Ready()
	{
		_mscene = (PackedScene)GD.Load("res://Minigame.tscn");
	}
	
	public void ShowMinigame()
	{
		_minstance = _mscene.Instantiate();
		AddChild(_minstance);
		Popup();
	}
	
	public void ResetMinigame()
	{
		_minstance.QueueFree();
		_minstance = _mscene.Instantiate();
		AddChild(_minstance);
	}
	
	public void CloseMinigame()
	{
		_minstance.QueueFree();
		_minstance = null;
		Hide();
	}
}
