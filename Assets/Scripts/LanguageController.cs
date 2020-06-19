using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
{
    //------------------ VARIABLES --------------------

    private int control, maxLanguages;

    private readonly string langKey = "lang";

    private LanguageData langDataScript;

    public Button changeButton;

    //------------------ PRIVATE METHODS --------------------

    public void Start()
    {
        control = 1;//PlayerPrefs.GetInt(langKey) - 1;

        langDataScript = FindObjectOfType<LanguageData>();

        maxLanguages = langDataScript.languagesNumber;
    }

    //------------------ PUBLIC METHODS --------------------

    public void UpdateLanguage()
    {
        return;
        control++;

        if (control > maxLanguages)
        {
            control = 1;
        }

        PlayerPrefs.SetInt(langKey, control);
        PlayerPrefs.Save();

        langDataScript.UpdateLanguage();

        Debug.Log("selected language: " + control);
    }
}
