using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("Next").GetComponent<Button>().interactable = false;
        GameObject.Find("Questionnaire").GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        // if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart && GameObject.Find("Canvas").GetComponent<LoadScene>().trackingStart)
        // {
        //     GameObject.Find("Questionnaire").GetComponent<Button>().interactable = true;
        // }
    }


    // public void ButtonOnClick()
    // {
    //     gameObject.GetComponent<Button>().interactable = false; 
    // }
}
