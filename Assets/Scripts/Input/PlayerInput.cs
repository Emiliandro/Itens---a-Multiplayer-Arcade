using UnityEngine;
using System.Collections;

public class PlayerInput {
	
	private int index; // controller index..
	
	InputType inputType; 
	
	Hashtable controllerButtonsMap;
	
	private float axisX = 0f;
	private float axisY = 0f;
	
	private bool[] wasAxisDirty;
	
	private bool enabled = false;
	
	public void Init(int idx, Hashtable controllerMap) {
		
		index = idx;
		
		wasAxisDirty = new bool[4];
		
		controllerButtonsMap = controllerMap;
		
		if (controllerButtonsMap == null) {
			inputType = InputType.Keyboard;
		} else {
			inputType = InputType.joystick;
		}
		
		Reset ();
	}
	
	void Reset() {
		
		axisX = 0f;
		axisY = 0f;
	}

	public bool isEnabled() {
		return enabled;
	}

	public void Enable() {
		enabled = true;
	}
	
	public void Disable() {
		enabled = false;
	}
	
	public void SetInputType (InputType input) {
		inputType = input;
	}
	
	/*-------------------- Get Input Values -------------------*/

	public float GetAxisX() {

		if (inputType == InputType.joystick) {
			return GetAxisJoystickX();
		} else {
			return Input.GetAxis("Horizontal");
		}
	}

	public float GetAxisY() {

		if (inputType == InputType.joystick) {
			return GetAxisJoystickY();
		} else {
			return Input.GetAxis("Vertical");
		}
	}

	public float GetRotationAxis() {
		return Input.GetAxis("Rotation" + index);
	}

	public bool GetButtonStatus (ButtonActions buttonId) {

		if (inputType == InputType.joystick) {
			return GetButtonStatusJoystick (buttonId);
		} else {
			return GetButtonStatusKeyboard (buttonId);
		}
	}
	
	public  bool GetButtonStatusJoystick (ButtonActions buttonId) {
		
		switch(buttonId) {
			
		case ButtonActions.Start:
			return GetKeyPressed("Start");
		case ButtonActions.Select:
			return GetKeyPressed("Select");
		case ButtonActions.UseItem:
			return GetKeyPressed("UseItem");
		case ButtonActions.Punch:
			return GetKeyPressed("Punch");
		case ButtonActions.Fire:
			return GetKeyPressed("Fire");
		case ButtonActions.Run:
			return GetKeyPressed("Run");
		case ButtonActions.Crouch:
			return GetKeyPressed("Crouch");
		case ButtonActions.Lock:
			return GetKeyPressed("Lock");
		case ButtonActions.MoveLeft:
			return GetKeyPressed("MoveLeft");
		case ButtonActions.MoveRight:
			return GetKeyPressed("MoveRight");
		}

		return false;
	}
	
	public  bool GetButtonDownStatusJoystick (ButtonActions buttonId) {
		
		switch(buttonId) {
			
		case ButtonActions.Start:
			return GetKeyDownPressed("Start");
		case ButtonActions.Select:
			return GetKeyDownPressed("Select");
		case ButtonActions.UseItem:
			return GetKeyDownPressed("UseItem");
		case ButtonActions.Punch:
			return GetKeyDownPressed("Punch");
		case ButtonActions.Fire:
			return GetKeyDownPressed("Fire");
		case ButtonActions.Run:
			return GetKeyDownPressed("Run");
		case ButtonActions.Crouch:
			return GetKeyDownPressed("Crouch");
		case ButtonActions.Lock:
			return GetKeyDownPressed("Lock");
		case ButtonActions.MoveLeft:
			return GetKeyDownPressed("MoveLeft");
		case ButtonActions.MoveRight:
			return GetKeyDownPressed("MoveRight");
		}

		return false;
	}
	
	private bool GetButtonStatusKeyboard (ButtonActions buttonId) {
		
		switch(buttonId) {
			
		case ButtonActions.Start:
			return Input.GetKeyDown (KeyCode.S);
		case ButtonActions.Select:
			return false;
		case ButtonActions.UseItem:
			return Input.GetKeyDown (KeyCode.C);
		case ButtonActions.Punch:
			return Input.GetKeyDown (KeyCode.P);
		case ButtonActions.Fire:
			return Input.GetKey (KeyCode.X);
		case ButtonActions.Run:
			return Input.GetKey (KeyCode.R);
		case ButtonActions.Crouch:
			return Input.GetKey (KeyCode.Z);
		case ButtonActions.Lock:
			return Input.GetKey (KeyCode.V);
		}
		
		return false;
		
	}
	
	public float GetAxisJoystickX () {
		return Input.GetAxis("JoystickH" + index);
	}
	
	public float GetAxisJoystickY () {
		return Input.GetAxis("JoystickV" + index);
	}
	
	private bool checkAxisOrientation (bool orientation, int dirtyFlagIndex) {
		
		if (orientation) {
			if (!wasAxisDirty[dirtyFlagIndex]) {
				wasAxisDirty[dirtyFlagIndex] = true;
				return true;
			}
			return false;
		}
		
		wasAxisDirty[dirtyFlagIndex] = false;
		return false;
		
	}
	
	public bool IsAxisToLeft() {
		return checkAxisOrientation((GetAxisX() < 0), 0);
	}
	
	public bool IsAxisToRight() {
		return checkAxisOrientation((GetAxisX() > 0), 1);		
	}
	
	public bool IsAxisToUp() {
		return checkAxisOrientation((GetAxisY() > 0), 2);		
	}
	
	public bool IsAxisToDown() {
		return checkAxisOrientation((GetAxisY() < 0), 3);		
	}
	
	string GetButtonName (string buttonIdx) {
		return "joystick " + index + " button " + buttonIdx;
	}
	
	bool GetKeyPressed (string keyAction) {
		return Input.GetKey (GetButtonName ((string)controllerButtonsMap[keyAction]));
	}
	
	bool GetKeyDownPressed (string keyAction) {
		return Input.GetKeyDown (GetButtonName ((string)controllerButtonsMap[keyAction]));
	}
}
