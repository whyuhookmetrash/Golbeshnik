using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindTriggerScript : MonoBehaviour
{
    [SerializeField] int _triggerValue = 0; 
    
    private MindController _mindController;

    private void Start()
    {
        _mindController = GetComponent<MindController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _mindController.DecreaseMindStatus(_triggerValue);
        }
    }


}
