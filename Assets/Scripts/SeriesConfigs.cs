using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeriesConfigs : MonoBehaviour
{
    //------------------ VARIABLES --------------------

    private int borderWidth, bigSize, smallSize;
    private bool firstTime;
    private Color32 active, inactive, lightActive, lightInactive;
    private Vector2 big, small;
    private Vector3 bigPosition, smallPosition, squareReference, sawToothReference;

    public Image squareImage, sawToothImage;
    public RectTransform squareButton, sawToothButton;
    public Text squareText, sawToothText;

    //------------------ PRIVATE METHODS --------------------

    private void Start()
    {
        firstTime = true;

        active = new Color32(0, 255, 20, 255);
        lightActive = new Color32(182, 255, 167, 255);
        inactive = new Color32(255, 82, 0, 255);
        lightInactive = new Color32(255, 168, 167, 255);

        borderWidth = 20;
        big = new Vector2(600, 600);
        bigSize = -370;
        small = new Vector2(500, 500);
        smallSize = -320;

        squareReference = squareButton.transform.position;
        sawToothReference = sawToothButton.transform.position;

        if (PlayerPrefs.GetInt("wave") == 1)
            SetSquareAsActive();
        else
            SetSawToothAsActive();

        firstTime = false;
    }

    //------------------ PUBLIC METHODS --------------------

    public void SetSquareAsActive()
    {
        PlayerPrefs.SetInt("wave", 1);

        if(!firstTime)
        {
            bigPosition = new Vector3(squareReference.x - 50, squareReference.y + bigSize);
            smallPosition = new Vector3(sawToothReference.x - 50, sawToothReference.y + smallSize);
        }
        else
        {
            bigPosition = new Vector3(squareReference.x, squareReference.y + bigSize);
            smallPosition = new Vector3(sawToothReference.x, sawToothReference.y + smallSize);
        }

        //Button
        squareButton.sizeDelta = big;
        //Text
        squareText.color = lightActive;
        squareText.GetComponent<RectTransform>().position = bigPosition;
        //Image
        squareImage.color = active;
        squareImage.GetComponent<RectTransform>().sizeDelta 
            = new Vector2(big.x + borderWidth, big.y + borderWidth);

        //Button
        sawToothButton.sizeDelta = small;
        //Text
        sawToothText.color = lightInactive;
        sawToothText.GetComponent<RectTransform>().position = smallPosition;
        //Image
        sawToothImage.color = inactive;
        sawToothImage.GetComponent<RectTransform>().sizeDelta 
            = new Vector2(small.x + borderWidth, small.y + borderWidth);
    }

    public void SetSawToothAsActive()
    {
        PlayerPrefs.SetInt("wave", 2);

        bigPosition = new Vector3(sawToothReference.x, sawToothReference.y + bigSize);
        smallPosition = new Vector3(squareReference.x, squareReference.y + smallSize);

        //Button
        squareButton.sizeDelta = small;
        //Text
        squareText.color = lightInactive;
        squareText.GetComponent<RectTransform>().position = smallPosition;
        //Image
        squareImage.color = inactive;
        squareImage.GetComponent<RectTransform>().sizeDelta 
            = new Vector2(small.x + borderWidth, small.y + borderWidth);

        //Button
        sawToothButton.sizeDelta = big;
        //Text
        sawToothText.color = lightActive;
        sawToothText.GetComponent<RectTransform>().position = bigPosition;
        //Image
        sawToothImage.color = active;
        sawToothImage.GetComponent<RectTransform>().sizeDelta 
            = new Vector2(big.x + borderWidth, big.y + borderWidth);
    }
}
