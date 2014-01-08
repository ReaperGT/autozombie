using UnityEngine;
using System.Collections;

public class PopupView : MonoBehaviour {

	public static PopupView instance;
	public GameObject pausePanel;

	#region Vaccine Fields
	public GameObject vaccinePanel;
	public GameObject vaccineGlow;
	public GameObject vaccineCenter;
	public GameObject vaccineRight;
	public GameObject vaccineLeft;
	#endregion

	#region Infect Fields
	public GameObject infectBackground;
	public GameObject infectBackground2;
	public GameObject infectBackgroundEnd;
	public GameObject infectLabel;
	public UILabel infectTimer;
	private float timer;
	private bool isInfected;
	private bool isInfectAnimate;
	#endregion

	#region Nitro Fields
	public UISlicedSprite btnNitroBG;
	public GameObject btnNitroGlow;
	private bool isOnNitro;
	private bool isFilledNitro;
	#endregion

	public GameObject losePanel;
	public GameObject winPanel;
	public GameObject mainButtonsPanel;
	public GameObject popupButtonsPanel;

	void Awake() {
		if (instance == null)
			instance = this;
	}

	void Start () {
		if (instance == null)
			instance = this;
	}
	

	void Update () {
		#region INFECT
		if (isInfected) {
			if ((int)timer > 0) {
				timer -= Time.deltaTime;
				infectTimer.text = "Infection: " + ((int)timer).ToString ();
			} else if ((int)timer <= 0) {
				StopCoroutine ("ShowInfection");
				isInfectAnimate = false;
				infectTimer.gameObject.SetActive (false);
				OnInfected ();
			}

			if (isInfectAnimate) {
				StartCoroutine ("ShowInfection");
			}
		}
		#endregion

		if (isOnNitro) {
			StartCoroutine ("ShowNitroGlow");
		}
	}

	#region VACCINE
	public void OnVaccine() {
		isInfected = false;
		ResetInfect ();
		StartCoroutine ("ShowVaccineAnimation");
	}

	IEnumerator ShowVaccineAnimation() {
		//TODO:change player texture
		vaccinePanel.SetActive (true);
		
				iTween.ScaleTo (vaccineCenter, iTween.Hash("scale",new Vector3(500f,500f,500f),"time",0.1f));
				yield return new WaitForSeconds (0.1f);
				iTween.ScaleTo (vaccineGlow, iTween.Hash("scale",new Vector3(1136f,640f,1f),"time",0.1f));
				yield return new WaitForSeconds (0.1f);
				iTween.ScaleTo (vaccineRight, iTween.Hash("scale",new Vector3(150,150f,150f),"time",0.1f));
				yield return new WaitForSeconds (0.1f);
		iTween.ScaleTo (vaccineLeft, iTween.Hash("scale",new Vector3(100f,100f,100f),"time",0.2f));


		yield return new WaitForSeconds (0.3f);
		StartCoroutine ("UnShowVaccineAnimation");
		StopCoroutine ("ShowVaccineAnimation");
	}

	IEnumerator UnShowVaccineAnimation() {

		iTween.ScaleTo (vaccineCenter, iTween.Hash("scale",new Vector3(0,0,0),"time",0.2f));
		iTween.ScaleTo (vaccineGlow, iTween.Hash("scale",new Vector3(0,0,0f),"time",0.2f));
		iTween.ScaleTo (vaccineRight, iTween.Hash("scale",new Vector3(0,0,0),"time",0.2f));
		iTween.ScaleTo (vaccineLeft, iTween.Hash("scale",new Vector3(0,0,0),"time",0.2f));

		yield return new WaitForSeconds (0.1f);
		vaccinePanel.SetActive (false);
		StopCoroutine ("ShowVaccineAnimation");
	}
	#endregion

	#region INFECT
	public void OnInfect() {
		if (!isInfected) {
			OnInfectLight ();
			ResetInfect ();

			timer = 11;
			infectTimer.gameObject.SetActive (true);
			isInfected = true;
			isInfectAnimate = true;
		}
	}

	IEnumerator ShowInfection() {
		isInfectAnimate = false;
		infectBackground.SetActive (true);
		infectBackground2.SetActive (false);
		yield return new WaitForSeconds (1f);
		infectBackground2.SetActive (true);
		yield return new WaitForSeconds (1f);
		isInfectAnimate = true;
	}
	
	void OnInfected() {
		infectBackground.SetActive (false);
		infectBackground2.SetActive (false);
		infectBackgroundEnd.SetActive (true);
		infectLabel.SetActive (true);

		iTween.ScaleTo (infectLabel, iTween.Hash("scale",new Vector3(650,180,0),"time",0.2f));

		Time.timeScale = 0f;

		OnShowLosePopup ();
	}

	void ResetInfect() {
		OffInfectLight ();
		popupButtonsPanel.SetActive (false);
		infectBackground.SetActive (false);
		infectBackground2.SetActive (false);
		infectBackgroundEnd.SetActive (false);
		infectLabel.SetActive (false);
		iTween.ScaleTo (infectLabel, iTween.Hash ("scale", new Vector3 (0, 0, 0), "time", 0.2f));
		infectTimer.gameObject.SetActive (false);

		isInfected = false;
		isInfectAnimate = false;
	}
	#endregion

	#region NITRO
	public void OnNitro() {
		isOnNitro = true;
		btnNitroBG.spriteName = "Auto Zombie_In Game Ui_Nitro Button_with green";
		isFilledNitro = true;
	}

	IEnumerator ShowNitroGlow() {
		isOnNitro = false;
		iTween.ScaleTo (btnNitroGlow, iTween.Hash("scale",new Vector3(230,230,0),"time",1f));
		yield return new WaitForSeconds (1f);
		iTween.ScaleTo (btnNitroGlow, iTween.Hash("scale",new Vector3(180,180,0),"time",1f));
		yield return new WaitForSeconds (0.5f);
		isOnNitro = true;
		
		StopCoroutine ("ShowNitroGlow");
	}
	
	public void OnUseNitro() {
		if (isFilledNitro) {
			OnNitroLight ();
			isOnNitro = false;
			StopCoroutine ("ShowNitroGlow");
			iTween.ScaleTo (btnNitroGlow, iTween.Hash ("scale", new Vector3 (0, 0, 0), "time", 1f));
			btnNitroBG.spriteName = "Auto Zombie_In Game Ui_Nitro Button_empty";
			isFilledNitro = false;
		}
	}
	#endregion

	#region LIGHTS
	void OnNitroLight() {
		GameObject.FindWithTag ("Player").transform.FindChild ("PowerupLights/NitroLight").gameObject.SetActive(true);
		Invoke ("OffNitroLight", 3.0f);
	}

	void OffNitroLight() {
		GameObject.FindWithTag ("Player").transform.FindChild ("PowerupLights/NitroLight").gameObject.SetActive(false);
	}

	public void OnBoostLight() {
		GameObject.FindWithTag ("Player").transform.FindChild ("PowerupLights/BoostLight").gameObject.SetActive(true);
		Invoke ("OffBoostLight", 3.0f);
	}

	void OffBoostLight() {
		GameObject.FindWithTag ("Player").transform.FindChild ("PowerupLights/BoostLight").gameObject.SetActive(false);
	}

	public void OnInfectLight() {
		GameObject.FindWithTag ("Player").transform.FindChild ("PowerupLights/InfectLight").gameObject.SetActive(true);
	}

	void OffInfectLight() {
		GameObject.FindWithTag ("Player").transform.FindChild ("PowerupLights/InfectLight").gameObject.SetActive(false);
	}
	#endregion

	public void OnLose() {
		losePanel.SetActive (true);		
		OnShowLosePopup ();
	}

	public void OnWin() {
		winPanel.SetActive (true);
	}

	public void OnShowLosePopup() {
		mainButtonsPanel.SetActive (false);
		popupButtonsPanel.SetActive (true);
		GameObject.Find ("_RaceManager").GetComponent<RaceUIMobileSample> ()._showRightWindow = false;
	}
}
