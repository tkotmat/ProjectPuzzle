using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayerX : MonoBehaviour
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DynamicObj") || collision.gameObject.CompareTag("Player"))
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("DynamicObj") || collision.gameObject.CompareTag("Player"))
        {
            rb.constraints |= RigidbodyConstraints.FreezePositionX;
        }
    }
}
