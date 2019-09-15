using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    

public class OptionsManager : MonoBehaviour
{
    [SerializeField] float defaultSoundVolume = 0.5f;
    [SerializeField] int defaultDifficulty = 3;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    
    // Start is called before the first frame update
    void Start()
    {
        loadPrefs();
    }

    public void Defaults()
    {
        volumeSlider.value = defaultSoundVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public void loadPrefs()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.setVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found... did you start from splash screen");
        }
        
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");

    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        int difficulty = Mathf.RoundToInt(difficultySlider.value);
        Debug.Log("difficult: " + difficulty);
        PlayerPrefsController.SetDifficulty(difficulty);
        LoadStartScene();
    }


}
