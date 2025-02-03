extends Control

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
	else:
		_is_paused = true

func _on_options_pressed() -> void:
	_is_paused = false
	get_tree().change_scene_to_file("res://OptionMenu.tscn")
