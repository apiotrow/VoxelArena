#pragma strict

	var paused : boolean = false;
	var canShift : boolean = true;
	public var FPSInputController1 : FPSInputController;
	public var MouseLook1 : MouseLook;
	public var MouseLook1_2 : MouseLook;
	public var CharacterMotor1 : CharacterMotor;
	public var FPSInputController2 : FPSInputController;
	public var MouseLook2 : MouseLook;
	public var MouseLook2_2 : MouseLook;
	public var CharacterMotor2 : CharacterMotor;


	function Start ()
	{
		
		paused = false;
		//Time.timeScale = 1;
		if(Application.loadedLevel == 2){
			FPSInputController1.enabled = true;
			MouseLook1.enabled = true;
			MouseLook1_2.enabled = true;
			CharacterMotor1.enabled = true;
			FPSInputController2.enabled = true;
			MouseLook2.enabled = true;
			MouseLook2_2.enabled = true;
			CharacterMotor2.enabled = true;
		}
	}
	
	function Update ()
	{
		if ((Input.GetButton ("Pause") || Input.GetButton ("Pause_alt")) && canShift && Application.loadedLevel == 0) {
			canShift = false;
			paused = !paused;
			if(paused){
				StartCoroutine(psWait());
				//Time.timeScale = 0;
				FPSInputController1.enabled = false;
				MouseLook1.enabled = false;
				MouseLook1_2.enabled = false;
				CharacterMotor1.enabled = false;
				FPSInputController2.enabled = false;
				MouseLook2.enabled = false;
				MouseLook2_2.enabled = false;
				CharacterMotor2.enabled = false;
			}else{
				StartCoroutine(psWait());
				//Time.timeScale = 1;
				FPSInputController1.enabled = true;
				MouseLook1.enabled = true;
				CharacterMotor1.enabled = true;
				MouseLook1_2.enabled = true;
				CharacterMotor1.enabled = true;
				FPSInputController2.enabled = true;
				MouseLook2.enabled = true;
				MouseLook2_2.enabled = true;
				CharacterMotor2.enabled = true;
			}
		}
	}
	
	function psWait(){
		yield WaitForSeconds(1f);
		canShift = true;
	}