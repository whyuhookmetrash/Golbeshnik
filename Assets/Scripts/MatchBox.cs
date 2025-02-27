using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBox : MonoBehaviour
{
    [SerializeField] int matchesInBox = 5;

    public SoundManager soundManager;

    public int MatchesInBox
    {
        get { return matchesInBox; }
        set
        {
            matchesInBox = value;
        }
    }
    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

}
