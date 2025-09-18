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
            Vector2 mouseCurrentPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y);
            Debug.DrawLine(lastMousePos, mouseCurrentPos);

            if (Time.time > timer)
            {
                timer = Time.time + 0.1f;
                total += ((mouseCurrentPos - lastMousePos).magnitude);
                lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("The total length of the pipeline was " + total + " units.");
            total = 0;
            lastMousePos = Vector2.zero;
        }
    }
}
