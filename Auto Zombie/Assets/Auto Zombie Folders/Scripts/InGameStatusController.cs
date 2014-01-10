using UnityEngine;
using System.Collections;

public class InGameStatusController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {

		if (gameObject.name.Contains ("Finish")) {
			
			if (collider.tag.Contains ("AI")) {
				PopupView.instance.OnLose ();
				SoundManager.instance.PlayLoseResultSoundEffect();
			}
			else if(collider.tag.Contains("Car")) {
				PopupView.instance.OnWin ();
				SoundManager.instance.PlayWinResultSoundEffect();
			}
		} else {
			if (collider.tag.Contains ("AI")) {
				PopupView.instance.OnInfect ();
			}
		}
	}
}
