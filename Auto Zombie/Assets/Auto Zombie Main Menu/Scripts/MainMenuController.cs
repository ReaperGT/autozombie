﻿using UnityEngine;
using System.Collections;

public enum MMSCREEN {
	MMCAR = 0,
	MMCHAR,
	MMSTART,
	MMPLAY,
}

public class MainMenuController : MonoBehaviour {

	public static MainMenuController instance; 
	public GameObject logo;

	#region Character Selection Fields
	public GameObject character;
	public GameObject characterSelection;
	public GameObject directionalLight;
	public GameObject characterSpotLight;
	#endregion

	#region Car Selection Fields
	public GameObject car;
	public GameObject carSelection;
	#endregion

	#region Button Fields
	public GameObject btnStartRacing;
	public GameObject btnSelectCar;
	public GameObject btnSelectCharacter;
	#endregion

	public GameObject loadingPanel;
	public GameObject mainMenuPanel;
	public UISlider progressLoading;

	private Vector3 characterPosition1 = new Vector3(-0.8f,1.05f,2.85f);
	private Vector3 characterPosition2 = new Vector3(-0.8f,1.23f,2.8f);
	private Vector3 characterPosition3 = new Vector3(-0.05f,1.3f,1.9f);
	private Vector3 characterPosition4 = new Vector3(-0.11f,0.86f,1.9f);
	private MMSCREEN fromScreen;

	void Awake() {
		if (instance == null)
			instance = this;
		
		loadingPanel.SetActive (false);
		iTween.MoveTo (logo, iTween.Hash("position",new Vector3(0.6f,0.7f,2.8f),"time",3f));
	}

	void Start () {
		if (instance == null)
			instance = this;	
	}
	
	public void SwitchScreens(MMSCREEN toScreen) {
		
		iTween.ScaleTo (logo, iTween.Hash("scale",new Vector3(0f,0f,0f),"time",0.2f));

		if (fromScreen == MMSCREEN.MMCHAR) {
			iTween.ScaleTo (characterSelection, iTween.Hash("scale",new Vector3(0f,0f,0f),"time",0.25f));
			StartCoroutine ("UnShowCharacter");
		} else if (fromScreen == MMSCREEN.MMCAR) {
			iTween.ScaleTo (carSelection, iTween.Hash("scale",new Vector3(0f,0f,0f),"time",0.25f));
		}

		switch (toScreen) {
			case MMSCREEN.MMCHAR:
				OnCharacterSelection ();
				break;
			case MMSCREEN.MMCAR:
				OnCarSelection ();
				break;
			case MMSCREEN.MMSTART:
				OnStartRacing ();
				break;
			case MMSCREEN.MMPLAY:
				GoToInGame ();
				break;
		}

		fromScreen = toScreen;
	}

	#region CHARACTER
	void OnCharacterSelection() {
		btnSelectCharacter.SetActive (false);
		btnSelectCar.SetActive (true);
		iTween.MoveTo (btnStartRacing, iTween.Hash("y",-417f,"time",0.25f,"islocal",true));
		iTween.ScaleTo (characterSelection, iTween.Hash("scale",new Vector3(2f,2f,2f),"time",0.25f));
		StartCoroutine ("ShowCharacter");
	}

	IEnumerator ShowCharacter() {
		directionalLight.light.intensity = 0.1f;
		characterSpotLight.SetActive (true);

		character.GetComponent<RotationMovement> ().enabled = false;

		iTween.RotateTo(character, iTween.Hash("rotation",new Vector3(0f,180f,0f),"time",0.25f));
		iTween.MoveTo (character, iTween.Hash("position",characterPosition2,"time",0.25f,"easetype",iTween.EaseType.easeInOutSine));
		yield return new WaitForSeconds(0.25f);
		iTween.MoveTo (character, iTween.Hash("position",characterPosition3,"time",0.25f,"easetype",iTween.EaseType.easeInOutSine));
		yield return new WaitForSeconds(0.25f);
		iTween.MoveTo (character, iTween.Hash("position",characterPosition4,"time",0.25f,"easetype",iTween.EaseType.easeInOutSine));
		StopCoroutine ("ShowCharacter");
	}

	IEnumerator UnShowCharacter() {
		directionalLight.light.intensity = 0.5f;
		characterSpotLight.SetActive (false);

		iTween.MoveTo (character, iTween.Hash("position",characterPosition3,"time",0.25f,"easetype",iTween.EaseType.easeInOutSine));
		yield return new WaitForSeconds(0.25f);
		iTween.MoveTo (character, iTween.Hash("position",characterPosition2,"time",0.25f,"easetype",iTween.EaseType.easeInOutSine));
		yield return new WaitForSeconds(0.25f);
		iTween.MoveTo (character, iTween.Hash("position",characterPosition1,"time",0.25f,"easetype",iTween.EaseType.easeInOutSine));

		iTween.RotateTo(character, iTween.Hash("rotation",new Vector3(0f,car.transform.localEulerAngles.y,0f),"time",0.1f,"localRotation",true)); //TODO: current rotation

		character.GetComponent<RotationMovement> ().enabled = true;
		character.GetComponent<RotationMovement> ().rotationValue = car.transform.localEulerAngles.y;
		StopCoroutine ("UnShowCharacter");
	}
	#endregion

	#region CAR
	void OnCarSelection() {
		btnSelectCharacter.SetActive (true);
		btnSelectCar.SetActive (false);
		iTween.MoveTo (btnStartRacing, iTween.Hash("y",-417f,"time",0.25f,"islocal",true));
		iTween.ScaleTo (carSelection, iTween.Hash("scale",new Vector3(2f,2f,2f),"time",0.25f));
	}
	#endregion

	#region START
	void OnStartRacing() {
		btnSelectCharacter.SetActive (true);
		btnSelectCar.SetActive (true);
		iTween.MoveTo (btnStartRacing, iTween.Hash("y",-215f,"time",0.25f,"islocal",true));
	}

	void GoToInGame() {
		StartCoroutine ("AnimateProgress");
	}

	IEnumerator AnimateProgress() {
		btnStartRacing.SetActive (false);
		mainMenuPanel.SetActive (false);
		loadingPanel.SetActive (true);

		progressLoading.sliderValue = (1f/3f);
				yield return new WaitForSeconds(3f);
		progressLoading.sliderValue = (2f/3f);
				yield return new WaitForSeconds(3f);
		progressLoading.sliderValue = 1;
				yield return new WaitForSeconds(1f);
		
		StopCoroutine ("AnimateProgress");
		Application.LoadLevel(1);
	}

	#endregion
}
