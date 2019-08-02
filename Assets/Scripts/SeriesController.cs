using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeriesController : MonoBehaviour
{
    private readonly int limit = 99; //total--
    
    public int nMultiplier, counter;
    public bool run;
    public GameObject[] points;

    public GameObject circlePrefab, startPoint;
    public Text counterText, runText;

    //---------------------------------------------

    private void Start()
    {
        counter = 0;

        points = new GameObject[limit];
        points[counter] = startPoint;

        counterText.text = "Total = " + (counter + 1);

        run = false;
    }

    //---------------------------------------------

    public void NewCircle()
    {
        if(counter < limit)
        {
            nMultiplier += 2;

            GameObject circle = Instantiate(circlePrefab, points[counter].transform.position, Quaternion.identity);
            circle.transform.parent = points[counter].transform;

            counter++;
            counterText.text = "Total = " + (counter + 0);
        }
    }

    public void DeleteCircle()
    {
        Debug.Log("Delete");
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
            SceneManager.LoadScene("Series");
        }
    }
}
