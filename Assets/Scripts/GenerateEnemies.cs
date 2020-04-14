using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemy;
    public float minFrequency, maxFrequency;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(minFrequency, maxFrequency));
        Instantiate(enemy, transform.transform.position, transform.rotation);
        StartCoroutine(Start());
    }
}
