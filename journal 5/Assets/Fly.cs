using UnityEditor.Rendering;
using UnityEngine;

public class Fly : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += 0.1f;
        transform.position = temp;
    }
}
