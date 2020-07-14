﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandShift : MonoBehaviour
{
    public GameObject leftHandAvatar;
    public Transform leftRealHand;
    public Transform leftShoulderJoint;
    public Transform leftAvatarPosition;
    public float leftRotationAngle = -45f;

    // Start is called before the first frame update
    void Start()
    {

        //avatarPosition.position = realHand.position;
        //handAvatar.transform.RotateAround(shoulderJoint.position, shoulderJoint.transform.right, speed);
    }

    // Update is called once per frame
    void Update()
    {
        leftAvatarPosition.position = leftRealHand.position;
        leftAvatarPosition.rotation = leftRealHand.rotation;
        leftAvatarPosition.Rotate(Vector3.forward*90);
        leftAvatarPosition.transform.RotateAround(leftShoulderJoint.position, leftShoulderJoint.transform.right, leftRotationAngle);
        // avatarPosition.position = handAvatar.transform.position;
        // avatarPosition.rotation = handAvatar.transform.rotation;
        leftHandAvatar.transform.position = leftAvatarPosition.position;
        leftHandAvatar.transform.rotation = leftAvatarPosition.rotation;
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
