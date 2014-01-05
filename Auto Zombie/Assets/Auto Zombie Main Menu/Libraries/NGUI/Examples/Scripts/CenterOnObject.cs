using UnityEngine;
using System.Collections;

public class CenterOnObject : MonoBehaviour {

	public UIDraggablePanel dragPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() {
		Vector3 newPos = dragPanel.transform.worldToLocalMatrix.MultiplyPoint3x4(transform.position);
		SpringPanel.Begin(dragPanel.gameObject, -newPos, 8f);
			
		//Application.LoadLevel("Game");		
	}
}
