using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    float rotAngle;
    float orbitalSpeed, orbitalDistance;

    void Start()
    {
        rotAngle = Mathf.Atan2(planetTransform.position.y - transform.position.y, planetTransform.position.x - transform.position.x);
        orbitalSpeed = 0.25f;
        orbitalDistance = 4;
    }

    void Update()
    {
        OrbitalMotion(orbitalDistance, orbitalSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        Vector3 barycenter = target.position;

        Vector3 temp = (barycenter + (new Vector3(Mathf.Cos(rotAngle), Mathf.Sin(rotAngle)) * radius));
        transform.position = temp;

        rotAngle += speed * Mathf.Deg2Rad;
    }
}
