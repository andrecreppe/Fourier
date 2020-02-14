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

    private readonly int max = 2;
    private readonly string langKey = "lang";
    private readonly string version = "1.1";

    public Sprite[] flags;
    public Button changeButton;
    public Text[] textField;

    //------------------ PRIVATE METHODS --------------------

    private void Start()
    {
        int saved = PlayerPrefs.GetInt(langKey);

        if (saved > 3 || saved < 1)
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
                "\n(january, 2020)";

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
                "\n(janeiro, 2020)";

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

    private void UpdateSeriesText()
    {
        if (control == 1) //English
        {
            textField[0].text = "about the app";
            textField[1].text = "This app is menant to" +
                "\nshow off the amazing" +
                "\nproprierties of the" +
                "\nfourier tools" +
                "\n\n- version: " + version +
                "\n(january, 2020)";

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
                "\n(janeiro, 2020)";

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

    private void UpdateLanguage()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "About":
                UpdateAboutText();
                break;
            case "Series":
                UpdateSeriesText();
                break;
        }
    }
}
