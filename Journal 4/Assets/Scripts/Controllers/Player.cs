using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public List<Vector3> radarPoints;
    public Transform enemyTransform;
    public GameObject powerupPrefab;
    public int health;

    private void Start()
    {
        health = 100;
    }

    void Update()
    {
        PlayerMovement();

        EnemyRadar(1, 3);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerups(1, 50);
        }

        Debug.Log(health);
    }

    public void EnemyRadar (float radius, int circlePoints)
    {
        float interval = (360 / circlePoints) * Mathf.Deg2Rad;
        radarPoints = new List<Vector3>();
        for (int i = 0; i < circlePoints; i++)
        {
            radarPoints.Add(transform.position + (new Vector3(Mathf.Cos(i * interval), Mathf.Sin(i * interval))*radius));
        }

        Color line = Color.green;
        if ((transform.position - enemyTransform.position).magnitude < radius + 0.5f)
        {
            line = Color.red;
        }

        for (int i = 0; i < circlePoints-1; i++)
        {
            Debug.DrawLine(radarPoints[i], radarPoints[i+1] , line);
        }
        Debug.DrawLine(radarPoints[0], radarPoints[circlePoints-1], line);
    }

    public void SpawnPowerups(float radius, int circlePoints)
    {
        float interval = (360 / circlePoints) * Mathf.Deg2Rad;

        for (int i = 0; i < circlePoints; i++) {
            Instantiate(powerupPrefab, (transform.position + (new Vector3(Mathf.Cos(i * interval), Mathf.Sin(i * interval)) * radius)), Quaternion.identity);
        }
    }

    void PlayerMovement()
    {
        Vector3 temp = transform.position;
        Vector3 vel = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            vel.y += 0.01f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel.y -= 0.01f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x -= 0.01f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x += 0.01f;
        }

        temp += vel;
        transform.position = temp;
    }
}