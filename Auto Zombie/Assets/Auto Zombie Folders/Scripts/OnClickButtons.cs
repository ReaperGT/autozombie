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

		if (gameObject.name.Contains ("btnNextMap")) {
				if (!GameStats.AZ_OnVillage)
						GameStats.AZ_OnVillage = true;
				Application.LoadLevel (2);
		}
	}

	void PauseButtons() {
		if (gameObject.name.Contains ("btnPause")) {
			OnPause ();
			SoundManager.instance.PlayClickButtonSoundEffect();
		}
		if (gameObject.name.Contains ("btnRetry")) {
			Application.LoadLevel (1);
			SoundManager.instance.PlayClickButtonSoundEffect();
		}
		if (gameObject.name.Contains ("btnQuit") || gameObject.name.Contains("btnHome")) {
			Application.LoadLevel (0);
			SoundManager.instance.PlayClickButtonSoundEffect();
		}
		if (gameObject.name.Contains ("btnPlay")) {
			OnUnPause ();
			SoundManager.instance.PlayClickButtonSoundEffect();
		}
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
