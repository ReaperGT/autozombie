using UnityEngine;
using System.Collections;

public class OnClickButtons : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	
	}

	void OnClick() {
		PauseButtons ();

		if(gameObject.name.Contains("btnNitro"))
			PopupView.instance.OnUseNitro ();
	}

	void PauseButtons() {
		if (gameObject.name.Contains ("btnPause"))
			OnPause ();
		if (gameObject.name.Contains ("btnRetry"))
			Application.LoadLevel (1);
		if (gameObject.name.Contains ("btnQuit"))
			Application.LoadLevel (0);
		if (gameObject.name.Contains ("btnPlay"))
			OnUnPause ();
	}

	void OnPause() {
		Time.timeScale = 0;
		PopupView.instance.pausePanel.SetActive (true);
	}

	void OnUnPause() {
		Time.timeScale = 1;
		PopupView.instance.pausePanel.SetActive (false);
	} 
}
