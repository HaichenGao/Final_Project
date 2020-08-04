using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretch : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        leftHand.transform.position = leftHand.transform.position + new Vector3(-10f, 0f, 0f);
        Debug.Log(leftHand.transform.position.ToString());
        rightHand.transform.position = rightHand.transform.position + new Vector3(10f, 0f, 0f);
        Debug.Log(rightHand.transform.position.ToString());
    }


}
