using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Vector3 diff, temp;
    public GameObject player;
    bool isMoving;
    public float maxSpeed, accTimer, deccTimer, deccTime, accTime = 1;

    private void Start()
    {
        deccTime = accTime / 2;
    }

    private void Update()
    {
        if (isMoving)
        {
            deccTimer = Time.time + deccTime;
        }
        else
        {
            accTimer = Time.time + accTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isMoving)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
        }

        EnemyMovement();
    }

    public void EnemyMovement()
    {
        diff = (player.transform.position - this.transform.position);
        diff.Normalize();

        if (isMoving)
        {
            if (Time.time < accTimer)
            {
                maxSpeed = (accTime - (accTimer - Time.time) / accTime);
            }
            else
            {
                maxSpeed = 1;
            }
        }
        else
        {
            if (Time.time < deccTimer)
            {
                maxSpeed = (deccTimer - Time.time) / deccTime;
            }
            else
            {
                maxSpeed = 0;
            }
        }

        

        diff.x /= 10;
        diff.y /= 10;

        diff.x *= maxSpeed;
        diff.y *= maxSpeed;

        temp = this.transform.position;
        temp += diff;
        transform.position = temp;
    }
}
