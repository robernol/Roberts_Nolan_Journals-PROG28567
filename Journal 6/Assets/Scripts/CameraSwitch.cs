using UnityEditor.AnimatedValues;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject player;


    void Update()
    {
            Vector3 temp = player.transform.position;
            temp.z = -10;
            transform.position = temp;
    }
}
