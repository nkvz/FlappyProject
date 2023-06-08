using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwan : MonoBehaviour
{
    [Header("Pipe inspector")]
    public MainStarted mainStarted;
    public GameObject pipePrefab;
    public Transform spawnPoint;
    public Transform spwanPoint2;

    public Transform[] normalLVL;
    public Transform[] HardLVL;

    public float delaySpwan = 3f;
    public string dificultLVL;


    public void Started()
    {
        dificultLVL = mainStarted.mode;
        if(dificultLVL == "Easy")
        {
            StartCoroutine(SpawnEasy());
        } else if(dificultLVL == "Normal")
        {
            StartCoroutine(SpawnNormal());
        } else
        {
            StartCoroutine(SpawnHard());
        }
         
    }

    IEnumerator SpawnEasy()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaySpwan);

            GameObject newPipe = Instantiate(pipePrefab, spawnPoint.position, Quaternion.identity, transform);
            GameObject newPipe2 = Instantiate(pipePrefab, spwanPoint2.position, Quaternion.identity, transform);
            Destroy(newPipe, 10f);
            Destroy(newPipe2, 10f);
        }
    }
    IEnumerator SpawnNormal()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaySpwan);

            for (int i = 0; i < normalLVL.Length; i++)
            {
                GameObject newPipe = Instantiate(pipePrefab, normalLVL[i].position, Quaternion.identity, transform);
                Destroy(newPipe, 6f);
            }
        }
    }

    IEnumerator SpawnHard()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaySpwan);

            for (int i = 0; i < normalLVL.Length; i++)
            {
                GameObject newPipe = Instantiate(pipePrefab, normalLVL[i].position, Quaternion.identity, transform);
                Destroy(newPipe, 5f);
            }
        }
    }

}
