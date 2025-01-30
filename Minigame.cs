using Godot;
using System;
using System.Collections.Generic;

public partial class Minigame : Control
{
	public int b;
	public double timer;
	public int a;
	private int i;
	public int[] key = {0,0,0,0,0};
	public int[] input = {0,0,0,0,0};
	public Button _b1;
	public Button _b2;
	public Button _b3;
	public Button _b4;
	public Button _b5;
	private Panel _p;
	
	public override void _Ready()
	{
		GD.Print("hiya");
		_b1 = GetTree().Root.GetNode<Button>("Node2D/PopupPanel/CanvasLayer/Panel/Control/CanvasLayer/Button");
		_b1.Pressed += OnB1Pressed;
		_b2 = GetTree().Root.GetNode<Button>("Node2D/PopupPanel/CanvasLayer/Panel/Control/CanvasLayer/Button2");
		_b2.Pressed += OnB2Pressed;
		_b3 = GetTree().Root.GetNode<Button>("Node2D/PopupPanel/CanvasLayer/Panel/Control/CanvasLayer/Button3");
		_b3.Pressed += OnB3Pressed;
		_b4 = GetTree().Root.GetNode<Button>("Node2D/PopupPanel/CanvasLayer/Panel/Control/CanvasLayer/Button4");
		_b4.Pressed += OnB4Pressed;
		_b5 = GetTree().Root.GetNode<Button>("Node2D/PopupPanel/CanvasLayer/Panel/Control/CanvasLayer/Button5");
		_b5.Pressed += OnB5Pressed;
		_p = GetTree().Root.GetNode<Panel>("Node2D/PopupPanel/CanvasLayer/Panel");
		
		int[] buttons = {1,2,3,4,5};
		List<int> list = new List<int>(buttons);
		while(i < 5)
		{
			Random random = new Random();
			int bruh = random.Next(0, list.Count);
			key[i] = buttons[bruh];
			list.RemoveAt(bruh);
			buttons = list.ToArray();
			GD.Print(key[i]);
			i++;
		}
	}
	public override void _Process(double delta)
	{
		if(a < 5)
		{
			timer += delta;
			if(timer > 0.3)
			{
				Demo(a);
				timer = 0.0;
				a++;
			}
			
		}
		if(b >= 5)
		{
			if(Equal(key, input)){
				Global.minigame = true;
			}
			else{
				Global.toreload = true;
			}
		}
	}
	
	public void SetScale(float scale)
	{
		_p.Scale = new Vector2(scale, scale);
	}
	
	public bool Equal(int[] a1, int[] a2)
	{
		int counter = 0;
		for(int index = 0; index < a1.Length; index++)
		{
			if(a1[index] == a2[index])
			{
				counter++;
			}
		}
		if(counter == 5){return true;}
		return false;
	}
	
	public void Demo(int j)
	{
		if(key[j] == 1){
			Flash(ref _b1);
		}
		else if(key[j] == 2){
			Flash(ref _b2);
		}
		else if(key[j] == 3){
			Flash(ref _b3);
		}
		else if(key[j] == 4){
			Flash(ref _b4);
		}
		else if(key[j] == 5){
			Flash(ref _b5);
		}
	}
	
	public void Flash(ref Button button)
	{
		GD.Print("aye");
		var i_hate_naming_variables = (button.GetThemeStylebox("normal") as StyleBoxFlat)?.Duplicate() as StyleBoxFlat ?? new StyleBoxFlat();
		i_hate_naming_variables.BgColor = new Color(0,0,0);
		button.AddThemeStyleboxOverride("normal", i_hate_naming_variables);
		button.QueueRedraw();
	}
	
	public void OnB1Pressed()
	{
		input[b] = 1;
		b++;
		var i_hate_naming_variables = (_b1.GetThemeStylebox("normal") as StyleBoxFlat)?.Duplicate() as StyleBoxFlat ?? new StyleBoxFlat();
		i_hate_naming_variables.BgColor = new Color(1,1,1);
		_b1.AddThemeStyleboxOverride("normal", i_hate_naming_variables);
		_b1.QueueRedraw();
	}
	public void OnB2Pressed()
	{
		input[b] = 2;
		b++;
		var i_hate_naming_variables = (_b2.GetThemeStylebox("normal") as StyleBoxFlat)?.Duplicate() as StyleBoxFlat ?? new StyleBoxFlat();
		i_hate_naming_variables.BgColor = new Color(1,1,1);
		_b2.AddThemeStyleboxOverride("normal", i_hate_naming_variables);
		_b2.QueueRedraw();
	}
	public void OnB3Pressed()
	{
		input[b] = 3;
		b++;
		var i_hate_naming_variables = (_b3.GetThemeStylebox("normal") as StyleBoxFlat)?.Duplicate() as StyleBoxFlat ?? new StyleBoxFlat();
		i_hate_naming_variables.BgColor = new Color(1,1,1);
		_b3.AddThemeStyleboxOverride("normal", i_hate_naming_variables);
		_b3.QueueRedraw();
	}
	public void OnB4Pressed()
	{
		input[b] = 4;
		b++;
		var i_hate_naming_variables = (_b4.GetThemeStylebox("normal") as StyleBoxFlat)?.Duplicate() as StyleBoxFlat ?? new StyleBoxFlat();
		i_hate_naming_variables.BgColor = new Color(1,1,1);
		_b4.AddThemeStyleboxOverride("normal", i_hate_naming_variables);
		_b4.QueueRedraw();
	}
	public void OnB5Pressed()
	{
		input[b] = 5;
		b++;
		var i_hate_naming_variables = (_b5.GetThemeStylebox("normal") as StyleBoxFlat)?.Duplicate() as StyleBoxFlat ?? new StyleBoxFlat();
		i_hate_naming_variables.BgColor = new Color(1,1,1);
		_b5.AddThemeStyleboxOverride("normal", i_hate_naming_variables);
		_b5.QueueRedraw();
	}
}
