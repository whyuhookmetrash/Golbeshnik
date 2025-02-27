using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private LayerMask visibleTriggerMask;
    void Start()
    {
        visibleTriggerMask = LayerMask.GetMask("Wall", "VisibleTrigger");
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.yellow, 0.02f);
        if (Physics.Raycast(ray, out hit, 100f, visibleTriggerMask))
        {
            VisibleTrigger visibleTrigger = hit.collider.GetComponent<VisibleTrigger>();
            if (visibleTrigger != null)
            {
                if (visibleTrigger.CheckConditions())
                {
                    visibleTrigger.ActivateTrigger();
                }
            }
        }


    }
}
