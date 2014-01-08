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
	
		switch (powerUp) {
			case PowerUp.PowerUpNitro:
				
				if (collider.CompareTag("CarChasisCollider")) {
					PopupView.instance.OnNitro();
					Destroy(this.gameObject);
				}
				break;
			case PowerUp.PowerUpVaccine:
				
				if (collider.CompareTag("CarChasisCollider")) {
					PopupView.instance.OnVaccine ();
					Destroy(this.gameObject);
				}
				break;
		}

	}

	void OnTriggerExit(Collider collider) {
		if (powerUp == PowerUp.PowerUpBoost &&
		    collider.CompareTag ("CarChasisCollider")) {
				PopupView.instance.OnBoostLight ();
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
