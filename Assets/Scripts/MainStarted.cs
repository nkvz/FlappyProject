using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainStarted : MonoBehaviour
{
    public TMP_Text conversionDataText;
    public ControlAppsFlyerUI controlUI;

    public string mode = "Easy";
    public TMP_Text textStartMode;

    public bool sounds;

    private void Update()
    {
        conversionDataText = controlUI.conversionDataText;
        textStartMode.text = $"Start: {mode}";
    }

    public void TogleSounds()
    {
        sounds = !sounds;
    }

    public void setEasy()
    {
        mode = "Easy";
    }
    public void setNormal()
    {
        mode = "Normal";
    }
    public void setHard()
    {
        mode = "Hard";
    }
}
