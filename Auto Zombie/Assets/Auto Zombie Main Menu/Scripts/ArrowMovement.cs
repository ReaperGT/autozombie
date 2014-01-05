using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

	public GameObject leftArrow;
	public GameObject rightArrow;
	float tempLeftX;
	float tempRightX;
	float leftX;
	float rightX;
	bool isLeft;
	bool isRight;
	float spaceBasis = 5f;
	float speed;


	void Awake() {
		leftX = leftArrow.transform.localPosition.x;
		rightX = rightArrow.transform.localPosition.x;
		speed = 0.25f;
		tempLeftX = leftX;
		tempRightX = rightX;
	}

	void Start () {
	
	}
	
	void Update () {
		leftArrowMovement ();
		rightArrowMovement ();
	}


	void leftArrowMovement() {
		
		if (leftX == tempLeftX)
			isLeft = true;
		if (leftX == tempLeftX - spaceBasis)
			isLeft = false;

		if(isLeft)
			leftX = leftArrow.transform.localPosition.x - speed;
		else
			leftX = leftArrow.transform.localPosition.x + speed;
	
			leftArrow.transform.localPosition = new Vector3 (leftX, leftArrow.transform.position.y);
	}
	
	void rightArrowMovement() {
		if (rightX == tempRightX)
			isRight = true;
		if (rightX == tempRightX + spaceBasis)
			isRight = false;

		if(isRight)
			rightX = rightArrow.transform.localPosition.x + speed;
		else
			rightX = rightArrow.transform.localPosition.x - speed;

		rightArrow.transform.localPosition = new Vector3 (rightX, rightArrow.transform.position.y);
	}
}
