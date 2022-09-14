using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldGolfClub : MonoBehaviour
{
    Rigidbody rb;
    public Transform controller;
    public float rotateBy = 0;
    public float heightOffset = -2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per physics update
    void FixedUpdate()
    {
        rb.MovePosition(controller.position + new Vector3 (0, heightOffset, 0));
        rb.MoveRotation(controller.rotation * Quaternion.Euler(rotateBy, 0, 0));
    }
}
