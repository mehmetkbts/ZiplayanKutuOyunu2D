using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Obstacle : MonoBehaviour
{
    float speed  = 10f;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }



    void Update()
    {
        Debug.Log(speed);
        transform.Translate(Vector3.left * Time.deltaTime * speed);

    }
}
