using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;
    public float timeRemaining = 0f;
    public float taskTime = 121f;
    // public float loadingTime = 20f;
    public Text countdownText;
    public Text TimeRemaining;
    // public TextMeshProUGUI loadingText;
    public bool trackingStart;
    public bool trackingStop;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        timeRemaining = taskTime;
        //GameObject.Find("CountdownText").SetActive(false);
        GameObject.Find("CountdownText").GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("HapticFeedback").GetComponent<HitTriggers>().hit == true)
        {
            //countdownText.color = Color.red;
            GameObject.Find("CountdownText").GetComponent<Text>().enabled = true;

            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            
            if(currentTime <= 0)
            {
                currentTime = 0;
                GameObject.Find("CountdownText").GetComponent<Text>().enabled = false;
                trackingStart = true;
                //Debug.Log("START");
            }

            // if(trackingStart)
            // {
            //     timeRemaining -= 1 * Time.deltaTime;
            //     TimeRemaining.text = timeRemaining.ToString("0");

            //     if(timeRemaining <= 0)
            //     {
            //         timeRemaining = 0;
            //         trackingStart = false;
            //     }
            // }
        }

        if(trackingStart)
        {
            timeRemaining -= 1 * Time.deltaTime;
            TimeRemaining.text = timeRemaining.ToString("0");

            if(timeRemaining <= 0)
            {
                timeRemaining = 0;
                trackingStart = false;
                trackingStop = true;
            }
        }

        // if()
        // {

        // }

        // if(GameObject.Find("HapticFeedback").GetComponent<HitTriggers>().hit == true)
        // {

        // }

    }
}
