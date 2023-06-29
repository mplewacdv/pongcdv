using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool isSpawnerActive = true;

    private void Update()
    {
        if (isSpawnerActive)
            return;
        StartCoroutine(SpawnAfterRandomTime());
    }

    public IEnumerator SpawnAfterRandomTime()
    {
        isSpawnerActive = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5f));
        Debug.Log("Spawn");
        isSpawnerActive = false;
    }
}
