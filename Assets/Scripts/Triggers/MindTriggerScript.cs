using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindTriggerScript : MonoBehaviour
{
    [SerializeField] int _triggerValue = 0;
    [SerializeField] GameObject _subTrigger;
    
    private MindController _mindController;
    bool _isActive = false;

    //

    private void Start()
    {
        _mindController = GetComponent<MindController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_subTrigger != null)
        {
            if (_isActive)
            {
                if (other.gameObject.tag == "Player")
                {
                    _mindController.DecreaseMindStatus(_triggerValue);
                    Destroy(gameObject);
                }
            }
        }
    }


}
