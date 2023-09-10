using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [Header("Enemy Stuff")]

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int numberOfEnemies = 100;

    private float elapsedTime = 0f;

    [Space]

    [SerializeField] private boolVariable gameIsPaused;


    [SerializeField] private intVariable enemyCount;


    private void Awake()
    {
        enemyCount.Value = 0;
    }


    private void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            CreateEnemy(10f, 20f);


        }

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.5f)
        {

            if (gameIsPaused.Value == false)
            {
                while (enemyCount.Value < numberOfEnemies + 50)
                {
                    CreateEnemy(25f, 30f);

                }
            }
            elapsedTime = 0f;
        }
    }


    void CreateEnemy(float min, float max)
    {

        float maxDistanceFromPlayer = min;
        float minDistanceFromPlayer = max;

        float xOffset = Random.Range(maxDistanceFromPlayer, minDistanceFromPlayer) * Mathf.Sign(Random.Range(-1f, 1f));
        float zOffset = Random.Range(maxDistanceFromPlayer, minDistanceFromPlayer) * Mathf.Sign(Random.Range(-1f, 1f));

        GameObject enemy = Instantiate(enemyPrefab, playerTransform.position + new Vector3(playerTransform.position.x + xOffset, 20f, playerTransform.position.z + zOffset), Quaternion.identity);

        enemyCount.Value++;
    }

}