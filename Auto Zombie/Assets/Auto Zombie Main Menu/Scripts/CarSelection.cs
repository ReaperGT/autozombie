using UnityEngine;
using System.Collections;
using System;

public enum CAR {
	BLACK = 0,
	RED,
	BLUE,
	GRAY,
}

public class CarSelection : MonoBehaviour {

	public static CarSelection instance; 
	public GameObject car;
	public Material[] carMaterials = new Material[4];
	[HideInInspector] public CAR selectedCar;

	void Awake() {
		if (instance == null)
			instance = this;
	}

	void Start () {
		if (instance == null)
			instance = this;
	}

	void Update () {
	
	}

	public void SelectCar(string selected) {

		int index = 0;
		foreach(CAR keyName in  Enum.GetValues(typeof(CAR))) {
			if (selected.Equals (keyName.ToString ())) {
				car.renderer.material = carMaterials [index];
				selectedCar = keyName;
				GameStats.AZ_selectedCar = (int) selectedCar;
			}

		 	index++;
		}
	}
}
