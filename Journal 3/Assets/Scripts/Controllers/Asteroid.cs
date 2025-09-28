using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Vector3 dir, next;
    bool arrived;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.01f;
        maxFloatDistance = 3.2f;
        arrivalDistance = 0.1f;
        arrived = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (arrived)
        {
            next = new Vector3(this.transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance), this.transform.position.y + (Random.Range(-maxFloatDistance, maxFloatDistance)));
            arrived = false;
        }

        if ( (next.x - this.transform.position.x <= arrivalDistance) && (next.y - this.transform.position.y <= arrivalDistance))
        {
            arrived = true;
        }

        dir = (next - this.transform.position).normalized;

        dir.x *= moveSpeed;
        dir.y *= moveSpeed;

        transform.position += dir;
    }
}
