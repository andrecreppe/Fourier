using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeriesController : MonoBehaviour
{
    private GameObject lastPoint;

    public int count;
    public bool run;

    public GameObject circlePrefab, startPoint;
    public Text counterText, runText;

    //---------------------------------------------

    private void Start()
    {
        count = 1;

        lastPoint = startPoint;

        run = false;
    }

    //---------------------------------------------

    public void NewCircle()
    {
        count+=2;

        counterText.text = "Quantidade = " + (count + 1)/2;

        GameObject circle = Instantiate(circlePrefab, lastPoint.transform.position, Quaternion.identity);

        circle.transform.parent = lastPoint.transform;
    }

    public void NewLastPoint(GameObject point)
    {
        lastPoint = point; 
    }

    public void SwapState()
    {
        if (!run)
        {
            run = !run;

            runText.text = "STOP";
        }
        else
        {
            SceneManager.LoadScene("Seriess");
        }
    }
}
