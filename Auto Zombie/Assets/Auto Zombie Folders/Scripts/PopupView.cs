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
				infectTimer.gameObject.SetActive (false);
				OnInfected ();
			}

			if (isInfectAnimate) {
				StartCoroutine ("ShowInfection");
			}
		}
		#endregion
	}

	#region VACCINE
	public void OnVaccine() {
		StartCoroutine ("ShowVaccineAnimation");
	}

	IEnumerator ShowVaccineAnimation() {
		//TODO:change player texture
		vaccinePanel.SetActive (true);
		
		iTween.ScaleTo (vaccineCenter, iTween.Hash("scale",new Vector3(500f,500f,500f),"time",0.2f));
		yield return new WaitForSeconds (0.2f);
		iTween.ScaleTo (vaccineGlow, iTween.Hash("scale",new Vector3(1136f,640f,1f),"time",0.2f));
		yield return new WaitForSeconds (0.2f);
		iTween.ScaleTo (vaccineRight, iTween.Hash("scale",new Vector3(150,150f,150f),"time",0.2f));
		yield return new WaitForSeconds (0.2f);
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
		//TODO: change player texture
		infectBackground.SetActive (false);
		infectBackground2.SetActive (false);
		infectBackgroundEnd.SetActive (false);
		infectLabel.SetActive (false);
		iTween.ScaleTo (infectLabel, iTween.Hash("scale",new Vector3(0,0,0),"time",0.2f));

		timer = 11;
		infectTimer.gameObject.SetActive (true);
		isInfected = true;
		isInfectAnimate = true;
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
	}
	#endregion
}
