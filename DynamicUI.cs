using Godot;
using System;

public partial class DynamicUI : Control
{
	public int wartime;
	public bool war;
	public int faminetick;
	public bool faminetime;
	public bool m2;
	public bool tutorial = true;
	public bool tradeboost;
	public bool famine;
	public bool go;
	public double dialoguetimer;
	public bool dialogue;
	public double verttick;
	public bool vertpressed;
	public double sidetick;
	public bool sidepressed;
	public int statuerevoltcount;
	public bool revoltbool = false;
	public double revolttick;
	public bool villagerevolt;
	public bool statuerevolt;
	public bool farmrevolt;
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
	public int worker_buy_count = 50;
	public int worker_price = 1000;
	public int state = 1;
	public int statue_py_temp;
	public int hunger_temp;
	public int gold_py_temp;
	public int hunger;
	public int happiness = 100;
	public int total_workers = 30;
	public int passive_workers;
	public int active_workers = 30;
	public int farmers = 10;
	public int traders = 10;
	public int builders = 10;
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
	public Sprite2D _statuesprite2;
	public Sprite2D _statuesprite3;
	public Sprite2D _statuesprite4;
	public Sprite2D _statuesprite5;
	public Sprite2D _farmsprite;
	public Sprite2D _villagealert;
	public Sprite2D _statuealert;
	public Sprite2D _farmalert;
	public Sprite2D _pharaoh2;
	public Sprite2D _pharaoh3;
	public Sprite2D _pharaoh4;
	public Sprite2D _deal1;
	public Sprite2D _deal2;
	public Sprite2D _deal3;
	public Sprite2D _war;
	public Sprite2D _famine;
	public Label _villagelabel;
	public Label _statuelabel;
	public Label _farmlabel;
	public Label _price;
	public Label _revolt;
	public Label _dialogue;
	public Panel _tutorial;
	public Button _1;
	public Button _2;
	public Button _3;
	public Button _4;
	public Button _5;
	public Button _6;
	public AudioStreamPlayer _music;
	public ColorRect _crui;
	public MinigamePanel _popup;
	public AdvisorPanel _advisor;
	public MilitaryPanel _military;
	public double tick;
	public float fadecolor;
	public int i = 0;
	public int year_value = 1279;
	public string[] month_value = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
	public int day_value = 1;
	
	public override void _Ready()
	{
		_dialogue = GetTree().Root.GetNode<Label>("Node2D/Control/Dialogue");
		_year = GetTree().Root.GetNode<Label>("Node2D/Control/Panel/Year");
		_month = GetTree().Root.GetNode<Label>("Node2D/Control/Panel2/Month");
		_day = GetTree().Root.GetNode<Label>("Node2D/Control/Panel3/Day");
		_gold = GetTree().Root.GetNode<Label>("Node2D/Control/Gold");
		_workers = GetTree().Root.GetNode<Label>("Node2D/Control/WorkerCount");
		_workerstotal = GetTree().Root.GetNode<Label>("Node2D/Control/WorkerCountTotal");
		_hungerbar = GetTree().Root.GetNode<ProgressBar>("Node2D/Control/ProgressBar");
		_statuebar = GetTree().Root.GetNode<ProgressBar>("Node2D/Control/ProgressBar2");
		_hunger = GetTree().Root.GetNode<Label>("Node2D/Control/Hunger");
		_statue = GetTree().Root.GetNode<Label>("Node2D/Control/Statue2");
		_buybutton = GetTree().Root.GetNode<Button>("Node2D/Control/CanvasLayer2/BuyWorkers");
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
		_pause = GetTree().Root.GetNode<Button>("Node2D/Control/CanvasLayer/Pause");
		_pausesprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Control/CanvasLayer/Pause/Pause");
		_playsprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Control/CanvasLayer/Pause/Play");
		_villagesprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Village");
		_statuesprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Statue");
		_statuesprite2 = GetTree().Root.GetNode<Sprite2D>("Node2D/Statue2");
		_statuesprite3 = GetTree().Root.GetNode<Sprite2D>("Node2D/Statue3");
		_statuesprite4 = GetTree().Root.GetNode<Sprite2D>("Node2D/Statue4");
		_statuesprite5 = GetTree().Root.GetNode<Sprite2D>("Node2D/Statue5");
		_farmsprite = GetTree().Root.GetNode<Sprite2D>("Node2D/Farm");
		_villagelabel = GetTree().Root.GetNode<Label>("Node2D/VillageLabel");
		_statuelabel = GetTree().Root.GetNode<Label>("Node2D/StatueLabel");
		_farmlabel = GetTree().Root.GetNode<Label>("Node2D/FarmLabel");
		_price = GetTree().Root.GetNode<Label>("Node2D/Control/CanvasLayer2/BuyWorkers/Label");
		_vrevolt = GetTree().Root.GetNode<Button>("Node2D/Control/Village/Button");
		_vrevolt.Pressed += OnVRPressed;
		_srevolt = GetTree().Root.GetNode<Button>("Node2D/Control/Statue/Button");
		_srevolt.Pressed += OnSRPressed;
		_frevolt = GetTree().Root.GetNode<Button>("Node2D/Control/Farm/Button");
		_frevolt.Pressed += OnFRPressed;
		_popup = GetTree().Root.GetNode<MinigamePanel>("Node2D/PopupPanel");
		_advisor = GetTree().Root.GetNode<AdvisorPanel>("Node2D/AdvisorPanel");
		_military = GetTree().Root.GetNode<MilitaryPanel>("Node2D/MilitaryPanel");
		_tutorial = GetTree().Root.GetNode<Panel>("Node2D/Tutorial");
		_1 = GetTree().Root.GetNode<Button>("Node2D/Tutorial/Panel/Statue/CanvasLayer/Up");
		_2 = GetTree().Root.GetNode<Button>("Node2D/Tutorial/Panel/Statue/CanvasLayer/Down");
		_3 = GetTree().Root.GetNode<Button>("Node2D/Tutorial/Panel2/Statue/CanvasLayer/Up");
		_4 = GetTree().Root.GetNode<Button>("Node2D/Tutorial/Panel2/Statue/CanvasLayer/Down");
		_5 = GetTree().Root.GetNode<Button>("Node2D/Tutorial/Panel3/Statue/CanvasLayer/Up");
		_6 = GetTree().Root.GetNode<Button>("Node2D/Tutorial/Panel3/Statue/CanvasLayer/Down");
		_music = GetTree().Root.GetNode<AudioStreamPlayer>("Node2D/Control/AudioStreamPlayer");
		_crui = GetTree().Root.GetNode<ColorRect>("Node2D/ColorRect");
		_pharaoh2 = GetTree().Root.GetNode<Sprite2D>("Node2D/PharaohHead2");
		_pharaoh3 = GetTree().Root.GetNode<Sprite2D>("Node2D/PharaohHead3");
		_pharaoh4 = GetTree().Root.GetNode<Sprite2D>("Node2D/PharaohHead4");
		_deal1 = GetTree().Root.GetNode<Sprite2D>("Node2D/Deal1");
		_deal2 = GetTree().Root.GetNode<Sprite2D>("Node2D/Deal2");
		_deal3 = GetTree().Root.GetNode<Sprite2D>("Node2D/Deal3");
		_war = GetTree().Root.GetNode<Sprite2D>("Node2D/War");
		_famine = GetTree().Root.GetNode<Sprite2D>("Node2D/Famine");
		_pause = GetTree().Root.GetNode<Button>("Node2D/Control/CanvasLayer/Pause");
		_pause.Pressed += OnPausePressed;
	}
	
	public override void _Process(double delta)
	{
		if(Global.resume)
		{
			_music.StreamPaused = false;
			Global.resume = false;
		}
		if(Global.meet2 && !m2)
		{
			m2 = true;
			GD.Print("yikes!");
			worker_price -= 500;
			Global.meet2 = false;
		}
		if(Global.meet1 && Global.meet1check)
		{
			_deal1.Visible = true;
		}
		if(Global.meet2 && Global.meet2check)
		{
			_deal2.Visible = true;
		}
		if(Global.meet3 && Global.meet3check)
		{
			_deal3.Visible = true;
		}
		if(!tutorial)
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
						cooldown_timer = 10;
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
						cooldown_timer = 10;
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
						cooldown_timer = 10;
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
						cooldown_timer = 10;
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
						cooldown_timer = 10;
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
						cooldown_timer = 10;
					}
					cooldown_timer--;
					if(hold_timer > 0){hold_timer--;}
				}
			}
		}
		if(revoltbool)
		{
			//nothing?
		}
		
		if(villagerevolt)
		{
			gold_py = 0;
			if(revolt_timer <= 0){
				KillWorkers(ref traders, 20);
				revolt_timer = 1;
			}
			revolt_timer -= delta;
			if(Global.minigame == true)
			{
				EndRevolt(0);
				Global.minigame = false;
				_popup.CloseMinigame();
				DisplayDialogue("Revolt Ended");
				KillWorkers(ref traders, 5);
			}
		}
		if(statuerevolt)
		{
			statue_py = 0;
			if(revolt_timer <= 0){
				KillWorkers(ref builders, 20);
				revolt_timer = 1;
			}
			revolt_timer -= delta;
			if(Global.minigame == true)
			{
				EndRevolt(1);
				Global.minigame = false;
				_popup.CloseMinigame();
				DisplayDialogue("Revolt Ended");
				KillWorkers(ref builders, 5);
			}
		}
		if(farmrevolt)
		{
			hunger = 100;
			if(revolt_timer <= 0){
				KillWorkers(ref farmers, 20);
				revolt_timer = 1;
			}
			revolt_timer -= delta;
			if(Global.minigame == true)
			{
				EndRevolt(2);
				Global.minigame = false;
				_popup.CloseMinigame();
				DisplayDialogue("Revolt Ended");
				KillWorkers(ref farmers, 5);
			}
		}
		if(go)
		{
			tick += delta;
		}
		if(go && Global.music)
		{
			_music.Playing = true;
			Global.music = false;
		}
		if(tick >= 0.0301)
		{
			day_value++;
			tick = 0;
			if(year_value == 1214)
			{
				fadecolor += 0.002739726027397f;
			}
		}
		if(day_value > Month_Length(i))
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
		if(worker_price > Global.gold)
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
		if(Input.IsActionPressed("ui_up"))
		{
			if(vertpressed == false)
			{
				if(state == 0)
				{
					vupheld = true;
				}
				else if(state == 1)
				{
					supheld = true;
				}
				else
				{
					fupheld = true;
				}
				verttick = 0.2;
				vertpressed = true;
			}
		}
		if(Input.IsActionPressed("ui_down"))
		{
			if(vertpressed == false)
			{
				if(state == 0)
				{
					vdownheld = true;
				}
				else if(state == 1)
				{
					sdownheld = true;
				}
				else
				{
					fdownheld = true;
				}
				verttick = 0.2;
				vertpressed = true;
			}
		}
		if(dialogue)
		{
			dialoguetimer -= delta;
			if(dialoguetimer <= 0)
			{
				dialoguetimer = 0;
				dialogue = false;
				_dialogue.Visible = false;
			}
		}
		if(tradeboost)
		{
			gold_py = traders * 13;
		}
		else{gold_py = traders * 10;}
		statue_py = (builders/10);
		if(Global.meet1){
			hunger_py = (total_workers - farmers * 4);
		}
		else if(!Global.meet1 && !famine){hunger_py = total_workers - farmers * 3;}
		else if(!Global.meet1 && famine){hunger_py = total_workers - farmers * 2;}
		total_workers = active_workers + passive_workers;
		_price.Text = "Buy 50: " + worker_price.ToString() + " G";
		_year.Text = year_value.ToString();
		_month.Text = month_value[i];
		_day.Text = day_value.ToString();
		_gold.Text = Global.gold.ToString() + " G";
		_workers.Text = passive_workers.ToString();
		_workerstotal.Text = total_workers.ToString();
		_hungerbar.Value = (hunger/10);
		_statuebar.Value = statue;
		_hunger.Text = (hunger/10).ToString() + "%";
		_statue.Text = (statue/75).ToString() + "%";
		_village.Text = traders.ToString();
		_statuenum.Text = builders.ToString();
		_farm.Text = farmers.ToString();
		
		if(year_value == 1214)
		{
			_crui.Color = new Color(0,0,0,fadecolor);
		}
		if(year_value == 1213 && i == 0 && day_value == 1)
		{
			GD.Print("cooked");
			GetTree().ChangeSceneToFile("res://Lose.tscn");
			if(Global.meet1)
			{
				Global.starved += ((Global.killed * 3)/10);
			}
			if(Global.meet3)
			{
				Global.starved += ((Global.killed * 5)/10);
			}
		}
		if(i == 6 && day_value == 3 && !faminetime && !famine && !statuerevolt && !villagerevolt && !farmrevolt && year_value < 1277)
		{
			Random random = new Random();
			int pluh = random.Next(0,14);
			if(pluh == 0)
			{
				DisplayDialogue("The harvest withered; a famine draws nigh...");
				faminetime = true;
			}
		}
		if(i == 6 && day_value == 2 && faminetime)
		{
			faminetime = false;
			faminetick = 0;
			famine = true;
			_famine.Visible = true;
			DisplayDialogue("A famine has begun.");
		}
		if(i == 6 && day_value == 3 && famine && faminetick >= 3)
		{
			famine = false;
			_famine.Visible = false;
			DisplayDialogue("Your fields are renewed, and hunger is no more.");
		}
		if(year_value == 1238i == 4 && day_value == 29)
		{
			_military.ShowMilitary();
			_music.StreamPaused = true;
			_war.Visible = true;
			wartime = 0;
		}
		if(year_value == 1235 && i == 2 && day_value == 25)
		{
			_war.Visible = false;
			Random random = new Random();
			int real = random.Next(0,2);
			if(real == 0){
				DisplayDialogue("Victory, like the sun's tender rays, rests upon your brow.");
				tradeboost = true;
				Global.gold += ((Global.invest * 3)/2);
			}
			if(real == 1)
			{
				DisplayDialogue("Defeat in battle brings dishonor to your kingdom.");
			}
		}
		if(statue >= 7500)
		{
			GetTree().ChangeSceneToFile("res://Glory.tscn");
			if(Global.meet1)
			{
				Global.starved += ((Global.killed * 3)/10);
			}
			if(Global.meet3)
			{
				Global.starved += ((Global.killed * 5)/10);
			}
		}
		if(year_value == 1251 && i == 4 && day_value == 24)
		{
			tradeboost = false;
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
	
	//public override void _Input(InputEvent @event)
	//{
		//if (@event.IsActionPressed("ui_pause"))
		//{
			//if(_pausesprite.Visible == true)
			//{
				//_pausesprite.Visible = false;
				//_playsprite.Visible = true;
			//}
			//else
			//{
				//_pausesprite.Visible = true;
				//_playsprite.Visible = false;
			//}
		//}
	//}
	
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
		else if(hunger >= 250 && hunger < 500)
		{
			happiness = happiness;
		}
		else if(hunger >= 500 && hunger < 750)
		{
			happiness -= 5;
		}
		else if(hunger >= 750)
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
		tutorial = false;
		_1.Visible = false;
		_2.Visible = false;
		_3.Visible = false;
		_4.Visible = false;
		_5.Visible = false;
		_6.Visible = false;
		_tutorial.Visible = false;
		go = true;
		if(Global.gold >= worker_price)
		{
			passive_workers += worker_buy_count;
			Global.gold -= worker_price;
			worker_price += 50;
			Global.exploit += 50;
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
		if(passive_workers >= 10)
		{
			people += 10;
			passive_workers -= 10;
			active_workers += 10;
		}
		else{
			people += passive_workers;
			active_workers += passive_workers;
			passive_workers = 0;
		}
	}
	
	void DownButtonHeld(ref int people)
	{
		if(people >= 10)
		{
			people -= 10;
			passive_workers += 10;
			active_workers -= 10;
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
		if(statue < 1500)
		{
			_statuesprite.Visible = true;
		}
		else if(statue >= 1500 && statue < 3000)
		{
			_statuesprite2.Visible = true;
		}
		else if(statue >= 3000 && statue < 4500)
		{
			_statuesprite3.Visible = true;
		}
		else if(statue >= 4500 && statue < 6000)
		{
			_statuesprite4.Visible = true;
		}
		else if(statue >= 6000)
		{
			_statuesprite2.Visible = true;
		}
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
		if(year_value == 1278)
		{
			StatueRevolt();
		}
		if(year_value == 1254)
		{
			_pharaoh2.Visible = true;
		}
		if(year_value == 1234)
		{
			_pharaoh3.Visible = true;
		}
		if(year_value == 1219)
		{
			_pharaoh4.Visible = true;
		}
		faminetick++;
		wartime++;
		if(year_value == 1266)
		{
			_advisor.ShowAdvisor();
			_music.StreamPaused = true;
		}
		if(year_value == 1244)
		{
			_advisor.ShowAdvisor();
			_music.StreamPaused = true;
		}
		if(year_value == 1222)
		{
			_advisor.ShowAdvisor();
			_music.StreamPaused = true;
		}
		GD.Print("bomba");
		if((double)builders/(double)active_workers < 0.25)
		{
			statuerevoltcount += 1;
		}
		Global.gold += gold_py;
		statue += statue_py;
		hunger += hunger_py;
		if(hunger > 1000)
		{
			hunger = 1000;
		}
		if(hunger < 0)
		{
			hunger = 0;
		}
		if(hunger >= 500)
		{
			KillAnyWorkers(20);
		}
		CalculateHappiness();
		if(happiness < 40 || statuerevoltcount >= 3 && year_value != 1267 && year_value != 1266 && year_value != 1245 && year_value != 1244 && year_value != 1223 && year_value != 1222)
		{
			statuerevoltcount = 3;
			if(revolt_cooldown <= 0 && !revoltbool && !Global.meet3)
			{
				Random random = new Random();
				int bruh = random.Next(0,3);
				revoltbool = true;
				revolt_cooldown = 25.0;
				if(bruh == 0){VillageRevolt();}
				else if(bruh == 1){StatueRevolt();}
				else{FarmRevolt();}
				if(statuerevoltcount >= 3)
				{
					statuerevoltcount = 0;
				}
			}
		}
	}
	
	void VillageRevolt()
	{
		DisplayDialogue("Village Revolt!");
		_vrevolt.Visible = true;
		villagerevolt = true;
		gold_py_temp = gold_py;
		revolt_timer = 3;
	}
	
	void StatueRevolt()
	{
		DisplayDialogue("Statue Revolt!");
		_srevolt.Visible = true;
		statuerevolt = true;
		statue_py_temp = statue_py;
		revolt_timer = 3;
	}
	
	void FarmRevolt()
	{
		DisplayDialogue("Farm Revolt!");
		_frevolt.Visible = true;
		farmrevolt = true;
		gold_py_temp = gold_py;
		revolt_timer = 3;
	}
	
	void EndRevolt(int area)
	{
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
		_dialogue.Visible = false;
	}
	
	void KillWorkers(ref int people, int count)
	{
		if(people >= count)
		{
			people -= count;
			active_workers -= count;
			DisplayDialogue(count + " workers died");
			Global.killed += count;
		}
	}
	
	void KillAnyWorkers(int count)
	{
		if(traders == 0 && builders == 0 && farmers == 0){return;}
		Random random = new Random();
		int bruh = random.Next(0,3);
		if(bruh == 0)
		{
			if(traders >= count){
				KillWorkers(ref traders, count);
				DisplayDialogue(count + " traders died");
				Global.killed += count;
			}
			else if(traders == 0){KillAnyWorkers(count);}
			else{KillWorkers(ref traders, traders);}
		}
		else if(bruh == 1)
		{
			if(builders >= count){
				KillWorkers(ref builders, count);
				DisplayDialogue(count + " builders died");
				Global.killed += count;
			}
			else if(builders == 0){KillAnyWorkers(count);}
			else{KillWorkers(ref builders, builders);}
		}
		else
		{
			if(farmers >= count){
				KillWorkers(ref farmers, count);
				DisplayDialogue(count + " farmers died");
				Global.killed += count;
			}
			else if(farmers == 0){KillAnyWorkers(count);}
			else{KillWorkers(ref farmers, farmers);}
		}
	}
	
	public void DisplayDialogue(string text)
	{
		_dialogue.Visible = true;
		_dialogue.Text = text;
		dialoguetimer = 5.0;
		dialogue = true;
	}

	
}
