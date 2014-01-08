using UnityEngine;
using System.Collections;
using System;

public class SoundManager : MonoBehaviour {
	
	public static SoundManager instance;
	public AudioClip mainMenuSound;
	public AudioClip inGameSound;

	private AudioSource audioSource;

	void Awake() {
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		if(audioSource == null) {
			gameObject.AddComponent<AudioListener>();
			audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.loop = true;
		}
		DontDestroyOnLoad(gameObject);

		if (instance == null)
			instance = this;
	}

	public void PlayMainMenuBGM() {
		audioSource.clip = mainMenuSound;
		audioSource.Play();
	}

	public void PlayInGameBGM() {
		audioSource.clip = inGameSound;
		audioSource.Play();
	}

	public void StopSound() {
		audioSource.Stop();
	}

	public void PauseSound() {
		AudioListener.pause = true;
	}

	public void ResumeSound() {
		AudioListener.pause = false;
	}

}
