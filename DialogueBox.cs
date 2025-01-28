// DialogueBox.cs
using Godot;
using System;

public partial class DialogueBox : Control
{
	private Label _textLabel;
	private Timer _typeTimer;
	private string _currentText = "";
	private int _currentIndex = 0;
	
	public override void _Ready()
	{
		_textLabel = GetNode<Label>("Panel/Label");
		_typeTimer = GetNode<Timer>("TypeTimer");
		Hide();
	}
	
	public void ShowDialog(string text)
	{
		_currentText = text;
		_currentIndex = 0;
		_textLabel.Text = "";
		Show();
		_typeTimer.Start();
	}
	
	public void HideDialog()
	{
		Hide();
		_typeTimer.Stop();
	}
	
	private void OnTypeTimerTimeout()
	{
		if(_currentIndex < _currentText.Length)
		{
			_textLabel.Text += _currentText[_currentIndex];
			_currentIndex++;
		}
		else
		{
			_typeTimer.Stop();
		}
	}
}
