using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;

    public Transform respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(moveX, 0, moveZ);

        rb.AddForce(force * speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter:" + other.gameObject.tag);

        if(other.gameObject.tag == "FinishZone")
        {
            transform.position = respawnPoint.position;
            rb.isKinematic = false;
        }
    }
}
