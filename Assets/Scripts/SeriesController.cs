using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeriesController : MonoBehaviour
{
    //------------------ VARIABLES --------------------

    private readonly int limit = 49;
    private int activeWavePattern;

    public int nMultiplier, counter;
    public bool run;
    public GameObject[] points;

    public GameObject circlePrefab, startPoint, buttons, slider;
    public Text counterText, runText;
    public Slider speedScale;

    private Wave wave;
    private MenuController menuController;

    //------------------ PRIVATE METHODS --------------------

    private void Awake()
    {
        wave = FindObjectOfType<Wave>();
        menuController = FindObjectOfType<MenuController>();
    }

    private void Start()
    {
        counter = 0;
        counterText.text = "ITERATIONS = " + (counter + 1);

        points = new GameObject[limit];
        points[counter] = startPoint;

        if (!PlayerPrefs.HasKey("wave"))
            activeWavePattern = 1;
        else
            activeWavePattern = PlayerPrefs.GetInt("wave");

        run = false;
    }

    //------------------ PUBLIC METHODS --------------------

    public void NewCircle()
    {
        if(counter < limit)
        {
            if(activeWavePattern == 1)
                nMultiplier += 2; //Square wave
            else
                nMultiplier++; //Saw Tooth

            GameObject circle = Instantiate(circlePrefab, points[counter].transform.position, Quaternion.identity);
            circle.transform.parent = points[counter].transform;

            wave.SetNewEnd();

            counter++;
            counterText.text = "ITERATIONS = " + (counter + 1);
        }
    }

    public void DeleteCircle()
    {
        if(counter > 0)
        {
            GameObject.Destroy(points[counter]);
            points[counter] = null;
            counter--;

            counterText.text = "ITERATIONS = " + (counter + 1);
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
            menuController.LoadSeries();
        }
    }

    public void UpdateSpeed()
    {
        Time.timeScale = speedScale.value;
    }
}
