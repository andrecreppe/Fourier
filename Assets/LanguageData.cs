using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageData : MonoBehaviour
{
    /* Language Number list
     * 1) English
     * 2) Portuguese
     * 3) German
     */

    //------------------ VARIABLES --------------------

    private int control;

    private readonly string langKey = "lang";
    private readonly string version = "1.1";
    private readonly string monthRelease = "06/2020";

    public readonly int languagesNumber = 2;

    public Sprite[] flags;
    public Text[] textField;

    //------------------ PRIVATE METHODS --------------------

    private void Start()
    {
        int saved = PlayerPrefs.GetInt(langKey);

        if (saved > languagesNumber || saved < 1)
        {
            if (Application.systemLanguage == SystemLanguage.Portuguese)
            {
                PlayerPrefs.SetInt(langKey, 2);
            }
            else if (Application.systemLanguage == SystemLanguage.German)
            {
                PlayerPrefs.SetInt(langKey, 3);
            }
            else
            {
                PlayerPrefs.SetInt(langKey, 1); //Default = english
            }

            PlayerPrefs.Save();
        }
        else
        {
            control = saved;
        }

        control--;
        UpdateLanguage();
    }

    private void UpdateAboutText()
    {
        if (control == 1) //English
        {
            textField[0].text = "about the app";
            textField[1].text = "This app is menant to" +
                "\nshow off the amazing" +
                "\nproprierties of the" +
                "\nfourier tools" +
                "\n\n- version: " + version +
                "\n" + monthRelease;

            textField[2].text = "the developer";
            textField[3].text = "André z. creppe" +
                "\n(all rights reserved)";

            textField[4].text = "contact";

            textField[5].text = "Language:" +
                "\nEnglish";
        }
        else if (control == 2) //Portuguese
        {
            textField[0].text = "sobre este app";
            textField[1].text = "esse aplicativo tem como" +
                "\nfinalidade demonstrar" +
                "\nas incriveis propriedades" +
                "\ndas ferramentas de fourier" +
                "\n\n- versão: " + version +
                "\n" + monthRelease;

            textField[2].text = "desenvolvedor";
            textField[3].text = "andré z. creppe" +
                "\n(direitos reservados)";

            textField[4].text = "contato";

            textField[5].text = "idioma:" +
                "\nPortuguês";
        }
        //        else if(control == 3) //German
        //        {
        //            textField[0].text = "";
        //            textField[1].text = "";
        //
        //            textField[2].text = "";
        //            textField[3].text = "";
        //
        //            textField[4].text = "";
        //
        //            textField[5].text = "";
        //        }
    }

    private void UpdateMenuText()
    {
        if(control == 1)
        {
            textField[0].text = "Fourier series";
            textField[1].text = "Fourier draw";
        }
        else if(control == 2)
        {
            textField[0].text = "Série de fourier";
            textField[1].text = "Desenho de fourier";
        }
        //        else if(control == 3) //German
        //        {
        //            textField[0].text = "";
        //            textField[1].text = "";
        //        }
    }

    private void UpdateSeriesText()
    {

    }

    //------------------ PUBLIC METHODS --------------------

    public void UpdateLanguage()
    {
        control = PlayerPrefs.GetInt(langKey);

        switch (SceneManager.GetActiveScene().name)
        {
            case "About":
                UpdateAboutText();
                break;
            case "Menu":
                UpdateMenuText();
                break;
            case "Series":
                UpdateSeriesText();
                break;
        }
    }
}
