using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    Vector3 acc, vel, pos;
    public Vector2 effMaxSpeed, accTimer, deccTimer;

    float maxSpeed = 0.2f;
    float accTime = 2;
    float deccTime;

    private void Start()
    {
        acc = Vector3.zero;
        accTimer.x = Time.time;
        accTimer.y = Time.time;
        deccTime = accTime / 2;
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement() { 
        pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            acc.y += maxSpeed/50;
        }
        if (Input.GetKey(KeyCode.A))
        {
            acc.x -= maxSpeed/50;
        }
        if (Input.GetKey(KeyCode.S))
        {
            acc.y -= maxSpeed/50;
        }
        if (Input.GetKey(KeyCode.D))
        {
            acc.x += maxSpeed/50;
        }

        if (acc.x > maxSpeed)
        {
            acc.x = maxSpeed;
        }
        if (acc.x < -maxSpeed)
        {
            acc.x = -maxSpeed;
        }
        if (acc.y > maxSpeed)
        {
            acc.y = maxSpeed;
        }
        if (acc.y < -maxSpeed)
        {
            acc.y = -maxSpeed;
        }



        if (! (((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))))
        {
            accTimer.x = Time.time + accTime;
            if (Time.time >= deccTimer.x)
            {
                effMaxSpeed.x = 0;
                acc.x = 0;
            }
            else
            {
                effMaxSpeed.x = maxSpeed * ((deccTimer.x - Time.time) / deccTime);
            }
        }
        else
        {
            deccTimer.x = Time.time + deccTime;
            if (Time.time >= accTimer.x)
            {
                effMaxSpeed.x = maxSpeed;
            }
            else
            {
                effMaxSpeed.x = maxSpeed * (accTime - (accTimer.x - Time.time) / accTime);
            }
        }


        if (!(((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)))))
        {
            accTimer.y = Time.time + accTime;
            if (Time.time >= deccTimer.y)
            {
                effMaxSpeed.y = 0;
                acc.y = 0;
            }
            else
            {
                effMaxSpeed.y = maxSpeed * ((deccTimer.x - Time.time) / deccTime);
            }
        }
        else
        {
            deccTimer.y = Time.time + deccTime;
            if (Time.time >= accTimer.y)
            {
                effMaxSpeed.y = maxSpeed;
            }
            else
            {
                effMaxSpeed.y = maxSpeed * (accTime - (accTimer.y - Time.time) / accTime);
            }
        }


        vel += acc;

        if (vel.x > effMaxSpeed.x)
        {
            vel.x = effMaxSpeed.x;
        }
        if (vel.x < -effMaxSpeed.x)
        {
            vel.x = -effMaxSpeed.x;
        }
        if (vel.y > effMaxSpeed.y)
        {
            vel.y = effMaxSpeed.y;
        }
        if (vel.y < -effMaxSpeed.y)
        {
            vel.y = -effMaxSpeed.y;
        }

        pos += vel;

        transform.position = pos;

        vel = Vector3.zero;
    }

}