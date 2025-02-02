extends Control

@onready var _pausesprite = get_tree().root.get_node("Node2D/Control/Time/CanvasLayer/Pause/Pause")
@onready var _playsprite = get_tree().root.get_node("Node2D/Control/Time/CanvasLayer/Pause/Play")

var _is_paused:bool = false:
	set = set_paused

func _ready():
	process_mode = Node.PROCESS_MODE_ALWAYS


func set_paused(value:bool) ->void:
	_is_paused = value
	get_tree().paused = _is_paused
	if _is_paused:
		show()
	else:
		hide()

func toggle_pause() -> void:
	_is_paused = !_is_paused

func _on_resume_pressed() -> void:
	_is_paused = false

func _on_restart_pressed() -> void:
	_is_paused = false
	get_tree().change_scene_to_file("res://Main.tscn")

func _on_quit_pressed() -> void:
	get_tree().quit()

func _on_pause_pressed():
	if _is_paused:
		_is_paused = false
		_pausesprite.visible = true
		
	else:
		_is_paused = true
		_playsprite.visible = true
		
func _input(event):
	if(event.is_action_pressed("ui_pause")):
		_pausesprite.visible = false
		_playsprite.visible = false
		_on_pause_pressed()
