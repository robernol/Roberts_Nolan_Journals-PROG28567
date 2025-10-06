using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{

    public float angularSpeed = 30f;
    public Transform target;
    public GameObject t;

    float timer;
    bool shoot;
    public int health;
    void Start()
    {
        timer = 0;
        health = t.GetComponent<int>();
    }

    void Update()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        float upAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;
        float directionAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(upAngle, directionAngle);

        float dot = Vector3.Dot(transform.up, directionToTarget);
        float sign = Mathf.Sign(deltaAngle);

        Color detect = Color.green;
        if (dot < 0) { detect = Color.red; }

        if ((dot < 0.999f) && (detect == Color.green))
        {
            transform.Rotate(0, 0, angularSpeed * Time.deltaTime * sign);
        }
        if (dot > 0.999f)
        {
            if (Time.time > timer)
            {
                timer = Time.time + 0.08f;
                if (shoot == true) { shoot = false; }
                else { shoot = true; }
                health -= 1;
            }
            if (shoot) { Debug.DrawLine(transform.position, target.position, Color.yellow); }
        }
        
        Debug.DrawLine(transform.position, (transform.position + transform.up), detect);
        Debug.DrawLine(transform.position, transform.position + directionToTarget, Color.magenta);

    }
}
