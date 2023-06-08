using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public MainStarted mainStarted;
    private const string SoundKey = "Sound";
    private const string DifficultyKey = "Difficulty";

    public static bool SoundEnabled { get; private set; }
    public static int DifficultyLevel { get; private set; }

    private void Awake()
    {
        LoadSettings();
    }
    private void SaveSettings()
    {
        PlayerPrefs.SetInt(SoundKey, SoundEnabled ? 1 : 0);
        PlayerPrefs.SetInt(DifficultyKey, DifficultyLevel);
        PlayerPrefs.Save();
    }
    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey(SoundKey))
        {
            int soundValue = PlayerPrefs.GetInt(SoundKey);
            SoundEnabled = soundValue == 1;
        }
        else
        {
            SoundEnabled = true; // значение по умолчанию
        }

        if (PlayerPrefs.HasKey(DifficultyKey))
        {
            DifficultyLevel = PlayerPrefs.GetInt(DifficultyKey);
        }
        else
        {
            DifficultyLevel = 1; // значение по умолчанию
        }

        Debug.Log($"SoundKey = {SoundEnabled}, DifficultyLevel = {DifficultyLevel}");

        mainStarted.sounds = SoundEnabled;
        mainStarted.soundEnabled.isOn = SoundEnabled;

        switch (DifficultyLevel)
        {
            case 1:
                mainStarted.setEasy();
                break;
            case 2:
                mainStarted.setNormal();
                break;
            case 3:
                mainStarted.setHard();
                break;
        }
            

    }

    public void ToggleSound()
    {
        SoundEnabled = !SoundEnabled;
        SaveSettings();
    }

    public void ChangeDifficulty(int level)
    {
        DifficultyLevel = level;
        SaveSettings();
    }
}
