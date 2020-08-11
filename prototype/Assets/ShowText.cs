using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour
{
    public string sceneName;


    // Start is called before the first frame update
    void Start()
    {

        // sceneName = SceneManager.GetActiveScene().name;
        // switch(sceneName)
        // {
        //     case "Linear_Top":
        //         condition.text = "Condition: 1";
        //         break;
        //     case "None_Bottom":
        //         condition.text = "Condition: 2";
        //         break;
        //     case "None_Top":
        //         condition.text = "Condition: 3";
        //         break;
        //     case "Proportional_Top":
        //         condition.text = "Condition: 4";
        //         break;
        //     case "Quasi_Random":
        //         condition.text = "Condition: 5";
        //         break;
        //     case "Menu 1":
        //         break;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // if(OVRInput.GetDown(OVRInput.RawButton.B))
        // {
        //     GameObject.Find("Welcome").SetActive(false);
        // }
    }
}
