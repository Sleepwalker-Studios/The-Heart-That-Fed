using Godot;
using System;

public partial class DynamicUI : Control
{
	public double gold_timer;
	public int gold;
	public int hunger;
	public int happiness;
	public int total_workers;
	public int passive_workers;
	public int active_workers;
	public int farmers;
	public int traders;
	public int builders;
	public int statue;
	private Label _gold;
	private Label _workers;
	private Label _hunger;
	private Label _statue;
	private Label _year;
	private Label _month;
	private Label _day;
	private Label _village;
	private Label _statuenum;
	private Label _farm;
	private ProgressBar _hungerbar;
	private ProgressBar _statuebar;
	private Button _buybutton;
	private Button _vup;
	private Button _sup;
	private Button _fup;
	private Button _vdown;
	private Button _sdown;
	private Button _fdown;
	public double tick;
	public int i = 4;
	public int year_value = 1279;
	public string[] month_value = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
	public int day_value = 31;
	
	public override void _Ready()
	{
		_year = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Panel/Year");
		_month = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Panel2/Month");
		_day = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Panel3/Day");
		_gold = GetTree().Root.GetNode<Label>("Node2D/Control/Money/Gold");
		_workers = GetTree().Root.GetNode<Label>("Node2D/Control/Workers/WorkerCount");
		_hungerbar = GetTree().Root.GetNode<ProgressBar>("Node2D/Control/HungerBox/ProgressBar");
		_statuebar = GetTree().Root.GetNode<ProgressBar>("Node2D/Control/StatueBox/ProgressBar");
		_hunger = GetTree().Root.GetNode<Label>("Node2D/Control/HungerBox/Hunger");
		_statue = GetTree().Root.GetNode<Label>("Node2D/Control/StatueBox/Statue");
		_buybutton = GetTree().Root.GetNode<Button>("Node2D/Control/Workers/CanvasLayer/BuyWorkers");
		_buybutton.Pressed += OnBuyWorkersPressed;
		_vup = GetTree().Root.GetNode<Button>("Node2D/Control/Village/CanvasLayer/Up");
		_vup.Pressed += OnVUPPressed;
		_vdown = GetTree().Root.GetNode<Button>("Node2D/Control/Village/CanvasLayer/Down");	
		_vdown.Pressed += OnVDOWNPressed;
		_sup = GetTree().Root.GetNode<Button>("Node2D/Control/Statue/CanvasLayer/Up");
		_sup.Pressed += OnSUPPressed;
		_sdown = GetTree().Root.GetNode<Button>("Node2D/Control/Statue/CanvasLayer/Down");
		_sdown.Pressed += OnSDOWNPressed;
		_fup = GetTree().Root.GetNode<Button>("Node2D/Control/Farm/CanvasLayer/Up");
		_fup.Pressed += OnFUPPressed;
		_fdown = GetTree().Root.GetNode<Button>("Node2D/Control/Farm/CanvasLayer/Down");
		_fdown.Pressed += OnFDOWNPressed;
		_village = GetTree().Root.GetNode<Label>("Node2D/Control/Village/Label");
		_statuenum = GetTree().Root.GetNode<Label>("Node2D/Control/Statue/Label");
		_farm = GetTree().Root.GetNode<Label>("Node2D/Control/Farm/Label");
	}
	
	public override void _Process(double delta)
	{
		gold_timer += delta;
		tick += delta;
		if(tick >= 0.0328767)
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
		if(farmers < 30)
		{
			if(hunger < 100)
			{
			hunger += 1;
			}
		}
		if(gold_timer >= 1.0)
		{
			gold++;
			gold_timer = 0;
		}
		total_workers = active_workers + passive_workers;
		_year.Text = year_value.ToString();
		_month.Text = month_value[i];
		_day.Text = day_value.ToString();
		_gold.Text = gold.ToString() + " G";
		_workers.Text = passive_workers.ToString();
		_hungerbar.Value = hunger;
		_statuebar.Value = statue;
		_hunger.Text = hunger.ToString() + "%";
		_statue.Text = statue.ToString() + "%";
		_village.Text = traders.ToString();
		_statuenum.Text = builders.ToString();
		_farm.Text = farmers.ToString();
		
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
	
	void OnBuyWorkersPressed()
	{
		passive_workers += 10;
		gold -= 5;
	}
	
	void OnVUPPressed()
	{
		traders += 5;
		passive_workers -= 5;
		active_workers += 5;
	}
	
	void OnSUPPressed()
	{
		builders += 5;
		passive_workers -= 5;
		active_workers += 5;
	}
	
	void OnFUPPressed()
	{
		farmers += 5;
		passive_workers -= 5;
		active_workers += 5;
	}
	
	void OnVDOWNPressed()
	{
		traders -= 5;
		passive_workers += 5;
		active_workers -= 5;
	}
	
	void OnSDOWNPressed()
	{
		builders -= 5;
		passive_workers += 5;
		active_workers -= 5;
	}
	
	void OnFDOWNPressed()
	{
		farmers -= 5;
		passive_workers += 5;
		active_workers -= 5;
	}
	
}
