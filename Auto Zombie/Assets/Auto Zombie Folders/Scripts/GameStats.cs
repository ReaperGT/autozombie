﻿using UnityEngine;
using System.Collections;

public static class GameStats {

	public static int AZ_selectedCar;
	public static int AZ_selectedCharacter;
	public static bool AZ_OnVillage;

	public static float bestTime = 0f;

	public static void saveBestTime(float raceTime)
	{
		if (raceTime > bestTime)
		{
			PlayerPrefs.SetFloat("BestTime", raceTime);
		}
	}

	public static float getBestTime()
	{
		return PlayerPrefs.GetFloat("BestTime", 0f);
	}
}
