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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Either a time based constant shift that is applied until the max angle is reached, or shift by pressing a button
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
        else
        {
            bool buttonXPressed = OVRInput.GetDown(OVRInput.Button.Three, OVRInput.Controller.Touch);

            if (buttonXPressed)
            {
                ApplyShift(maxAngle);
            }
        }
        
    }

    void ApplyShift(float angle)
    {
        // get axis between shoulders
        Vector3 axis = LeftShoulder.position - RightShoulder.position;

        // rotate the object around that axis projected from one shoulder
        ObjectToShift.RotateAround(RightShoulder.position, axis, angle);
        // ObjectToShift.position = new Vector3(RealHandLeft.position.x, ObjectToShift.position.y, ObjectToShift.position.z);
        // ObjectToShift.rotation = RealHandLeft.rotation;
        // ObjectToShift.Rotate(Vector3.forward*90);
    }
}
