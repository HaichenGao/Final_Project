using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOffset : MonoBehaviour
{
    public GameObject offsetReceiver;
    //float i = 0.0001f;
    public float k = 0.0001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(k <= 0.32f){
            offsetReceiver.transform.position += new Vector3(0.0f, 0.0001f, 0.0f);
            k += 0.0001f;

        }
        
        //offsetReceiver.transform.Rotate(0.01f, 0.0f, 0.0f);
    }
}
