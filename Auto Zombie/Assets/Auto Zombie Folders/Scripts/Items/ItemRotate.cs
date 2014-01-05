using UnityEngine;
using System.Collections;

public class ItemRotate : MonoBehaviour {

	public float rotationValue = 180;
	
	void Update () {
		transform.localRotation = Quaternion.Euler(0f, rotationValue, 0f); 
		rotationValue -= 0.25f; 
	}
}
