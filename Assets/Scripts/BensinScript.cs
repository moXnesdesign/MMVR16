﻿using UnityEngine;
using System.Collections;
using System.Timers;

[RequireComponent(typeof(AudioSource))]
public class BensinScript : MonoBehaviour {

    //public delegate void Exploded();
    //public static event Exploded OnExploded;

    public GameObject bensin;
    public GameObject explosion;
    public AudioClip boomSound;
    

    bool played;

    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
        played = false;
    }

    void OnCollisionEnter(Collision col)
    {
        // Sjekk om bensinkanna er på bålet 
        if (col.gameObject == bensin)
        {
            source.PlayOneShot(boomSound, 1F);
            if (source.isPlaying)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                OnExploded();
                played = true;
            }
            if(played == true)
            {
                Destroy(bensin.gameObject);
            }
            //if (OnExploded != null)
            //    OnExploded();
            //EventManager.TriggerEvent("OnExploded");
            
        }
    }

    void OnExploded()
    {
        CasesScripts.ExperimentTwo = true;
        
        if (CasesScripts.ExperimentThree == true)
        {
            CasesScripts.experiment = 4;
            Debug.Log("Experiment " + CasesScripts.experiment);
        }
        else {
            CasesScripts.experiment = 3;
            Debug.Log("Experiment " + CasesScripts.experiment);
        }
        //Spill av fullført eksperiment lyd
        DisplayHintsScript.hintDisplayed = false;
        DisplayHintsScript.startTime = Time.time;
    }
}
