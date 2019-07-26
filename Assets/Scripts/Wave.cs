using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float destroyTime = 7f;
    private Vector3 position, initial;

    public LineRenderer conection;
    public GameObject dot, end;

    private Controller controller;

    //---------------------------------------------

    private void Start()
    {
        controller = FindObjectOfType<Controller>();

        initial = transform.position;
    }

    private void Update()
    {
        if (!controller.run)
            return;

        position = end.transform.position;

        transform.position = new Vector3(initial.x, position.y, 0);

        DrawLine();

        SpawnWave();
    }

    //---------------------------------------------

    private void DrawLine()
    {
        conection.SetPosition(0, position);
        conection.SetPosition(1, transform.position);
    }

    private void SpawnWave()
    {
        GameObject point = Instantiate(dot, transform.position, Quaternion.identity);
        point.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);

        Object.Destroy(point, destroyTime);
    }

    private void DrawWave()
    {
        //more efficient wave
    }

    //---------------------------------------------

    public void SetNewEnd(GameObject newEnd)
    {
        end = newEnd;
    }

    public GameObject GetEndObject()
    {
        return end;
    }
}
