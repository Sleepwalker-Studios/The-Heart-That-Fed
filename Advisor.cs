using Godot;
using System;

public partial class Advisor : Control
{
	public string[] meeting1 = new string[6]{"My pharaoh…", "To thy legacy I am bound.", "Thou may have heard — one of our most devout religious sects hath taken to fasting by day.",
											"I propose we bid our laborers follow this example.", "To forgo their meals would lessen their food consumption by 40%, at no cost to thee.",
											"What sayest thou, my lord?"};
	public string[] y1 = new string[1]{"Thy word is done."};
	public string[] n1 = new string[3]{"How unlike thee.", "Thou shalt ne’er finish thy statue by fretting for thy people.", "Still, thy word is done."};
	public string[] meeting2 = new string[6]{"My pharaoh…", "To thy legacy I am bound.", "Our labor groweth dear, and our kingdom wider by the hour.", 
											"Yet I’ve spoken with one who offereth an… alternative means of securing new workers.", "Thou needst not trouble thyself with the details. It shall cut a new worker’s cost by 25%, for no ill consequence.",
											"What say thee, lord?"};
	public string[] y2 = new string[1]{"Thy word is done."};
	public string[] n2 = new string[2]{"Thou shalt rue this choice.", "Yet thy word is done."};
	public string[] meeting3 = new string[6]{"My pharaoh…", "To thy legacy I am bound.", "Thy people bow in full obedience. Thy name stands among history’s greatest kings.",
											"Yet thou art still beholden to the fickle, daily concerns of thy subjects.", "Give me the order, and I shall make revolts an impossibility. Thou may direct them at thy will.",
											"What say thee, lord?"};
	public string[] y3 = new string[2]{"Thy word is done.", "Lead us into Egypt’s golden age."};
	public string[] n3 = new string[2]{"Thou hast been too gentle with thy subjects.", "Thy legacy shall reckon the cost."};
	public int i;
	public bool ans;
	public int ansnum;
	public Button _o1;
	public Button _o2;
	public Label _dialogue;
	public override void _Ready()
	{
		_o1 = GetTree().Root.GetNode<Button>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel/Option1");
		_o1.Pressed += OnO1Pressed;
		_o2 = GetTree().Root.GetNode<Button>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel/Option2");
		_o2.Pressed += OnO2Pressed;
		_dialogue = GetTree().Root.GetNode<Label>("Node2D/AdvisorPanel/CanvasLayer/Control/Panel2/Label");
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
				if(i > 4)
				{
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
