using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuasiRandom : MonoBehaviour
{

    public Transform ShoulderOnLeft;
    public Transform ShoulderOnRight;

    public Transform ShiftObject;
    public GameObject HandRight;

    public float amplitude = 0.12f;

    float currentTime = 0.0f;

    float speed = 0f;
    public Transform changeAngleAvatar;
    float speedAngular;
    public float secondParameter = 0.52f;
    Vector3 lastHandPosition = Vector3.zero;
    public float timeCount = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        // ObjectShift.position = RealHandRight.transform.position;
        // ObjectShift.rotation = RealHandRight.transform.rotation;
        // ObjectShift.Rotate(Vector3.forward*-90);
    }

    // Update is called once per frame
    void Update()
    {

        //Avatar.transform.position = RealHandRight.transform.position;
        // Vector3 direction = RealHandRight.transform.position - lastHandPosition;
        // float directionY = RealHandRight.transform.position.y - lastHandPosition.y;
        // float d = Vector3.Dot(direction, Vector3.up);
        // speed = Mathf.Abs(directionY)/Time.deltaTime;
        // //speed = directionY.magnitude/Time.deltaTime;
        // angularSpeed = Time.deltaTime * speed/parameter;

        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart)
        {
            ShiftObject.localPosition = new Vector3(amplitude*(Mathf.Sin(2.51f*currentTime) + Mathf.Sin(2.4f*currentTime) + Mathf.Sin(0.28f*currentTime) + Mathf.Sin(0.44f*currentTime)), amplitude*(Mathf.Sin(2.51f*currentTime) + Mathf.Sin(0.12f*currentTime + 0.25f*Mathf.PI) + Mathf.Sin(2f*currentTime) + Mathf.Sin(2.51f*currentTime + 0.5f*Mathf.PI)), amplitude*(Mathf.Sin(1.31f*currentTime) + Mathf.Sin(1.16f*currentTime + 0.5f*Mathf.PI) + Mathf.Sin(2.4f*currentTime)));
            currentTime += 1 * Time.deltaTime;
        }


        // if(OVRInput.GetDown(OVRInput.Button.Three, OVRInput.Controller.Touch))
        // {
        //     ObjectShift.position = RealHandRight.transform.position;
        //     ObjectShift.rotation = RealHandRight.transform.rotation;
        //     ObjectShift.Rotate(Vector3.forward*-90);
        // }

        Vector3 direction = HandRight.transform.position - lastHandPosition;
        float directionY = HandRight.transform.position.y - lastHandPosition.y;
        float d = Vector3.Dot(direction, Vector3.up);
        speed = Mathf.Abs(directionY)/Time.deltaTime;
        //speed = directionY.magnitude/Time.deltaTime;
        //angularSpeed = Time.deltaTime * speed/parameter;
        speedAngular = Time.deltaTime * speed/secondParameter;

        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStop && d < 0)
        {
            //Debug.Log("123321");
            if(Vector3.Distance(ShiftObject.position, HandRight.transform.position) > 0f)
            {

                changeAngleAvatar.rotation = HandRight.transform.rotation;
                changeAngleAvatar.Rotate(Vector3.forward*-90);
                //Debug.Log("oooooooooooh");
                ShiftObject.position = Vector3.MoveTowards(ShiftObject.position, HandRight.transform.position, speedAngular);
                ShiftObject.rotation = Quaternion.Slerp(ShiftObject.rotation, changeAngleAvatar.rotation, timeCount);
                //timeCount = timeCount + Time.deltaTime;
                //ObjectToShift.rotation = RealHandLeft.rotation;
                //ObjectToShift.Rotate(Vector3.forward*-90);
            }

        }

        // Debug.Log(speed); 

        lastHandPosition = HandRight.transform.position;
        
    }

    // void ApplyShift(float angle)
    // {
    //     // get axis between shoulders
    //     Vector3 axis = ShoulderLeft.position - ShoulderRight.position;

    //     // rotate the object around that axis projected from one shoulder
    //     ObjectShift.RotateAround(ShoulderRight.position, axis, angle);
    //     // ObjectToShift.position = new Vector3(RealHandLeft.position.x, ObjectToShift.position.y, ObjectToShift.position.z);
    //     // ObjectToShift.rotation = RealHandLeft.rotation;
    //     // ObjectToShift.Rotate(Vector3.forward*90);
    // }
}
