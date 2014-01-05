using UnityEngine;
using System.Collections;

public class ItemBounce : MonoBehaviour {
	public float distanceY, speed, delay;
	
	private float startingYpos, maxYpos;
	private bool isGoingUp = true, okToMove = true;
	
	// Use this for initialization
	void Start () {
		startingYpos = transform.position.y;
		maxYpos = startingYpos + distanceY;
	}
	
	// Update is called once per frame
	void Update () {
		if (okToMove)
			StartMoveUpDown ();
	}
	
	void StartMoveUpDown () {
		if (isGoingUp) {
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
			
			if (transform.position.y > maxYpos) {
				isGoingUp = false;
			}
		} else {
			transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
			
			if (transform.position.y < startingYpos) {
				isGoingUp = true;
				okToMove = false;
				Invoke ("RestartMoving", delay);
			}
		}
	}
	
	void RestartMoving() {
		okToMove = true;
	}

}
