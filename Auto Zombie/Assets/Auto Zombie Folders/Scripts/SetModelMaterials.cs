using UnityEngine;
using System.Collections;

public class SetModelMaterials : MonoBehaviour {

	private GameObject character;
	private GameObject car;

	// Use this for initialization
	void Start () {
		character = GameObject.FindWithTag("Player").transform.FindChild("Chasis/mrcool_sportscar_withoutwheels/polySurface306").gameObject;
		car = GameObject.FindWithTag("Player").transform.FindChild("Chasis/mrcool_sportscar_withoutwheels/polySurface310").gameObject;

		character.renderer.material = CharacterSelection.instance.characterMaterials [GameStats.AZ_selectedCharacter];
		car.renderer.material = CarSelection.instance.carMaterials [GameStats.AZ_selectedCar];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
