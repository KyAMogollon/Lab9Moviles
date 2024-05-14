using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZoneUpPlatform : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entre x arriba");
            boxCollider2D.isTrigger = false;
        }
    }
}
