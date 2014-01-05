using UnityEngine;
using System.Collections;

public enum PowerUp {
	PowerUpBoost	= 0,
	PowerUpNitro	= 1,
	PowerUpVaccine 	= 2,
};

public class ItemDestroy : MonoBehaviour {
	
	public PowerUp powerUp;
	
	void OnTriggerEnter(Collider collider) {
		Debug.Log("Enter!");
		switch (powerUp) {
		case PowerUp.PowerUpBoost:
			// Add - Boost
			break;
		case PowerUp.PowerUpNitro:
			// Add - Nitro
			break;
		case PowerUp.PowerUpVaccine:
			// Add - Vaccine
			break;
		default:
			break;
		}
		
		if (collider.CompareTag("CarChasisCollider")) {
			Destroy(this.gameObject);
		}
	}
	
	void updateUIEffectOnScreen() {
		// Add Effect On Screen
	}
	
	void updateUIEffectOnCar() {
		// Add Effect On Car
		// not sure kung d2 sa script gagawin yung change when collided
	}
}
