using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CircleDraw : MonoBehaviour
{
    List<float> angles;
    int num;
    public float radius;
    void Start()
    {
        angles = new List<float>();
        for (int i = 0; i < 10; i++)
        {
            angles.Add(Random.value * 360f);
        }

        num = 0;
        radius = 1;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            num++;
            if (num >= angles.Count)
            {
                num = 0;
            }
        }

        Vector3 point = new Vector3 (Mathf.Cos(angles[num] * Mathf.Deg2Rad) * radius, Mathf.Sin(angles[num] * Mathf.Deg2Rad) * radius);

        Debug.DrawLine(Vector3.zero, point, Color.white);
        Debug.Log(angles[num]);
    }
}
