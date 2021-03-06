﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //------------------ VARIABLES --------------------

    private Vector3 centerPosition;
    private float rotateX, rotateY, theta, posX, posY;
    private GameObject previousPoint;

    public int serie;
    public float radius;
    public LineRenderer radiusLine, circleOutline;
    public GameObject center, point;

    private SeriesController controller;
    private Wave wave;

    //------------------ PRIVATE METHODS --------------------

    private void Awake()
    {
        controller = FindObjectOfType<SeriesController>();
    }

    private void Start()
    {
        centerPosition = center.transform.position;
        transform.position = new Vector3(centerPosition.x + radius, centerPosition.y);
        
        if(controller.counter > 0)
            SetPointInController();

        theta = 0;

        serie = controller.nMultiplier;
    }

    private void FixedUpdate()
    {
        if (!controller.run)
            return;

        centerPosition = center.transform.position;

        if(PlayerPrefs.GetInt("wave") == 1) //Square Wave
            SquareCircle();
        else //Saw Tooth wave
            SawToothCircle();

        theta += 0.01f;

        transform.position = new Vector3(centerPosition.x + rotateX, centerPosition.y + rotateY);

        UpdateCoordinates();

        if (PlayerPrefs.GetInt("wave") == 1) //Square Wave
            DrawSquareCircle();
        else //Saw Tooth wave
           DrawSawToothCircle();
    }

    private void SetPointInController()
    {
        controller.points[controller.counter] = this.gameObject;
    }

    private void SquareCircle()
    {
        rotateX = radius * (4 / (Mathf.PI * serie)) * Mathf.Cos(theta * serie);
        rotateY = radius * (4 / (Mathf.PI * serie)) * Mathf.Sin(theta * serie);
    }

    private void DrawSquareCircle()
    {
        float x, y;
        float resolution = 0.01f, theta = 0f;
        int Size = (int)((1f / resolution) + 1f);

        circleOutline.positionCount = Size;

        for (int i = 0; i < Size; i++)
        {
            theta += (2.0f * Mathf.PI * resolution);
            x = radius * (4 / (Mathf.PI * serie)) * Mathf.Cos(theta);
            y = radius * (4 / (Mathf.PI * serie)) * Mathf.Sin(theta);
            circleOutline.SetPosition(i, new Vector3(x + posX, y + posY, 0));
        }

        DrawRadius();
    }

    private void SawToothCircle()
    {
        int negative = (serie%2 == 0) ? (1) : (-1);
        rotateX = 2.5f * radius * (2 / (Mathf.PI * serie * negative)) * Mathf.Cos(theta * serie);
        rotateY = 2.5f * radius * (2 / (Mathf.PI * serie * negative)) * Mathf.Sin(theta * serie);
    }

    private void DrawSawToothCircle()
    {
        float x, y;
        float resolution = 0.01f, theta = 0f;
        int Size = (int)((1f / resolution) + 1f);

        circleOutline.positionCount = Size;

        for (int i = 0; i < Size; i++)
        {
            theta += (2.0f * Mathf.PI * resolution);
            x = 2.5f * radius * (2 / (Mathf.PI * serie)) * Mathf.Cos(theta * serie);
            y = 2.5f * radius * (2 / (Mathf.PI * serie)) * Mathf.Sin(theta * serie);
            circleOutline.SetPosition(i, new Vector3(x + posX, y + posY, 0));
        }

        DrawRadius();
    }

    private void UpdateCoordinates()
    {
        posX = centerPosition.x;
        posY = centerPosition.y;
    }

    private void DrawRadius()
    {
        radiusLine.SetPosition(0, centerPosition);
        radiusLine.SetPosition(1, transform.position);
    }
}
