using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZoneUp : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entre x arriba");
            boxCollider2D.isTrigger = false;
            StartCoroutine(TimeToBreakOut());
        }
    }
    IEnumerator TimeToBreakOut()
    {
        yield return new WaitForSeconds(0.3f);
        boxCollider2D.gameObject.SetActive(false);
    }
}
