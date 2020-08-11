using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UserID : MonoBehaviour
{
    public TextMeshProUGUI userId;
    public TextMeshProUGUI condition;

    public string sceneName;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        userId.text = "Participant ID: " + GameObject.Find("Logger").GetComponent<Logger>().id;
        sceneName = SceneManager.GetActiveScene().name;
        switch(sceneName)
        {
            case "Linear_Top":
                condition.text = "Condition: 1";
                break;
            case "None_Bottom":
                condition.text = "Condition: 2";
                break;
            case "None_Top":
                condition.text = "Condition: 3";
                break;
            case "Proportional_Top":
                condition.text = "Condition: 4";
                break;
            case "Quasi_Random":
                condition.text = "Condition: 5";
                break;
        }
    }
}
