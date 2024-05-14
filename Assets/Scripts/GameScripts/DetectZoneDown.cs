using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZoneDown : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] BoxCollider2D zoneUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entre por abajo");
            boxCollider2D.isTrigger = true;
            zoneUp.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TimeToColliderDown());
        }
    }
    IEnumerator TimeToColliderDown()
    {
        yield return new WaitForSecondsRealtime(1);
        boxCollider2D.isTrigger = false;
        zoneUp.gameObject.SetActive(true);
    }
}
