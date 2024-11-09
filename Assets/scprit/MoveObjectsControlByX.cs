using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjectsControlByX: MonoBehaviour
{
    [SerializeField] private bool inversion = false;
    private KeyCode before;
    private KeyCode back;
    private Vector3 move = new Vector3(0.5f, 0f, 0f);

    private Rigidbody rb;
    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (inversion == false)
        {
            before = KeyCode.W;
            back = KeyCode.S;
        }
        else
        {
            before = KeyCode.S;
            back = KeyCode.W;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(before))
        {
            rb.velocity -= move;
            isMoving = true;
        }
        else if (Input.GetKey(back))
        {
            rb.velocity += move;
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
