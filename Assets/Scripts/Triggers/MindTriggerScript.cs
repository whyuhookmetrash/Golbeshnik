using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindTriggerScript : MonoBehaviour
{
    [SerializeField] int _triggerValue = 0;

    private MindController _mindController;
    private bool _activateOtherTrigger = false;
    bool _isActive = false;

    public bool _ActivateOtherTrigger { get => _activateOtherTrigger; }


    private void Start()
    {
        _mindController = GetComponent<MindController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_isActive)
            {
                _mindController.DecreaseMindStatus(_triggerValue);
                _activateOtherTrigger = true;
                _isActive = true;
            }
            //Destroy(gameObject);
        }
    }


}
