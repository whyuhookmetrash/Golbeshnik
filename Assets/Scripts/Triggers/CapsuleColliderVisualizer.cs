using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleColliderVisualizer : MonoBehaviour
{
    [SerializeField] private bool isActive;
    public Material lineMaterial;
    public GameObject renderCapsule;

    private CapsuleCollider capsuleCollider;
    private Transform renderCapsuleTransform; 
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        renderCapsuleTransform = renderCapsule.GetComponent<Transform>();
        if (!isActive)
        {
            Destroy(renderCapsule);
        }
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        renderCapsuleTransform.rotation = gameObject.transform.rotation;
        renderCapsuleTransform.Rotate(0, 0, 90);

        float scaleX = capsuleCollider.height / 2;
        float scaleY = capsuleCollider.radius / 0.5f;
        float scaleZ = scaleY;

        renderCapsuleTransform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
}
