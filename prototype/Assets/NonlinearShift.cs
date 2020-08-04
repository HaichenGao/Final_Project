using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonlinearShift : MonoBehaviour
{

    public Transform ShoulderLeft;
    public Transform ShoulderRight;

    public Transform ObjectShift;
    public GameObject RealHandRight;

    float speed = 0f;

    Vector3 lastHandPosition = Vector3.zero;

    private float m_currentAngle = 0.0f;
    public float maxAngle;
    float angularSpeed;
    public float parameter;

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
        Vector3 direction = RealHandRight.transform.position - lastHandPosition;
        float directionY = RealHandRight.transform.position.y - lastHandPosition.y;
        float d = Vector3.Dot(direction, Vector3.up);
        speed = Mathf.Abs(directionY)/Time.deltaTime;
        //speed = directionY.magnitude/Time.deltaTime;
        angularSpeed = Time.deltaTime * speed/parameter;

        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart)
        {
            if(m_currentAngle < maxAngle)
            {
                // if(d > 0)
                // {
                //     ApplyShift(angularSpeed);
                //     m_currentAngle += angularSpeed;

                // }
                ApplyShift(angularSpeed);
                m_currentAngle += angularSpeed;
            }
        }


        if(OVRInput.GetDown(OVRInput.Button.Three, OVRInput.Controller.Touch))
        {
            ObjectShift.position = RealHandRight.transform.position;
            ObjectShift.rotation = RealHandRight.transform.rotation;
            ObjectShift.Rotate(Vector3.forward*-90);
        }



        Debug.Log(speed); 

        lastHandPosition = RealHandRight.transform.position;
        
    }

    void ApplyShift(float angle)
    {
        // get axis between shoulders
        Vector3 axis = ShoulderLeft.position - ShoulderRight.position;

        // rotate the object around that axis projected from one shoulder
        ObjectShift.RotateAround(ShoulderRight.position, axis, angle);
        // ObjectToShift.position = new Vector3(RealHandLeft.position.x, ObjectToShift.position.y, ObjectToShift.position.z);
        // ObjectToShift.rotation = RealHandLeft.rotation;
        // ObjectToShift.Rotate(Vector3.forward*90);
    }
}
