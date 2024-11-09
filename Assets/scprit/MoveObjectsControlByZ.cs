using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjectsControlByZ: MonoBehaviour
{
    [SerializeField] private bool inversion = false;
    private KeyCode right;
    private KeyCode left;
    private Vector3 move = new Vector3(0f, 0f, 0.5f);

    private Rigidbody rb;
    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (inversion == false)
        {
            right = KeyCode.D;
            left = KeyCode.A;
        }
        else
        {
            right = KeyCode.A;
            left = KeyCode.D;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(right))
        {
            rb.velocity += move;
            isMoving = true;
        }
        else if (Input.GetKey(left))
        {
            rb.velocity -= move;
            isMoving = true;
        }
        else if (isMoving)
        {
            isMoving = false;
            StartCoroutine("StopMovementAfterDelay");
        }
    }
    private IEnumerator StopMovementAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector3.zero;           
    }
}
