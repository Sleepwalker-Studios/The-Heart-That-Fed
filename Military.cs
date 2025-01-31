using Godot;
using System;

public partial class Military : Control
{
	public Label _cost;
	public Button _b1;
	public Button _b2;
	public Button _check;
	public override void _Ready()
	{
		_cost = GetTree().Root.GetNode<Label>("Node2D/MilitaryPanel/CanvasLayer/Control/Panel/Panel/Label");
		_b1 = GetTree().Root.GetNode<Button>("Node2D/MilitaryPanel/CanvasLayer/Control/Panel/Button");
		_b1.Pressed += OnB1Pressed;
		_b2 = GetTree().Root.GetNode<Button>("Node2D/MilitaryPanel/CanvasLayer/Control/Panel/Button2");
		_b2.Pressed += OnB2Pressed;
		_check = GetTree().Root.GetNode<Button>("Node2D/MilitaryPanel/CanvasLayer/Control/Panel/Confirm");
		_check.Pressed += OnCheckPressed;
	}
	public override void _Process(double delta)
	{
		_cost.Text = Global.invest.ToString() + " G";
	}
	
	public void OnB1Pressed()
	{
		Global.invest += 100;
		if(Global.invest >= Global.gold)
		{
			Global.invest = Global.gold;
		}
	}
	
	public void OnB2Pressed()
	{
		Global.invest -= 100;
		if(Global.invest <= 0)
		{
			Global.invest = 0;
		}
	}
	
	public void OnCheckPressed()
	{
		Global.mcheck = true;
		Global.gold -= Global.invest;
	}
	
}
