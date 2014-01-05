using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum CHAR {
	UNCLE = 0,
	COOL,
	MARIE,
	BIG,
}

public class CharacterSelection : MonoBehaviour {

	public static CharacterSelection instance;

	public GameObject character;
	public Material[] characterMaterials = new Material[4];
	[HideInInspector] public CHAR selectedCharacter;

	void Awake() {
		if (instance == null)
			instance = this;
	}

	void Start() {
		if (instance == null)
			instance = this;
	}

	public void SelectCharacter(string selected) {
		int index = 0;
		foreach(CHAR keyName in  Enum.GetValues(typeof(CHAR))) {
			if (selected.Equals (keyName.ToString ())) {
				character.renderer.material = characterMaterials [index];
				selectedCharacter = keyName;
			}
			
			index++;
		}
	}


}
