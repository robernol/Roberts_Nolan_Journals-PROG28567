using System.Drawing;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Transform ship;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint( Input.mousePosition ); 
        mouse.z = 0;
        transform.position = ship.position;

        float rotAngle = Mathf.Atan2(mouse.y - ship.position.y, mouse.x - ship.position.x);
        transform.eulerAngles = new Vector3( 0, 0, (rotAngle * Mathf.Rad2Deg) -90 );
    }
}
