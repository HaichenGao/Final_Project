using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialPosition : MonoBehaviour
{
    //public Transform eyeLevel;
    public Transform canvasLevel;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 c = GameObject.Find("Menu").GetComponent<LoadScene>().height;
        Vector3 d = canvasLevel.position;
        d.y = c.y;
        canvasLevel.position = d;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
