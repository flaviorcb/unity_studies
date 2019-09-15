using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0;
    const float MAX_VOLUME = 1f;

    public static void SetMasterVolume(float value)
    {
        if (value >= MIN_VOLUME && value <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static void SetDifficulty(int value)
    {
        PlayerPrefs.SetInt(DIFFICULTY_KEY, value);
    }


    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static int GetDifficulty()
    {
        if(PlayerPrefs.GetInt(DIFFICULTY_KEY)<=0){
            return 10;
        }

        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
