using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipForInteraction : MonoBehaviour
{

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        PlayerController.isLookingAtInteractiveObj += SetVisibility;
    }

    private void OnDisable()
    {
        PlayerController.isLookingAtInteractiveObj -= SetVisibility;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void SetVisibility(bool flag) 
    {
      
        if (flag) 
        {
            _canvasGroup.alpha = 1f;
        }
        else
            _canvasGroup.alpha = 0f;
    }

}
