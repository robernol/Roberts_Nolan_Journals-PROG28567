using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject bat;
    public GameObject ship;
    Vector3 vel;
    void Start()
    {
        vel = Vector3.zero;
    }

    void Update()
    {
        if ((transform.position - ship.transform.position).magnitude < 0.4)
        {
            Destroy(ship);

        }

        Vector3 temp = transform.position + vel;
        transform.position = temp;

        vel *= 0.9f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        vel = (bat.transform.position - ship.transform.position).normalized/10;
    }
}
