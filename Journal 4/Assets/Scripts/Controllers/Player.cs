using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public List<Vector3> radarPoints;
    public Transform enemyTransform;
    public GameObject powerupPrefab;

    void Update()
    {
        PlayerMovement();

        EnemyRadar(2, 9);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerups(5, 5);
        }
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