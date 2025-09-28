using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime, drawingTimer;

    Vector3 lineDrawer, diff;

    int reached;

    private void Start()
    {
        drawingTime = 3;
        drawingTimer = Time.time + drawingTime;
        reached = 0;
        lineDrawer = starTransforms[0].position;
    }
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        diff.x = starTransforms[reached + 1].position.x - starTransforms[reached].position.x;
        diff.y = starTransforms[reached + 1].position.y - starTransforms[reached].position.y;

        lineDrawer.x = starTransforms[reached].position.x + diff.x - (diff.x * (drawingTimer - Time.time) / drawingTime);
        lineDrawer.y = starTransforms[reached].position.y + diff.y - (diff.y * (drawingTimer - Time.time) / drawingTime);

        if ((lineDrawer.x - starTransforms[reached + 1].position.x <= 0.1 ) && (lineDrawer.x - starTransforms[reached + 1].position.x >= -0.1) && (lineDrawer.y - starTransforms[reached + 1].position.y <= 0.1) && (lineDrawer.y - starTransforms[reached + 1].position.y >= -0.1))
        {
            reached++;
            drawingTimer = Time.time + drawingTime;
            if (reached > 5)
            {
                reached = 0;
            }
        }

        Debug.DrawLine(starTransforms[reached].position, lineDrawer);

        for (int i = 1; i <= reached; i++)
        {
            Debug.DrawLine(starTransforms[i-1].position, starTransforms[i].position, Color.yellow);
        }

    }
}
