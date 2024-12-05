using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    private bool isCoroutine;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            FootstepsCoroutine();
        }
        else
        {
            Stop("Walk");
            StopCoroutine("FootstepsCoroutine");
            isCoroutine = false;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
    public void PlayButtonSound()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "ButtonClick");
        if (s == null)
            return;
        s.source.Play();
    }
    private AudioSource PlayWalk()
    {

        string name = GetRandomFootstep();
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return null;
        s.source.pitch = UnityEngine.Random.Range(0.7f, 1.3f);
        s.source.Play();
        return s.source;
    }
    private void FootstepsCoroutine()
    {
        if (!isCoroutine)
            StartCoroutine(FootstepSound());
    }
    IEnumerator FootstepSound()
    {
        isCoroutine = true;
        AudioSource s = PlayWalk();
        yield return new WaitForSeconds(1);
        isCoroutine = false;
    }

    private string GetRandomFootstep()
    {
        int n = UnityEngine.Random.Range(1, 11);
        switch (n)
        {
            case 1:
                return "Footstep1";
            case 2:
                return "Footstep2";
            case 3:
                return "Footstep3";
            case 4:
                return "Footstep4";
            case 5:
                return "Footstep5";
            case 6:
                return "Footstep6";
            case 7:
                return "Footstep7";
            case 8:
                return "Footstep8";
            case 9:
                return "Footstep9";
            case 10:
                return "Footstep10";
            default:
                return null;
        }


    }
    private AudioSource GetSource(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return null;
        return s.source;
    }
    private void LoadSounds()
    {
        //возможно потом пригодится, когда добавится саундтрек
    }
}
