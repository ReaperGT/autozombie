using UnityEngine;
using System.Collections;

public class HumanCarAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			animation.CrossFade("turning R");
			//Invoke("ResumeMovingAnimation", animation["turning R"].length);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			animation.CrossFade("turning L");
			//Invoke("ResumeMovingAnimation", animation["turning L"].length);
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			ResumeMovingAnimation();
		}
	}

	void ResumeMovingAnimation()
	{
		animation.CrossFade("moving");
	}
}
