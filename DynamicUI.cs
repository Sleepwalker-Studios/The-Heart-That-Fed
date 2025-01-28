using Godot;
using System;

public partial class DynamicUI : Control
{
	public double sidetick;
	public bool sidepressed;
	public int statuerevoltcount;
	public bool revoltbool = false;
	public double revolttick;
	public bool villagerevolt;
	public bool statuerevolt;
	public bool farmrevolt;
	private Label _dialoguecontrol;
	private bool vupheld;
	private bool supheld;
	private bool fupheld;
	private bool vdownheld;
	private bool sdownheld;
	private bool fdownheld;
	public double revolt_timer;
	public double revolt_cooldown;
	public int cooldown_timer;
	public int hold_timer;
	public int statue_py;
	public int hunger_py;
	public int gold_py;
	public int worker_buy_count = 5;
	public int worker_price = 100;
	public int state = 1;
	public int statue_py_temp;
	public int hunger_temp;
	public int gold_py_temp;
	public double gold_timer;
	public int gold = 1000;
	public int hunger;
	public int happiness = 100;
	public int total_workers;
	public int passive_workers;
	public int active_workers;
	public int farmers;
	public int traders;
	public int builders;
	public int statue;
	private Label _gold;
	private Label _workers;
	private Label _workerstotal;
	private Label _hunger;
	private Label _statue;
	private Label _year;
	private Label _month;
	private Label _day;
	private Label _village;
	private Label _statuenum;
	private Label _farm;
	private Panel _villagepanel;
	private Panel _statuepanel;
	private Panel _farmpanel;
	private ProgressBar _hungerbar;
	private ProgressBar _statuebar;
	private ProgressBar _revoltbar;
	private Button _buybutton;
	private Button _vup;
	private Button _sup;
	private Button _fup;
	private Button _vdown;
	private Button _sdown;
	private Button _fdown;
	public Button _left;
	public Button _right;
	public Button _pause;
	public Button _vrevolt;
	public Button _srevolt;
	public Button _frevolt;
	public Sprite2D _pausesprite;
	public Sprite2D _playsprite;
	public Sprite2D _villagesprite;
	public Sprite2D _statuesprite;
	public Sprite2D _farmsprite;
	public Sprite2D _villagealert;
	public Sprite2D _statuealert;
	public Sprite2D _farmalert;
	public Label _villagelabel;
	public Label _statuelabel;
	public Label _farmlabel;
	public Label _price;
	public Label _revolt;
	public MinigamePanel _popup;
	public double tick;
	public int i = 4;
	public int year_value = 1279;
	public string[] month_value = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
	public int day_value = 31;
	
	public override void _Ready()
	{
		_dialoguecontrol = GetTree().Root.GetNode<Label>("Node2D/DialogueBox/Panel/Label");
		_year = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Panel/Year");
		_month = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Panel2/Month");
		_day = GetTree().Root.GetNode<Label>("Node2D/Control/Time/Panel3/Day");
		_gold = GetTree().Root.GetNode<Label>("Node2D/Control/Money/PanelGold/Gold");
		_workers = GetTree().Root.GetNode<Label>("Node2D/Control/Workers/WorkerCount");
		_workerstotal = GetTree().Root.GetNode<Label>("Node2D/Control/Workers/WorkerCountTotal");
		_hungerbar = GetTree().Root.GetNode<ProgressBar>("Node2D/Control/HungerBox/ProgressBar");
		_statuebar = GetTree().Root.GetNode<ProgressBar>("Node2D/Control/StatueBox/ProgressBar");
		_hunger = GetTree().Root.GetNode<Label>("Node2D/Control/HungerBox/Hunger");
		_statue = GetTree().Root.GetNode<Label>("Node2D/Control/StatueBox/Statue");
		_buybutton = GetTree().Root.GetNode<Button>("Node2D/Control/Workers/CanvasLayer/BuyWorkers");
		_buybutton.Pressed += OnBuyWorkersPressed;
		_vup = GetTree().Root.GetNode<Button>("Node2D/Control/Village/CanvasLayer/Up");
		_vup.ButtonDown += OnVUPHeld;
		_vup.ButtonUp += OnVUPUp;
		_vdown = GetTree().Root.GetNode<Button>("Node2D/Control/Village/CanvasLayer/Down");	
		_vdown.ButtonDown += OnVDOWNHeld;
		_vdown.ButtonUp += OnVDOWNUp;
		_sup = GetTree().Root.GetNode<Button>("Node2D/Control/Statue/CanvasLayer/Up");
		_sup.ButtonDown += OnSUPHeld;
		_sup.ButtonUp += OnSUPUp;
		_sdown = GetTree().Root.GetNode<Button>("Node2D/Control/Statue/CanvasLayer/Down");
		_sdown.ButtonDown += OnSDOWNHeld;
		_sdown.ButtonUp += OnSDOWNUp;
		_fup = GetTree().Root.GetNode<Button>("Node2D/Control/Farm/CanvasLayer/Up");
		_fup.ButtonDown += OnFUPHeld;
		_fup.ButtonUp += OnFUPUp;
		_fdown = GetTree().Root.GetNode<Button>("Node2D/Control/Farm/CanvasLayer/Down");
		_fdown.ButtonDown += OnFDOWNHeld;
		_fdown.ButtonUp += OnFDOWNUp;
		_village = GetTree().Root.GetNode<Label>("Node2D/Control/Village/Label");
		_statuenum = GetTree().Root.GetNode<Label>("Node2D/Control/Statue/Label");
		_farm = GetTree().Root.GetNode<Label>("Node2D/Control/Farm/Label");
		_left = GetTree().Root.GetNode<Button>("Node2D/Control/Left");
		_left.Pressed += OnLeftPressed;
		_right = GetTree().Root.GetNode<Button>("Node2D/Control/Right");
		_right.Pressed += OnRightPressed;
		_villagepanel = GetTree().Root.GetNode<Panel>("Node2D/Control/Village");
		_statuepanel = GetTree().Root.GetNode<Panel>("Node2D/Control/Statue");
		_farmpanel = GetTree().Root.GetNode<Panel>("Node2D/Control/Farm");
		_pause = GetTree().Root.GetNode<Button>("Node2D/Control/Time/CanvasLayer/Pause");
		_pause.Pressed += OnPausePressed;
		_pausesprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Control/Time/CanvasLayer/Pause/Pause");
		_playsprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Control/Time/CanvasLayer/Pause/Play");
		_villagesprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Village");
		_statuesprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Statue");
		_farmsprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Farm");
		_villagelabel = GetTree().Root.GetNode<Label>("Node2D/VillageLabel");
		_statuelabel = GetTree().Root.GetNode<Label>("Node2D/StatueLabel");
		_farmlabel = GetTree().Root.GetNode<Label>("Node2D/FarmLabel");
		_price = GetTree().Root.GetNode<Label>("Node2D/Control/Workers/CanvasLayer/BuyWorkers/Label");
		_villagealert = GetTree().Root.GetNode<Sprite2D>("Node2D/Control/Village/Alert");
		_statuealert = GetTree().Root.GetNode<Sprite2D>("Node2D/Control/Statue/Alert");
		_farmalert = GetTree().Root.GetNode<Sprite2D>("Node2D/Control/Farm/Alert");
		_vrevolt = GetTree().Root.GetNode<Button>("Node2D/Control/Village/Button");
		_vrevolt.Pressed += OnVRPressed;
		_srevolt = GetTree().Root.GetNode<Button>("Node2D/Control/Statue/Button");
		_srevolt.Pressed += OnSRPressed;
		_frevolt = GetTree().Root.GetNode<Button>("Node2D/Control/Farm/Button");
		_frevolt.Pressed += OnFRPressed;
		_popup = GetTree().Root.GetNode<MinigamePanel>("Node2D/PopupPanel");
		_revoltbar = GetTree().Root.GetNode<ProgressBar>("Node2D/Control/RevoltBar");
		_revolt = GetTree().Root.GetNode<Label>("Node2D/Control/RevoltBar/Revolt");
	}
	
	public override void _Process(double delta)
	{
		if(state == 0)
		{
			SetVillage();
			if(vupheld)
			{
				if(hold_timer <= 0 && cooldown_timer <= 0)
				{
					hold_timer = 0;
					UpButtonHeld(ref traders);
					cooldown_timer = 20;
				}
				cooldown_timer--;
				if(hold_timer > 0){hold_timer--;}
			}
			if(vdownheld)
			{
				if(hold_timer <= 0 && cooldown_timer <= 0)
				{
					hold_timer = 0;
					DownButtonHeld(ref traders);
					cooldown_timer = 20;
				}
				cooldown_timer--;
				if(hold_timer > 0){hold_timer--;}
			}
		}
		else if(state == 1)
		{
			SetStatue();
			if(supheld)
			{
				if(hold_timer <= 0 && cooldown_timer <= 0)
				{
					hold_timer = 0;
					UpButtonHeld(ref builders);
					cooldown_timer = 20;
				}
				cooldown_timer--;
				if(hold_timer > 0){hold_timer--;}
			}
			if(sdownheld)
			{
				if(hold_timer <= 0 && cooldown_timer <= 0)
				{
					hold_timer = 0;
					DownButtonHeld(ref builders);
					cooldown_timer = 20;
				}
				cooldown_timer--;
				if(hold_timer > 0){hold_timer--;}
			}
		}
		else
		{
			SetFarm();
			if(fupheld)
			{
				if(hold_timer <= 0 && cooldown_timer <= 0)
				{
					hold_timer = 0;
					UpButtonHeld(ref farmers);
					cooldown_timer = 20;
				}
				cooldown_timer--;
				if(hold_timer > 0){hold_timer--;}
			}
			if(fdownheld)
			{
				if(hold_timer <= 0 && cooldown_timer <= 0)
				{
					hold_timer = 0;
					DownButtonHeld(ref farmers);
					cooldown_timer = 20;
				}
				cooldown_timer--;
				if(hold_timer > 0){hold_timer--;}
			}
		}
		if(revoltbool)
		{
			revolttick += delta;
			_revoltbar.Visible = true;
			_revoltbar.Value = (int)revolttick * 5;
			_revolt.Text = ((int)revolttick).ToString();
			if(revolttick >= 20.0)
			{
				GD.Print("cooked");
				GetTree().ChangeSceneToFile("res://Main.tscn");
			}
		}
		
		if(villagerevolt)
		{
			gold_py = 0;
			if(revolt_timer <= 0){
				KillWorkers(ref traders, 2);
				revolt_timer = 1;
			}
			revolt_timer -= delta;
			if(Global.minigame == true)
			{
				EndRevolt(0);
				Global.minigame = false;
				_popup.CloseMinigame();
			}
		}
		if(statuerevolt)
		{
			statue_py = 0;
			if(revolt_timer <= 0){
				KillWorkers(ref builders, 2);
				revolt_timer = 1;
			}
			revolt_timer -= delta;
			if(Global.minigame == true)
			{
				EndRevolt(1);
				Global.minigame = false;
				_popup.CloseMinigame();
			}
		}
		if(farmrevolt)
		{
			hunger = 100;
			if(revolt_timer <= 0){
				KillWorkers(ref farmers, 2);
				revolt_timer = 1;
			}
			revolt_timer -= delta;
			if(Global.minigame == true)
			{
				EndRevolt(2);
				Global.minigame = false;
				_popup.CloseMinigame();
			}
		}
		
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
				NewYear();
			}
		}
		if(worker_price > gold)
		{
			_price.LabelSettings.FontColor = new Color(1, 0, 0);
		}
		else
		{
			_price.LabelSettings.FontColor = new Color(0, 1, 0);
		}
		if(revolt_cooldown > 0){
			revolt_cooldown -= delta;
			if(revolt_cooldown < 0){revolt_cooldown = 0;}
		}
		if(Global.toreload == true) {
			Global.toreload = false;
			_popup.ResetMinigame();
		}
		if(sidepressed)
		{
			sidetick -= delta;
			if(sidetick <= 0.0)
			{
				sidepressed = false;
				sidetick = 0.0;
			}
		}
		if(Input.IsActionPressed("ui_left"))
		{
			if(sidepressed == false)
			{
				OnLeftPressed();
				sidetick = 0.2;
				sidepressed = true;
			}
		}
		if(Input.IsActionPressed("ui_right"))
		{
			if(sidepressed == false)
			{
				OnRightPressed();
				sidetick = 0.2;
				sidepressed = true;
			}
		}
		gold_py = traders * 10;
		statue_py = builders;
		hunger_py = total_workers - farmers * 3;
		total_workers = active_workers + passive_workers;
		_price.Text = "Buy 5: " + worker_price.ToString() + " G";
		_year.Text = year_value.ToString();
		_month.Text = month_value[i];
		_day.Text = day_value.ToString();
		_gold.Text = gold.ToString() + " G";
		_workers.Text = passive_workers.ToString();
		_workerstotal.Text = total_workers.ToString();
		_hungerbar.Value = hunger;
		_statuebar.Value = statue;
		_hunger.Text = hunger.ToString() + "%";
		_statue.Text = (statue/75).ToString() + "%";
		_village.Text = traders.ToString();
		_statuenum.Text = builders.ToString();
		_farm.Text = farmers.ToString();
		
		if(year_value == 1213 && i == 7 && day_value == 8)
		{
			GD.Print("cooked");
			GetTree().ChangeSceneToFile("res://Main.tscn");
		}
	}
	
	public void OnVRPressed()
	{
		_popup.ShowMinigame();
	}
	public void OnSRPressed()
	{
		_popup.ShowMinigame();
	}
	public void OnFRPressed()
	{
		_popup.ShowMinigame();
	}
	
	public void CalculateHappiness()
	{
		if(((double)active_workers/(double)total_workers) > (0.8))
		{
			happiness -= 5;
		}
		else
		{
			happiness += 5;
		}
		if(((double)farmers/(double)active_workers) < (0.4))
		{
			happiness -= 5;
		}
		else
		{
			happiness += 5;
		}
		if(hunger < 25)
		{
			happiness += 5;
		}
		else if(hunger >= 25 && hunger < 50)
		{
			happiness = happiness;
		}
		else if(hunger >= 50 && hunger < 75)
		{
			happiness -= 5;
		}
		else if(hunger >= 75)
		{
			happiness -= 10;
		}
		if(happiness > 100){happiness = 100;}
		if(happiness < 0){happiness = 0;}
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
		if(gold >= worker_price)
		{
			passive_workers += worker_buy_count;
			gold -= worker_price;
			worker_price += 5;
			DisplayText("BALLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLS");
		}
	}
	
	void OnVUPHeld()
	{
		if(passive_workers >= 1)
		{
			traders += 1;
			passive_workers -= 1;
			active_workers += 1;
		}
		vupheld = true;
		hold_timer = 50;
	}
	
	void OnSUPHeld()
	{
		if(passive_workers >= 1)
		{
			builders += 1;
			passive_workers -= 1;
			active_workers += 1;
		}
		supheld = true;
		hold_timer = 50;
	}
	
	void OnFUPHeld()
	{
		if(passive_workers >= 1)
		{
			farmers += 1;
			passive_workers -= 1;
			active_workers += 1;
		}
		fupheld = true;
		hold_timer = 50;
	}
	
	void OnVDOWNHeld()
	{
		if(traders >= 1)
		{
			traders -= 1;
			passive_workers += 1;
			active_workers -= 1;
		}
		vdownheld = true;
		hold_timer = 50;
	}
	
	void OnSDOWNHeld()
	{
		if(builders >= 1)
		{
			builders -= 1;
			passive_workers += 1;
			active_workers -= 1;
		}
		sdownheld = true;
		hold_timer = 50;
	}
	
	void OnFDOWNHeld()
	{
		if(farmers >= 1)
		{
			farmers -= 1;
			passive_workers += 1;
			active_workers -= 1;
		}
		fdownheld = true;
		hold_timer = 50;
	}
	
	void OnVUPUp()
	{
		vupheld = false;
	}
	
	void OnSUPUp()
	{
		supheld = false;
	}
	
	void OnFUPUp()
	{
		fupheld = false;
	}
	
	void OnVDOWNUp()
	{
		vdownheld = false;
	}
	
	void OnSDOWNUp()
	{
		sdownheld = false;
	}
	
	void OnFDOWNUp()
	{
		fdownheld = false;
	}
	
	void UpButtonHeld(ref int people)
	{
		if(passive_workers >= 1)
		{
			people += 1;
			passive_workers -= 1;
			active_workers += 1;
		}
	}
	
	void DownButtonHeld(ref int people)
	{
		if(people >= 1)
		{
			people -= 1;
			passive_workers += 1;
			active_workers -= 1;
		}
	}
	
	void OnLeftPressed()
	{
		if(state > 0)
		{
			state --;
		}
	}
	
	void OnRightPressed()
	{
		if(state < 2)
		{
			state ++;
		}
	}
	
	void OnPausePressed()
	{
		if(_pausesprite.Visible == true)
		{
			_pausesprite.Visible = false;
			_playsprite.Visible = true;
		}
		else
		{
			_pausesprite.Visible = true;
			_playsprite.Visible = false;
		}
	}
	
	void SetVillage()
	{
		_left.Visible = false;
		_farmpanel.Visible = false;
		_fup.Visible = false;
		_fdown.Visible = false;
		_statuepanel.Visible = false;
		_sup.Visible = false;
		_sdown.Visible = false;
		_statuesprite.Visible = false;
		_farmsprite.Visible = false;
		_statuelabel.Visible = false;
		_farmlabel.Visible = false;
		
		_villagelabel.Visible = true;
		_villagesprite.Visible = true;
		_villagepanel.Visible = true;
		_vup.Visible = true;
		_vdown.Visible = true;
	}
	
	void SetStatue()
	{
		_left.Visible = true;
		_right.Visible = true;
		_farmpanel.Visible = false;
		_fup.Visible = false;
		_fdown.Visible = false;
		_villagepanel.Visible = false;
		_vup.Visible = false;
		_vdown.Visible = false;
		_villagesprite.Visible = false;
		_farmsprite.Visible = false;
		_villagelabel.Visible = false;
		_farmlabel.Visible = false;
		
		_statuelabel.Visible = true;
		_statuesprite.Visible = true;
		_statuepanel.Visible = true;
		_sup.Visible = true;
		_sdown.Visible = true;
	}
	
	void SetFarm()
	{
		_right.Visible = false;
		_villagepanel.Visible = false;
		_vup.Visible = false;
		_vdown.Visible = false;
		_statuepanel.Visible = false;
		_sup.Visible = false;
		_sdown.Visible = false;
		_statuesprite.Visible = false;
		_villagesprite.Visible = false;
		_statuelabel.Visible = false;
		_villagelabel.Visible = false;

		_farmlabel.Visible = true;
		_farmsprite.Visible = true;
		_farmpanel.Visible = true;
		_fup.Visible = true;
		_fdown.Visible = true;
	}
	
	void NewYear()
	{
		if(traders == 0)
		{
			gold += 10;
		}
		if((double)builders/(double)active_workers < 0.25)
		{
			statuerevoltcount += 1;
		}
		gold += gold_py;
		statue += statue_py;
		hunger += hunger_py;
		if(statue >= 7500)
		{
			GetTree().ChangeSceneToFile("res://Main.tscn");
		}
		if(hunger > 100)
		{
			hunger = 100;
		}
		if(hunger < 0)
		{
			hunger = 0;
		}
		if(hunger >= 50)
		{
			KillAnyWorkers(2);
		}
		CalculateHappiness();
		if(happiness < 40 || statuerevoltcount >= 3)
		{
			if(revolt_cooldown <= 0 && !revoltbool)
			{
				Random random = new Random();
				int bruh = random.Next(0,3);
				if(bruh == 0){VillageRevolt();}
				else if(bruh == 1){StatueRevolt();}
				else{FarmRevolt();}
				revoltbool = true;
				if(statuerevoltcount >= 3)
				{
					statuerevoltcount = 0;
				}
			}
		}
	}
	
	void VillageRevolt()
	{
		GD.Print("Village Revolt!");
		_vrevolt.Visible = true;
		villagerevolt = true;
		gold_py_temp = gold_py;
		revolt_timer = 3;
		revolt_cooldown = 20.0;
	}
	
	void StatueRevolt()
	{
		GD.Print("Statue Revolt!");
		_srevolt.Visible = true;
		statuerevolt = true;
		statue_py_temp = statue_py;
		revolt_timer = 3;
		revolt_cooldown = 20.0;
	}
	
	void FarmRevolt()
	{
		GD.Print("Farm Revolt!");
		_frevolt.Visible = true;
		farmrevolt = true;
		gold_py_temp = gold_py;
		revolt_timer = 3;
		revolt_cooldown = 20.0;
	}
	
	void EndRevolt(int area)
	{
		GD.Print("Revolt Ended");
		_revoltbar.Visible = false;
		_revoltbar.Value = 0;
		revoltbool = false;
		revolttick = 0.0;
		_frevolt.Visible = false;
		_srevolt.Visible = false;
		_vrevolt.Visible = false;
		villagerevolt = false;
		statuerevolt = false;
		farmrevolt = false;
		Global.minigame = false;
		if(area == 0){gold_py = gold_py_temp;}
		else if(area == 1){statue_py = statue_py_temp;}
		else{hunger = hunger_temp;}
	}
	
	void KillWorkers(ref int people, int count)
	{
		if(people >= count)
		{
			people -= count;
			active_workers -= count;
		}
	}
	
	void KillAnyWorkers(int count)
	{
		Random random = new Random();
		int bruh = random.Next(0,3);
		if(bruh == 0)
		{
			KillWorkers(ref traders, count);
		}
		else if(bruh == 1)
		{
			KillWorkers(ref builders, count);
		}
		else
		{
			KillWorkers(ref farmers, count);
		}
	}
	
	public void DisplayText(string text)
{
	if (_dialoguecontrol != null)
	{
		_dialoguecontrol.Text = text;
		
	}
}

	
}
