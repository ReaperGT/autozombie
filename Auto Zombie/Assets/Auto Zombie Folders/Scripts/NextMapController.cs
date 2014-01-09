using UnityEngine;
using System.Collections;

public class NextMapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("GoToMainMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator GoToMainMenu() {
		yield return new WaitForSeconds(3);
		Application.LoadLevel(0);
		StopCoroutine("GoToMainMenu");

	}
}
