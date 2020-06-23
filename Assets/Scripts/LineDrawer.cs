using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private bool firstClick;
    private GameObject line;

    public GameObject drawer;

    private void Start()
    {
        firstClick = true;
    }

    void Update()
    {
        if(!firstClick)
        {
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0))
            {
                Plane plane = new Plane(Camera.main.transform.forward * -1, line.transform.position);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                float distance;

                if (plane.Raycast(ray, out distance))
                {
                    line.transform.position = ray.GetPoint(distance);
                    line.GetComponent<TrailRenderer>().enabled = true;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                line = Instantiate(drawer, Input.mousePosition, Quaternion.identity);
                firstClick = false;
            }
        }
    }
}
