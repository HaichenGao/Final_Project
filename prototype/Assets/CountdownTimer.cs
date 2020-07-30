using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;
    float timeRemaining = 0f;
    float taskTime = 120f;
    public Text countdownText;
    public Text TimeRemaining;
    public bool trackingStart;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        timeRemaining = taskTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Switch").GetComponent<StartStop>().effectsOn)
        {
            countdownText.color = Color.red;

            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            
            if(currentTime <= 0)
            {
                currentTime = 0;
                trackingStart = true;
            }

            if(trackingStart)
            {
                timeRemaining -= 1 * Time.deltaTime;
                TimeRemaining.text = timeRemaining.ToString("0");

                if(timeRemaining <= 0)
                {
                    timeRemaining = 0;
                }
            }
        }

    }
}
