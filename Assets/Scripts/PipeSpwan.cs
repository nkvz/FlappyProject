using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwan : MonoBehaviour
{
    [Header("Pipe inspector")]
    public GameObject pipePrefab;
    public Transform spawnPoint;
    public Transform spwanPoint2;
    public float delaySpwan = 3f;


    public void Started()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
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

}
