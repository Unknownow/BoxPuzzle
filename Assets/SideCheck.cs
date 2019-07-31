using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCheck : MonoBehaviour
{
    [SerializeField]
    private bool _isBlocked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isBlocked |= collision.transform.CompareTag("Tile Map");
    }

    public bool GetIsBlocked()
    {
        return _isBlocked;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isBlocked &= !collision.transform.CompareTag("Tile Map");
    }
}
