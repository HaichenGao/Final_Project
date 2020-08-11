using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShift : MonoBehaviour
{

    public Transform LeftShoulder;
    public Transform RightShoulder;

    public Transform ObjectToShift;
    public Transform RealHandLeft;

    public Transform leftAvatarPosition;

    [Tooltip("The maximum angle for the constant shift and the step angle for the button shift")]
    public float maxAngle;
    [Tooltip("The speed for the constant shift. Given in degree per second")]
    public float angularSpeed;

    [Tooltip("Selection whether a button shift or a constant shift is used")]
    public bool ConstantShift = false;


    private float m_currentAngle = 0.0f;

    float speed = 0f;
    Vector3 lastHandPosition = Vector3.zero;
    public float parameter;
    public float speedAngular;
    public float timeCount = 0.0f;
    public Transform change;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = RealHandLeft.position - lastHandPosition;
        float directionY = RealHandLeft.position.y - lastHandPosition.y;
        float d = Vector3.Dot(direction,Vector3.up);
        speed = Mathf.Abs(directionY)/Time.deltaTime;
        speedAngular = Time.deltaTime * speed/parameter;

        // Either a time based constant shift that is applied until the max angle is reached, or shift by pressing a button
        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart)
        {
            if(ConstantShift)
            {
                // Check whether we are there yet and, if not shift
                if(m_currentAngle < maxAngle)
                {
                    // calculate how much we would move
                    float speed = Time.deltaTime * angularSpeed;

                    // Make sure that we don't overshoot
                    float diff = maxAngle - m_currentAngle;

                    if(diff > 0)
                    {
                        ApplyShift(speed);
                        //ObjectToShift.position = new Vector3(RealHandLeft.position.x, ObjectToShift.position.y, ObjectToShift.position.z);
                        // Vector3 pos = RealHandLeft.position;
                        // ObjectToShift.position.x = pos.x;
                        m_currentAngle += speed;
                    }
                    else
                    {
                        ApplyShift(diff);
                        //ObjectToShift.position = new Vector3(RealHandLeft.position.x, ObjectToShift.position.y, ObjectToShift.position.z);
                        m_currentAngle = maxAngle;
                    }                
                }
                //ObjectToShift.position = new Vector3(RealHandLeft.position.x, ObjectToShift.position.y, ObjectToShift.position.z);
            }
            // else
            // {
            //     bool buttonXPressed = OVRInput.GetDown(OVRInput.Button.Three, OVRInput.Controller.Touch);

            //     if (buttonXPressed)
            //     {
            //         ApplyShift(maxAngle);
            //     }
            // }    
        }

        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStop && d < 0)
        {
            Debug.Log("123321");
            if(Vector3.Distance(ObjectToShift.position, RealHandLeft.position) > 0f)
            {

                change.rotation = RealHandLeft.rotation;
                change.Rotate(Vector3.forward*-90);
                Debug.Log("oooooooooooh");
                ObjectToShift.position = Vector3.MoveTowards(ObjectToShift.position, RealHandLeft.position, speedAngular);
                ObjectToShift.rotation = Quaternion.Slerp(ObjectToShift.rotation, change.rotation, timeCount);
                //timeCount = timeCount + Time.deltaTime;
                //ObjectToShift.rotation = RealHandLeft.rotation;
                //ObjectToShift.Rotate(Vector3.forward*-90);
            }

        }

        lastHandPosition = RealHandLeft.position;
        
        
    }

    void ApplyShift(float angle)
    {
        // get axis between shoulders
        Vector3 axis = LeftShoulder.position - RightShoulder.position;

        // rotate the object around that axis projected from one shoulder
        ObjectToShift.RotateAround(RightShoulder.position, axis, angle);
        // ObjectToShift.position.x = RealHandLeft.position.x;
        // ObjectToShift.rotation = RealHandLeft.rotation;
        // ObjectToShift.Rotate(Vector3.forward*90);
        // ObjectToShift.position = new Vector3(RealHandLeft.position.x, ObjectToShift.position.y, ObjectToShift.position.z);
        // ObjectToShift.rotation = RealHandLeft.rotation;
        // ObjectToShift.Rotate(Vector3.forward*-90);
    }
}
