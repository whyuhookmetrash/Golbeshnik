using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQTE1 : MonoBehaviour
{
    public GameObject QTEPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("StartQTE");
            Instantiate(QTEPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
