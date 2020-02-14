using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
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

        
    }
}
