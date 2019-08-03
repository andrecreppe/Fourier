using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeriesController : MonoBehaviour
{
    private readonly int limit = 49;
    
    public int nMultiplier, counter, function;
    public bool run;
    public GameObject[] points;

    public GameObject circlePrefab, startPoint, buttons, slider;
    public Text counterText, runText;
    public Slider speedScale;

    private Wave wave;

    //---------------------------------------------

    private void Start()
    {
        wave = FindObjectOfType<Wave>();

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
            if(function == 1)
                nMultiplier += 2; //Square wave
            else
                nMultiplier++; //Saw Tooth

            GameObject circle = Instantiate(circlePrefab, points[counter].transform.position, Quaternion.identity);
            circle.transform.parent = points[counter].transform;

            wave.SetNewEnd();

            counter++;
            counterText.text = "Total = " + (counter + 1);
        }
    }

    public void DeleteCircle()
    {
        if(counter > 0)
        {
            GameObject.Destroy(points[counter]);
            points[counter] = null;
            counter--;

            counterText.text = "Total = " + (counter + 1);
            wave.SetNewEnd();
        }
    }

    public void SwapState()
    {
        if (!run)
        {
            run = true;

            runText.text = "STOP";

            buttons.SetActive(false);
            slider.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Series");
        }
    }

    public void UpdateSpeed()
    {
        Time.timeScale = speedScale.value;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
