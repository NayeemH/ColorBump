using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastMousePos;
    public float sensitivity = .16f, clampDelta = 42f;

    public float bounds = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update(){
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds,bounds),transform.position.y, transform.position.z);
        transform.position += FindObjectOfType<CameraControl>().camVel;
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePos = Input.mousePosition;
        }


        if (Input.GetMouseButton(0))
            {
                Vector3 vector = lastMousePos - Input.mousePosition;
                lastMousePos = Input.mousePosition;
                vector = new Vector3(vector.x, 0, vector.y);

                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
                // rb.AddForce(Vector3.forward * 1.5f + (-moveForce * sensitivity - rb.velocity / 5f), ForceMode.VelocityChange);
                rb.AddForce(-moveForce * sensitivity - rb.velocity / 5f, ForceMode.VelocityChange);
            }
            rb.velocity.Normalize();
    }
}