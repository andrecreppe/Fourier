using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadSeries()
    {
        SceneManager.LoadScene("Series");
    }

    public void LoadDrawing()
    {
        SceneManager.LoadScene("Drawing");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
