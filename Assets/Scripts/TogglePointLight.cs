using UnityEngine;

public class TogglePointLight : MonoBehaviour
{
    public Light pointLight;
    bool isLightOn = false;
    private SoundManager soundManager;

    public bool Condition
    {
        get { return isLightOn; }
        set
        {
            isLightOn = value;
        }
    }


    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        if (pointLight == null)
        {
            Debug.LogError("Point Light component not assigned to this object!");
            return;
        }
        pointLight.enabled = false;

    }


    void Update()
    {
        
    }

    public void ToggleLightOn()
    {
        Debug.Log(isLightOn);
        isLightOn = true;
        //Debug.Log(isLightOn);
        pointLight.enabled = isLightOn;
        TurnOnSound();
        soundManager.PlayRandomCandleLightUp();
    }
    public void ToggleLightOff()
    {
        isLightOn = false;
        pointLight.enabled = isLightOn;
        TurnOffSound();
    }
    void TurnOnSound()
    {
       AudioSource candleSource = gameObject.GetComponentInParent<AudioSource>();
        candleSource.Play();
    }
    void TurnOffSound()
    {
        AudioSource candleSource = gameObject.GetComponentInParent<AudioSource>();
        candleSource.Stop();
    }
}