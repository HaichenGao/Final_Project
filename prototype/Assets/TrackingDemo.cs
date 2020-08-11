using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingDemo : MonoBehaviour
{
    public GameObject circle;
    public float movingSpeed = 0.01f;
    public float amplitude = 0.12f;
    private float currentTime = 0.0f;
    public GameObject trackTask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart)
        {
            circle.transform.localPosition = new Vector3(amplitude*(Mathf.Sin(2.07f*currentTime) + Mathf.Sin(1.65f*currentTime) + Mathf.Sin(0.23f*currentTime) + Mathf.Sin(0.37f*currentTime)), amplitude*(Mathf.Sin(2.07f*currentTime + 0.5f*Mathf.PI) + Mathf.Sin(0.96f*currentTime + 0.5f*Mathf.PI) + Mathf.Sin(1.98f*currentTime) + Mathf.Sin(1.08f*currentTime)), 0f);
            currentTime += 1 * Time.deltaTime;

        }
    }
}
