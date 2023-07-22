using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class CellBtn : MonoBehaviour
{
    public GameObject textGO;
    public GameObject tickGO;
    public GameObject wrongGO;

    public RtlText myTxt;
    public int selectedNumber;

    public void RightAnswer()
    {
        textGO.SetActive(false);
        tickGO.SetActive(true);
        wrongGO.SetActive(false);
    }

    public void WrongAnswer()
    {
        textGO.SetActive(false);
        tickGO.SetActive(false);
        wrongGO.SetActive(true);
    }

    public void TextState()
    {
        textGO.SetActive(true);
        tickGO.SetActive(false);
        wrongGO.SetActive(false);
    }

    public void SetText(int myNumber)
    {
        //selectedNumber --> selected number 
        selectedNumber = myNumber;
        myTxt.text = myNumber.ToString();
    }


}
