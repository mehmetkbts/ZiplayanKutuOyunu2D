using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefab;
    [SerializeField] TMP_Text scoreText;
    float initialSpeed = 10f;
    float maxSpeed = 35f;
    float speedIncreaseRate = 1f;
    float timeElapsed = 0f;

    int score = 0;
    float scroreIncreaseRate = 1f; 

    void Start()
    {
        StartCoroutine(SpawnObstacles());
        StartCoroutine(DelayedOperation());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float randomDelay = Random.Range(0.7f, 3f);
            yield return new WaitForSeconds(randomDelay);

            int i = Random.Range(0, obstaclePrefab.Length);
            Vector3 spawnPosition = transform.position;

            if (i == 1)
            {
                spawnPosition.y += 1f;
            }

            GameObject obstacle = Instantiate(obstaclePrefab[i], spawnPosition, Quaternion.identity);
            Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();

            if (obstacleScript != null)
            {
                obstacleScript.SetSpeed(initialSpeed);
            }
        }
    }

    void IncreaseSpeed()
    {
        initialSpeed += speedIncreaseRate * Time.deltaTime;

        if (initialSpeed > maxSpeed)
        {
            initialSpeed = maxSpeed;
        }

        scroreIncreaseRate = initialSpeed / 10f;
    }

    IEnumerator DelayedOperation()
    {
        while (true)
        {
            score += 1;
           // Debug.Log(score);
           scoreText.text = "Score: " + score.ToString();
            yield return new WaitForSeconds(1f / scroreIncreaseRate);
        }
    }

    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 5f)
        {
            timeElapsed = 0;
            IncreaseSpeed();
        }

    }
}
