using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainStarted : MonoBehaviour
{
    public TMP_Text conversionDataText;
    public ControlAppsFlyerUI controlUI;
    public PipeSpwan pipeSpwan;
    public PlayerBehaviour playerBehaviour;
    public BackgroundParalaxx backParalax;
    public Score score;
    public GameSettings gameSettings;

    public string mode = "Easy";
    public TMP_Text textStartMode;

    public bool sounds;
    public Toggle soundEnabled;

    private void Update()
    {
        textStartMode.text = $"Start: {mode}";
        if (playerBehaviour.isDead)
        {
            backParalax.inGame = false;
        }
    }

    public void TogleSounds()
    {
        gameSettings.ToggleSound();
    }

    public void setEasy()
    {
        mode = "Easy";
        pipeSpwan.pipePrefab.GetComponent<Image>().color = Color.white;
        pipeSpwan.pipePrefab.GetComponent<PipeBehaviour>().speed = 2f;
        pipeSpwan.delaySpwan = 4f;

        gameSettings.ChangeDifficulty(1);
    }
    public void setNormal()
    {
        mode = "Normal";
        pipeSpwan.pipePrefab.GetComponent<Image>().color = Color.blue;
        pipeSpwan.pipePrefab.GetComponent<PipeBehaviour>().speed = 5f;
        pipeSpwan.delaySpwan = 2f;

        gameSettings.ChangeDifficulty(2);
    }
    public void setHard()
    {
        mode = "Hard";
        pipeSpwan.pipePrefab.GetComponent<Image>().color = Color.black;
        pipeSpwan.pipePrefab.GetComponent<PipeBehaviour>().speed = 10f;
        pipeSpwan.delaySpwan = 1f;

        gameSettings.ChangeDifficulty(3);
    }

    public void Started()
    {
        this.gameObject.SetActive(false);
        pipeSpwan.Started(); //start spawn 
        playerBehaviour.birdRigidbody.isKinematic = false; //unlock dragon
        backParalax.inGame = true; //start background
        playerBehaviour.inGame = true; // lock taps

        playerBehaviour.birdRigidbody.velocity = Vector2.up * playerBehaviour.jumpForce; //started force
        playerBehaviour.animator.SetTrigger("tap");

    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
