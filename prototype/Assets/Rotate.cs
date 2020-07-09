using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject cube;
    public Transform center;
    //public Vector3 axis = center.transform.forward;
    public Vector3 desiredPosition;
    public float radius = 0.4f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    void Start () {
        //cube = GameObject.FindWithTag("Cube");
        cube.transform.position = (cube.transform.position - center.position).normalized * radius + center.position;
        radius = 0.4f;
    }

    void Update () {
        cube.transform.RotateAround(center.position, center.transform.forward, rotationSpeed * Time.deltaTime);
        desiredPosition = (cube.transform.position - center.position).normalized * radius + center.position;
        cube.transform.position = Vector3.MoveTowards(cube.transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}
