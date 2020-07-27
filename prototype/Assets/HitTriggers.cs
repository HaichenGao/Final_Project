using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTriggers : MonoBehaviour
{
    public Transform raycastOrigin;
    public Transform direction;
    public float maxDistance = 0.3f;
    public int m_layerMask = 1 << 11;
    public int n_layerMask = 1 << 10;

    //RaycastHit raycastHit;

    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {
        
         Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
         laserLineRenderer.SetPositions( initLaserPositions );
         laserLineRenderer.SetWidth( laserWidth, laserWidth );
    }

    // Update is called once per frame
    void Update()
    {
        // lineRenderer.SetPositions(0, raycastOrigin.position);
        // lineRenderer.SetPositions(1, raycastHit.point);
        // lineRenderer.enabled = true;
        ShootLaserFromTargetPosition(raycastOrigin.position, direction.TransformDirection(Vector3.forward), maxDistance);


       if(Physics.Raycast(raycastOrigin.position, direction.TransformDirection(Vector3.forward), maxDistance, m_layerMask) == true && Physics.Raycast(raycastOrigin.position, direction.TransformDirection(Vector3.forward), maxDistance, n_layerMask) == true)
        {
            OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
            Debug.Log("1");
        }
        // else{
        //     OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
        //     Debug.Log("0");
        // }

        if(Physics.Raycast(raycastOrigin.position, direction.TransformDirection(Vector3.forward), maxDistance, n_layerMask) == true && Physics.Raycast(raycastOrigin.position, direction.TransformDirection(Vector3.forward), maxDistance, m_layerMask) == false)
        {
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
            Debug.Log("2");
        }
        // else{
        //     OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
        //     Debug.Log("0");
        // }
        if(Physics.Raycast(raycastOrigin.position, direction.TransformDirection(Vector3.forward), maxDistance, n_layerMask) == false && Physics.Raycast(raycastOrigin.position, direction.TransformDirection(Vector3.forward), maxDistance, m_layerMask) == false)
        {
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
            Debug.Log("0");
        }

    }

    void ShootLaserFromTargetPosition( Vector3 targetPosition, Vector3 direction, float length )
     {
         Ray ray = new Ray( targetPosition, direction );
         RaycastHit raycastHit;
         Vector3 endPosition = targetPosition + ( length * direction );
 
         if( Physics.Raycast( ray, out raycastHit, length ,m_layerMask)){
             endPosition = raycastHit.point;
         }
 
         laserLineRenderer.SetPosition( 0, targetPosition );
         laserLineRenderer.SetPosition( 1, endPosition );
     }
 
}
