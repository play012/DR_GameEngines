extends Node3D

func _input(event):
	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_LEFT and event.pressed:
		var redboatScene = load("res://Prefabs/redboat.tscn")
		var redboat = redboatScene.instantiate()
		
		var mousepos = get_viewport().get_mouse_position()
		var camera = get_viewport().get_camera_3d()
		var cursorpos = camera.project_position(mousepos, 200.0)
		
		get_tree().current_scene.add_child(redboat)
		redboat.position = cursorpos
		redboat.position.y = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	var mousepos = get_viewport().get_mouse_position()
	var camera = get_viewport().get_camera_3d()
	var cursorpos = camera.project_position(mousepos, 200.0)
	global_position = cursorpos
	global_position.y = 0
	pass
