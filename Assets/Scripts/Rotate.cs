using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 centerPosition;
    private float rotateX, rotateY, theta, posX, posY;

    public int serie;
    public float radius;
    public LineRenderer radiusLine, circleOutline;
    public GameObject center, point;

    private SeriesController controller;
    private Wave wave;

    //---------------------------------------------

    private void Start()
    {
        controller = FindObjectOfType<SeriesController>();
        controller.NewLastPoint(point);

        wave = FindObjectOfType<Wave>();
        wave.SetNewEnd(point);

        centerPosition = center.transform.position;
        transform.position = new Vector3(centerPosition.x + radius, centerPosition.y);

        theta = 0;

        serie = controller.count;
    }

    private void FixedUpdate()
    {
        if (!controller.run)
            return;

        centerPosition = center.transform.position;

        rotateX = radius * (4 / (Mathf.PI * serie)) * Mathf.Cos(theta * serie);
        rotateY = radius * (4 / (Mathf.PI * serie)) * Mathf.Sin(theta * serie);
        theta += 0.01f;

        transform.position = new Vector3(centerPosition.x + rotateX, centerPosition.y + rotateY);

        UpdateCoordinates();
        DrawCircle();
        DrawRadius();
    }

    //---------------------------------------------

    private void UpdateCoordinates()
    {
        posX = centerPosition.x;
        posY = centerPosition.y;
    }

    private void DrawCircle()
    {
        float resolution = 0.01f, theta = 0;
        int Size = (int)((1f / resolution) + 1f);

        circleOutline.positionCount = Size;

        for (int i = 0; i < Size; i++)
        {
            theta += (2.0f * Mathf.PI * resolution);
            float x = radius * (4 / (Mathf.PI * serie)) * Mathf.Cos(theta);
            float y = radius * (4 / (Mathf.PI * serie)) * Mathf.Sin(theta);
            circleOutline.SetPosition(i, new Vector3(x+posX, y+posY, 0));
        }
    }

    private void DrawRadius()
    {
        radiusLine.SetPosition(0, centerPosition);
        radiusLine.SetPosition(1, transform.position);
    }
}
