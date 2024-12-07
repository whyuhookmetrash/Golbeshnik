using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMindTriggerScript : MonoBehaviour
{
    [SerializeField] int _triggerValue = 0;
    [SerializeField] MindTriggerScript _subTrigger;

    private MindController _mindController;
    bool _isActive = false;

    private void Start()
    {
        _mindController = GetComponent<MindController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_subTrigger != null)
        {
            if (_subTrigger._ActivateOtherTrigger && !_isActive)
            {
                if (other.gameObject.tag == "Player")
                {
                    _mindController.DecreaseMindStatus(_triggerValue);
                    Destroy(_subTrigger);
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
