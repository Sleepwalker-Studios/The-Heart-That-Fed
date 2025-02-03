using Godot;
using System;

public partial class Advisor : Control
{
	public string[] meeting1 = new string[6]{"My pharaoh…", "To thy legacy I am bound.", "You may be aware — one of our most devout religious sects began daytime fasting.",
											"I propose we encourage our laborers to follow this example.", "Enforcing this would cause each farmer to feed one extra person, at no personal cost.",
											"What is your order, my lord?"};
	public string[] y1 = new string[1]{"Your word is done."};
	public string[] n1 = new string[3]{"How unlike you.", "You will never finish your statue by worrying over your people.", "Still, your word is done."};
	public string[] meeting2 = new string[7]{"My pharaoh…", "To thy legacy I am bound.", "Our labor grows dear, and our kingdom wider by the hour.", 
											"Recently, I’ve spoken with a man who offers us an… alternative means of securing new workers.", "You need not trouble yourself with the details.", "Taking the offer will cut a new worker’s cost by 25%, for no ill consequence to you.",
											"What is your order, my lord?"};
	public string[] y2 = new string[1]{"Your word is done."};
	public string[] n2 = new string[2]{"You will rue this choice.", "Still, your word is done."};
	public string[] meeting3 = new string[6]{"My pharaoh…", "To thy legacy I am bound.", "Your subjects bow in full obedience. Your name is planted among history’s greatest kings.",
											"Yet you are still beholden to the fickle, daily concerns of your people.", "Give me the order, and I will make revolts an impossibility. You may direct them at your will.",
											"What say you, lord?"};
	public string[] y3 = new string[2]{"Your word is done.", "Lead us into Egypt’s golden age."};
	public string[] n3 = new string[2]{"You have been too gentle with your subjects.", "Your legacy will reckon the cost."};
	public int i;
	public bool ans;
	public int ansnum;
	public Button _o1;
	public Button _o2;
	public Label _dialogue;
	public Sprite2D _second;
	public override void _Ready()
	{
		_o1 = GetTree().Root.GetNode<Button>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel/Option1");
		_o1.Pressed += OnO1Pressed;
		_o2 = GetTree().Root.GetNode<Button>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel/Option2");
		_o2.Pressed += OnO2Pressed;
		_dialogue = GetTree().Root.GetNode<Label>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel2/Label");
		_second = GetTree().Root.GetNode<Sprite2D>("Node2D/AdvisorPanel/CanvasLayer/Sprite2D2");
		_second.Visible = false;
	}
	
	public override void _Process(double delta)
	{
		if(Global.meetnum == 1){
			if(!ans)
			{
				_dialogue.Text = meeting1[i];
				if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
				{
					Global.starttyping = true;
					i++;
				}
				if(i > 4)
				{
					_second.Visible = true;
					_o1.Visible = true;
					_o2.Visible = true;
				}
			}
			else
			{
				if(ansnum == 0)
				{
					_dialogue.Text = n1[i];
					if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
					{
						Global.starttyping = true;
						i++;
					}
					if(i > 2)
					{
						Global.meet1check = true;
					}
				}
				else if(ansnum == 1)
				{
					Global.meet1 = true;
					_dialogue.Text = y1[i];
					if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
					{
						Global.starttyping = true;
						i++;
					}
					if(i > 0)
					{
						Global.meet1check = true;
					}
				}
			}
		}
		
		if(Global.meetnum == 2){
			if(!ans)
			{
				_dialogue.Text = meeting2[i];
				if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
				{
					Global.starttyping = true;
					i++;
				}
				if(i > 5)
				{
					_second.Visible = true;
					_o1.Visible = true;
					_o2.Visible = true;
				}
			}
			else
			{
				if(ansnum == 0)
				{
					_dialogue.Text = n2[i];
					if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
					{
						Global.starttyping = true;
						i++;
					}
					if(i > 1)
					{
						Global.meet2check = true;
					}
				}
				else if(ansnum == 1)
				{
					Global.meet2 = true;
					_dialogue.Text = y2[i];
					if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
					{
						Global.starttyping = true;
						i++;
					}
					if(i > 0)
					{
						Global.meet2check = true;
					}
				}
			}
		}
		
		if(Global.meetnum == 3){
			if(!ans)
			{
				_dialogue.Text = meeting3[i];
				if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
				{
					Global.starttyping = true;
					i++;
				}
				if(i > 4)
				{
					_second.Visible = true;
					_o1.Visible = true;
					_o2.Visible = true;
				}
			}
			else
			{
				if(ansnum == 0)
				{
					_dialogue.Text = n3[i];
					if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
					{
						Global.starttyping = true;
						i++;
					}
					if(i > 1)
					{
						Global.meet3check = true;
					}
				}
				else if(ansnum == 1)
				{
					Global.meet3 = true;
					_dialogue.Text = y3[i];
					if(Input.IsActionPressed("ui_next") && Global.typing == false && Global.starttyping == false)
					{
						Global.starttyping = true;
						i++;
					}
					if(i > 1)
					{
						Global.meet3check = true;
					}
				}
			}
		}
	}
	
	public void OnO1Pressed()
	{
		i = 0;
		ansnum = 1;
		ans = true;
		_o1.Visible = false;
		_o2.Visible = false;
	}
	public void OnO2Pressed()
	{
		i = 0;
		ansnum = 0;
		ans = true;
		_o1.Visible = false;
		_o2.Visible = false;
	}
}
