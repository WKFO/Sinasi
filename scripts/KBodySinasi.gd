extends KinematicBody2D
const UP = Vector2(0, -1)
const GRAVITY = 30
const SPEED = 200
const JUMP_HEIGHT = -300

var motion = Vector2()

func _physics_process(delta):

	motion.y += GRAVITY
	if Input.is_action_pressed("ui_right"):
		motion.x = SPEED
	elif Input.is_action_pressed("ui_left"):
		motion.x = -SPEED
	else:
		motion.x = 0

	if Input.is_action_pressed("ui_accept"):
		motion.y = JUMP_HEIGHT

	motion = move_and_slide(motion, UP)
