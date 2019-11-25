using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //------------------ PUBLIC METHODS --------------------

    public void LoadSeries()
    {
        SceneManager.LoadScene("Series");
    }

    public void LoadSeriesConfigs()
    {
        SceneManager.LoadScene("SeriesConfigs");
    }

    public void LoadDrawing()
    {
        SceneManager.LoadScene("Drawing");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadAbout()
    {
        SceneManager.LoadScene("About");
    }
}
