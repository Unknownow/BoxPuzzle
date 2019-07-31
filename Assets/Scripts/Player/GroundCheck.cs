using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private bool _isGrounded;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded |= collision.transform.CompareTag("Tile Map");
        if (GetIsGrounded())
        {
            transform.parent.GetComponent<PlayerMovement>().OnBreak();
            transform.parent.GetComponent<PlayerMovement>().OnGrounded();
        }
            
    }

    public bool GetIsGrounded()
    {
        return _isGrounded;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded &= !collision.transform.CompareTag("Tile Map");
    }

    
}
