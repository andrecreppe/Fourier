using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
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
    public Text aboutTitle, aboutText, developerTitle, developerText, contactTitle, langText;

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
        if(control == 1) //English
        {
            aboutTitle.text = "about the app";
            aboutText.text = "This app is menant to" +
                "\nshow off the amazing" +
                "\nproprierties of the" +
                "\nfourier tools" +
                "\n\n- version: " + version +
                "\n(december, 2019)";

            developerTitle.text = "the developer";
            developerText.text = "André z. creppe" +
                "\n(all rights reserved)";

            contactTitle.text = "contact";

            langText.text = "Language:" +
                "\nEnglish";
        }
        else if(control == 2) //Portuguese
        {
            aboutTitle.text = "sobre este app";
            aboutText.text = "esse aplicativo tem como" +
                "\nfinalidade demonstrar" +
                "\nas incriveis propriedades" +
                "\ndas ferramentas de fourier" +
                "\n\n- versão: " + version +
                "\n(dezembro, 2019)";

            developerTitle.text = "desenvolvedor";
            developerText.text = "andré z. creppe" +
                "\n(direitos reservados)";

            contactTitle.text = "contato";

            langText.text = "idioma:" +
                "\nPortuguês";
        }
//        else if(control == 3) //German
//        {
//            aboutTitle.text = "";
//            aboutText.text = "";
//
//            developerTitle.text = "";
//            developerText.text = "";
//
//            contactTitle.text = "";
//
//            langText.text = "";
//        }
    }

    //------------------ PUBLIC METHODS --------------------

    public void UpdateLanguage()
    {
        control++;

        if (control > max)
        {
            control = 1;
        }

        PlayerPrefs.SetInt(langKey, control);
        PlayerPrefs.Save();

        changeButton.image.sprite = flags[control-1] ;

        UpdateAboutText();
    }
}
