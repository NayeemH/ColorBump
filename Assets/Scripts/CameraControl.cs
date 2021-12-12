using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
   public float cameraSpeed = 6f;
   public Vector3 camVel;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * cameraSpeed * Time.deltaTime;
        camVel = Vector3.forward * cameraSpeed * Time.deltaTime;
    }
}
