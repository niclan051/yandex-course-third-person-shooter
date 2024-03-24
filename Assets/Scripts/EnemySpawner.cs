using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Range(1, 1000)] private uint limit;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, 1);
    }

    private void SpawnEnemy()
    {
        for (var i = 0; i <= (int)Time.timeSinceLevelLoad / 10; i++)
            if (FindObjectsOfType<EnemyMovement>().Length < limit)
                Instantiate(enemyPrefab, new Vector3((Random.value * 2 - 1) * 1.5f * 20, 2, (Random.value * 2 - 1) * 1.5f * 20), Quaternion.identity);
    }
}