using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public GameObject point;
    public float movingSpeed = 0.01f;
    public float amplitude = 0.12f;
    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //point.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //point.transform.position.y = Mathf.Sin(2.07f*Time.time + 0.5f*Mathf.PI) + Mathf.Sin(0.96f*Time.time + 0.5f*Mathf.PI) + Mathf.Sin(1.98f*Time.time) + Mathf.Sin(1.08f*Time.time);
        //point.transform.position.z = Mathf.Sin(2.07f*Time.time) + Mathf.Sin(1.65f*Time.time) + Mathf.Sin(0.23f*Time.time) + Mathf.Sin(0.37f*Time.time);
        //point.transform.localPosition = new Vector3(0f, Mathf.Sin(2.07f*Time.time), 0f);
        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart)
        {
            point.transform.localPosition = new Vector3(amplitude*(Mathf.Sin(2.07f*currentTime) + Mathf.Sin(1.65f*currentTime) + Mathf.Sin(0.23f*currentTime) + Mathf.Sin(0.37f*currentTime)), amplitude*(Mathf.Sin(2.07f*currentTime + 0.5f*Mathf.PI) + Mathf.Sin(0.96f*currentTime + 0.5f*Mathf.PI) + Mathf.Sin(1.98f*currentTime) + Mathf.Sin(1.08f*currentTime)), 0f);
            currentTime += 1 * Time.deltaTime;

        }
    }
}
