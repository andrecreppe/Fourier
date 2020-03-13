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
        control = PlayerPrefs.GetInt(langKey) - 1;

        langDataScript = LanguageData.FindObjectOfType<LanguageData>();

        maxLanguages = langDataScript.languagesNumber;
    }

    //------------------ PUBLIC METHODS --------------------

    public void UpdateLanguage()
    {
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
