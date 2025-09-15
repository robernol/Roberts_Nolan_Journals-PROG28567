using UnityEngine;

public class Pipeline : MonoBehaviour
{
    Vector2 lastMousePos;
    float timer, total;
    void Start()
    {
        timer = 0;
        total = 0;
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.DrawLine(lastMousePos, (Camera.main.ScreenToWorldPoint(Input.mousePosition)));

            if (Time.time > timer)
            {
                timer = Time.time + 0.1f;
                lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {

        }
    }
}
