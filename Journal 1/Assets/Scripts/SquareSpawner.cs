using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    Vector2 mouse, a,b,c,d, draw;
    float sqsize, drawsize;
    bool hasClicked;
    void Start()
    {
        sqsize = 0.3f;
        drawsize = sqsize;
        hasClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.mouseScrollDelta.y > 0) { sqsize += 0.05f; }
        else if (Input.mouseScrollDelta.y < 0) { sqsize -= 0.05f; }

        a.x = mouse.x - sqsize;
        a.y = mouse.y - sqsize;

        b.x = a.x;
        b.y = mouse.y + sqsize;

        c.x = mouse.x + sqsize;
        c.y = b.y;

        d.x = c.x;
        d.y = a.y;

        Debug.DrawLine(a, b, Color.gray);
        Debug.DrawLine(b, c, Color.gray);
        Debug.DrawLine(c, d, Color.gray);
        Debug.DrawLine(d, a, Color.gray);

        if (Input.GetMouseButton(0))
        {
            hasClicked = true;
            draw = mouse;
            drawsize = sqsize;
        }

        if (hasClicked)
        {
            Debug.DrawLine(new Vector2(draw.x - drawsize, draw.y - drawsize), new Vector2(draw.x - drawsize, draw.y + drawsize), Color.white);
            Debug.DrawLine(new Vector2(draw.x - drawsize, draw.y + drawsize), new Vector2(draw.x + drawsize, draw.y + drawsize), Color.white);
            Debug.DrawLine(new Vector2(draw.x + drawsize, draw.y + drawsize), new Vector2(draw.x + drawsize, draw.y - drawsize), Color.white);
            Debug.DrawLine(new Vector2(draw.x + drawsize, draw.y - drawsize), new Vector2(draw.x - drawsize, draw.y - drawsize), Color.white);

        }
    }
}
