using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public GameObject point;
    public float movingSpeed = 0.01f;

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
        point.transform.localPosition = new Vector3(Mathf.Sin(2.07f*Time.time) + Mathf.Sin(1.65f*Time.time) + Mathf.Sin(0.23f*Time.time) + Mathf.Sin(0.37f*Time.time), Mathf.Sin(2.07f*Time.time + 0.5f*Mathf.PI) + Mathf.Sin(0.96f*Time.time + 0.5f*Mathf.PI) + Mathf.Sin(1.98f*Time.time) + Mathf.Sin(1.08f*Time.time), 0f);
        //point.transform.localPosition = new Vector3(0f, Mathf.Sin(2.07f*Time.time), 0f);
    }
}
