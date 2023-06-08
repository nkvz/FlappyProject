using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainStarted : MonoBehaviour
{
    public TMP_Text conversionDataText;
    public ControlAppsFlyerUI controlUI;
    public PipeSpwan pipeSpwan;
    public PlayerBehaviour playerBehaviour;
    public BackgroundParalaxx backParalax;

    public string mode = "Easy";
    public TMP_Text textStartMode;

    public bool sounds;

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

    public void Started()
    {
        this.gameObject.SetActive(false);

        pipeSpwan.Started();
        playerBehaviour.birdRigidbody.isKinematic = false;

        backParalax.inGame = true;
        playerBehaviour.inGame = true;
        playerBehaviour.birdRigidbody.velocity = Vector2.up * playerBehaviour.jumpForce;
        playerBehaviour.animator.SetTrigger("tap");

    }

    public void Restart()
    {
        //SceneManager.LoadScene("Game");
        SceneManager.LoadSceneAsync("Game");
    }
}
