using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    Vector3 vel, pos;

    private void Start()
    {
    }

    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            vel.y += 0.05f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x -= 0.05f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel.y -= 0.05f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x += 0.05f;
        }

        pos += vel;

        transform.position = pos;

        vel = Vector3.zero;
    }

}