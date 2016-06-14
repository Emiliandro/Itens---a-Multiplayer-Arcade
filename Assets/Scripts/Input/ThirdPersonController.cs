using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

	public int joystickIndex = 0; 
	public InputType inputType = InputType.joystick;

	IControllerInputListener listener;

	public float speed = 6f;
	public float turnSmoothing = 15f;

	// camera
	private Camera camera;
	private int rotationEnabled;

	// rotation
	private Vector3 moveDirection;

	Vector3 movement;
	Rigidbody playerRigidBody;

	public bool isActivated = false;

	//input object
	public PlayerInput playerInput;

	void Awake () {
		playerRigidBody = GetComponent<Rigidbody> ();
		camera = GetComponentInChildren<Camera>();
		rotationEnabled = 1;

		turnSmoothing = 200;//FIXME: Hardcoded
		moveDirection = transform.TransformDirection(Vector3.forward);

		if (inputType == InputType.Keyboard) {
			SetInputType(0);
		}
	}

	public void SetListener (IControllerInputListener listener) {
		this.listener = listener;
	}

	public void SetInputType (int playerIndex) {

		if (inputType == InputType.joystick) {
			SetJoystick(playerIndex);
		} else {
			SetKeyboard();
		}

		isActivated = true;
	}

	public void SetJoystick (int joystickIndex) {
		
		this.joystickIndex = joystickIndex;
		
		playerInput = InputController.instance.GetPlayerInput(joystickIndex);
		playerInput.Enable();
	}

	public void SetKeyboard () {

		playerInput = new PlayerInput();
		playerInput.SetInputType(InputType.Keyboard);
		playerInput.Enable();
	}

	public void EnableRotation (bool enabled) {
		rotationEnabled = enabled ? 1 : 0;
	}

	void FixedUpdate() {
		if (playerInput != null && playerInput.isEnabled()) {
			float h = playerInput.GetAxisX();
			float v = playerInput.GetAxisY();
			float r = playerInput.GetRotationAxis();

			Rotate(r, 0);
			Move (h, v);
		}
	}

	public void Move (float h, float v) {
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		movement = camera.transform.TransformDirection(movement);
		movement = new Vector3 (movement.x, 0f, movement.z);

		transform.position += movement;

		listener.OnMoviment (h, v);
	}

	public void Rotate (float h, float v) {
		Vector3 forward = camera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;

		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		// Target direction relative to the camera
		Vector3 targetDirection = h * right + v * forward;

		if (targetDirection != Vector3.zero) {
			moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, rotationEnabled * turnSmoothing * Mathf.Deg2Rad * Time.deltaTime, 1000);
			moveDirection = moveDirection.normalized;
		}

		transform.rotation = Quaternion.LookRotation(moveDirection);
	}
}