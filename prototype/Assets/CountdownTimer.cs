using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;
    float timeRemaining = 0f;
    float taskTime = 121f;
    public Text countdownText;
    public Text TimeRemaining;
    public bool trackingStart;


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
            }
        }

        // if(GameObject.Find("HapticFeedback").GetComponent<HitTriggers>().hit == true)
        // {

        // }

    }
}
