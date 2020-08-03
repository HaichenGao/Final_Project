using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{
    public void ButtonOnClick()
    {
        gameObject.GetComponent<Button>().interactable = false; 
    }
}
