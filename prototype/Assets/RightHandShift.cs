using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandShift : MonoBehaviour
{
    public GameObject rightHandAvatar;
    public Transform rightRealHand;
    public Transform rightShoulderJoint;
    public Transform rightAvatarPosition;
    public float rightRotationAngle = -45f;

    // Start is called before the first frame update
    void Start()
    {

        //avatarPosition.position = realHand.position;
        //handAvatar.transform.RotateAround(shoulderJoint.position, shoulderJoint.transform.right, speed);
    }

    // Update is called once per frame
    void Update()
    {
        rightAvatarPosition.position = rightRealHand.position;
        rightAvatarPosition.rotation = rightRealHand.rotation;
        rightAvatarPosition.Rotate(Vector3.forward*-90);
        rightAvatarPosition.transform.RotateAround(rightShoulderJoint.position, rightShoulderJoint.transform.right, rightRotationAngle);
        // avatarPosition.position = handAvatar.transform.position;
        // avatarPosition.rotation = handAvatar.transform.rotation;
        rightHandAvatar.transform.position = rightAvatarPosition.position;
        rightHandAvatar.transform.rotation = rightAvatarPosition.rotation;
        // avatarPosition.position = realHand.position;
        // avatarPosition.rotation = realHand.rotation;
        // avatarPosition.Rotate(Vector3.forward*90);
        // handAvatar.transform.RotateAround(shoulderJoint.position, shoulderJoint.transform.right, rotationAngle);

        //avatarPosition = realHand.position;
        // if(OVRInput.GetUp (OVRInput.RawButton.A))
        // {
        //             avatarPosition.RotateAround(shoulderJoint.position, shoulderJoint.transform.right, rotationAngle);
        //             // avatarPosition.position = handAvatar.transform.position;
        //             // avatarPosition.rotation = handAvatar.transform.rotation;
        //             handAvatar.transform.position = avatarPosition.position;
        //             handAvatar.transform.rotation = avatarPosition.rotation;
        //             avatarPosition.position = realHand.position;
        //             avatarPosition.rotation = realHand.rotation;
        //             avatarPosition.Rotate(Vector3.forward*90);
        // }

        // if(OVRInput.GetUp (OVRInput.RawButton.B))
        // {
        //     handAvatar.transform.position = realHand.position;
        //     handAvatar.transform.rotation = realHand.rotation;
        //     handAvatar.transform.Rotate(Vector3.forward*90);
        // }
    }
}
