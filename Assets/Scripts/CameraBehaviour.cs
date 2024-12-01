using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraBehaviour : MonoBehaviour
{
    
    public Transform _mainCamera;
    public float _vignetteSpeed = 2f;

    private Volume _postProcessingVolume;
    private Vignette _vignette;
    private ChromaticAberration _chromaticAberration;

    private float Dt;

    
    void Start()
    {
        _postProcessingVolume = GetComponent<Volume>();
        Vignette vgt;
        ChromaticAberration chrmtcA;
        if (_postProcessingVolume.profile.TryGet(out vgt))
            _vignette = vgt;
        if (_postProcessingVolume.profile.TryGet(out chrmtcA))
            _chromaticAberration = chrmtcA;

    }

    
    void Update()
    {
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    if (_vignette.intensity.value != 1f)
        //    {
        //        _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 1, Dt);
        //        Dt += Time.deltaTime / _vignetteSpeed;
        //    }
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    _vignette.intensity.value = 0f;
        //}
    }
}
