using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text score;
    private int scoreINT;
    public TMP_Text mode;
    public PlayerBehaviour playerBehaviour;
    public MainStarted mainStarted;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScoreInc());
    }

    IEnumerator ScoreInc()
    {
        while (!playerBehaviour.isDead)
        {
            scoreINT++;
            score.text = $"{scoreINT}";
            yield return new WaitForSeconds(1f);
        }
    }

}
