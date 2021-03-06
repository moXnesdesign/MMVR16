﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ProfessorScript : MonoBehaviour {
    //public delegate void Saved();
    //public static event Saved OnSaved;
    public AudioClip tutorial;

    Vector3 profPos;
    Vector3 profRot;

    public GameObject telt;
    private AudioSource source;

    // For TurnOffStatic method
    public GameObject bensin;
    public GameObject nitrogen;
    public GameObject nitrogenLid;
    public GameObject bucket;
    public GameObject grill;

    Rigidbody profBody;
    public GameObject O2;
    private Renderer oksygenRend;
    public GameObject oksygen;

    bool audioPlaying;

    public static bool tutorialPlayed;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        tutorialPlayed = false;
        audioPlaying = false;
        profBody = gameObject.GetComponent<Rigidbody>();
        oksygenRend = oksygen.GetComponent<Renderer>();
    }

    void EnableOxygen()
    {
        O2.transform.localScale = new Vector3(2f, 2f, 2f);
        oksygenRend.enabled = true;
    }


    void OnTriggerEnter(Collider col) {
        if (col.gameObject == telt) {
            if(audioPlaying == false) {
                audioPlaying = true;
                source.PlayOneShot(tutorial, 1F);
                OnSaved();
                TurnOffStatic();
            }
        }
    }

    void FixedUpdate()
    {
        // Sjekk når professoren er ferdig å prate
        if (!source.isPlaying && audioPlaying == true)
        {
            // Activate button triggers and hits     
            tutorialPlayed = true;
            CasesScripts.ExperimentOne = true;
        }
    }

    void OnSaved()
    {
        CasesScripts.experiment = 2;
        Destroy(profBody);
        EnableOxygen();
        // Drop professor once TriggerEnter is executed
        gameObject.transform.SetParent(null);
        
    }

    void TurnOffStatic()
    {
        bensin.AddComponent<Rigidbody>();

        bucket.AddComponent<Rigidbody>();

        nitrogen.AddComponent<Rigidbody>();

        nitrogenLid.AddComponent<Rigidbody>();
    }

}
