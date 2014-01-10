using UnityEngine;
using System.Collections;

public class OnClickSelection : MonoBehaviour {

	int touch;
	float touchTimestamp;

	void OnClick() {
		string[] name = gameObject.name.Split ('-');

		if (gameObject.tag.Contains ("Character"))
			CharacterSelection.instance.SelectCharacter (name [1]);
		else if (gameObject.tag.Contains ("Car"))
			CarSelection.instance.SelectCar (name [1]);
		else if (gameObject.name.Contains ("SelectCharacter")) 
			MainMenuController.instance.SwitchScreens (MMSCREEN.MMCHAR);
		else if (gameObject.name.Contains ("SelectCar")) 
			MainMenuController.instance.SwitchScreens (MMSCREEN.MMCAR);
		else if (gameObject.name.Contains ("StartRacing"))
			MainMenuController.instance.SwitchScreens (MMSCREEN.MMPLAY);

		if (Time.time > touchTimestamp + 0.5f)
			touch = 0;

		touchTimestamp = Time.time;

		touch++;
		if (touch == 2)
		{
			onDoubleClick();
			touch =0;
		}

		if(gameObject.tag.Contains("btnStage"))
			StageSelectionOnClick ();
	}

	void onDoubleClick() {
		MainMenuController.instance.SwitchScreens (MMSCREEN.MMSTART);
	}

	
		private GameObject[] btnStages;
		void StageSelectionOnClick() {
			btnStages = GameObject.FindGameObjectsWithTag ("btnStage");

			foreach (GameObject go in btnStages) {
				go.transform.FindChild ("BackgroundGlow").gameObject.SetActive (false);
			}

			gameObject.transform.FindChild ("BackgroundGlow").gameObject.SetActive (true);

		}
}
