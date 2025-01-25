using Godot;
using System;

public partial class DynamicUI : Control
{
	
	private Label _year;
	private Label _month;
	private Label _day;
	public int year_value = 1279;
	public int month_value = 4;
	public int day_value = 31;
	
	public override void _Ready()
	{
		_year = GetNode<Label>("year");
		_month = GetNode<Label>("month");
		_day = GetNode<Label>("day");
	}
	public override void _Process(double delta)
	{
		
		_year.Text = year_value.ToString();
		_month.Text = month_value.ToString();
		_day.Text = day_value.ToString();
	}
}
