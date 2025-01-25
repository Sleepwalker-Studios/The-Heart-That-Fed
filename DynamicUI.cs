using Godot;
using System;

public partial class DynamicUI : Control
{
	private Label _year;
	private Label _month;
	private Label _day;
	public double tick;
	public int i = 4;
	public int year_value = 1279;
	public string[] month_value = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
	public int day_value = 31;
	
	public override void _Ready()
	{
		_year = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Year");
		_month = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Month");
		_day = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Day");
	}
	
	public override void _Process(double delta)
	{
		tick += delta;
		if(tick >= 0.05)
		{
				day_value++;
				tick = 0;
		}
		if(day_value >= Month_Length(i))
		{
			day_value = 1;
			if(i < 11)
			{
				i++;
			}
			else
			{
				i = 0;
				year_value--;
			}
		}
		_year.Text = year_value.ToString();
		_month.Text = month_value[i];
		_day.Text = day_value.ToString();
		if(year_value == 1213 && i == 7 && day_value == 8)
		{
			GD.Print("cooked");
			GetTree().ChangeSceneToFile("res://Main.tscn");
		}
	}
	
	public int Month_Length(int month)
	{
		if(month == 0 || month == 2 || month == 4 || month == 6 || month == 7 || month == 9 || month == 11)
		{
			return 31;
		}
		else if(month == 3 || month == 5 || month == 8 || month == 10)
		{
			return 30;
		}
		else if(month == 1)
		{
			return 28;
		}
		return 0;
	}
}
