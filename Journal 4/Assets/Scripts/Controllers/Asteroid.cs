using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject bat;
    public GameObject ship;
    public GameObject shipSprite, explosionSprite;
    public Vector3 vel, lastBatPos;
    float timer;
    void Start()
    {
        vel = Vector3.zero;
        timer = 0;
    }

    void Update()
    {
        if ((transform.position - ship.transform.position).magnitude < 0.4)
        {
            shipSprite.SetActive(false);
            explosionSprite.SetActive(true);
            bat.SetActive(false);
            Destroy(ship.GetComponent<Player>());
        }

        Vector3 temp = transform.position + vel;
        transform.position = temp;

        vel *= 0.95f;

        if (Time.time > timer)
        {
            lastBatPos = bat.transform.position;
            timer = Time.time + 0.1f;
        }

        if (Mathf.Abs(transform.position.x) > 10.75f)
        {
            vel.x *= -1;
        }
        if (Mathf.Abs(transform.position.y) > 5f)
        {
            vel.y *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>())
        {
        }
        vel = (bat.transform.position - lastBatPos).normalized/5;
    }
}
