using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMindTriggerScript : MonoBehaviour
{
    [SerializeField] int _triggerValue = 0;

    private MindController _mindController;
    bool _isActive = false;

    private void Start()
    {
        _mindController = GetComponent<MindController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _mindController.DecreaseMindStatus(_triggerValue);
            Destroy(gameObject);
        }
    }
}
