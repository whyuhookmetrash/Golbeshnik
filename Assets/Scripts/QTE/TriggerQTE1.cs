using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQTE1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("StartQTE");
            Destroy(gameObject);
        }
    }
}
