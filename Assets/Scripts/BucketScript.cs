﻿using UnityEngine;
using System.Collections;

public class BucketScript : MonoBehaviour {

    public static bool waterInBucket;
    public GameObject lake;
    public GameObject campfire;
    public TextMesh degrees;
    public static bool boiled;
    private Renderer rend;
    public GameObject bucketWater;

    private AudioSource source;
    public AudioClip vannetErKokt;

    public GameObject h2o;
    private Renderer vannRend;
    public GameObject planeVann;
    public AudioClip vann;
    bool vannPlayed;

    void Awake()
    {
        boiled = false;
        waterInBucket = false;
        vannPlayed = false;
        rend = bucketWater.GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        vannRend = planeVann.GetComponent<Renderer>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == lake)
        {
            waterInBucket = true;
            rend.enabled = true;
            degrees.text = "2°C";
            EnableWater();
        }
    }

    void OnCollisionEnter(Collision col) { 
        if (col.gameObject == campfire)
        {
            if (boiled == false) { 
                if (waterInBucket == true)
                {
                    degrees.text = "100°C";
                    boiled = true;
                    source.PlayOneShot(vannetErKokt, 1F);
                }
            }
        }
    }

    void EnableWater()
    {
        if (BucketScript.waterInBucket == true)
        {
            if (vannPlayed == false)
            {
                source.PlayOneShot(vann, 1F);
                vannPlayed = true;
                h2o.transform.localScale = new Vector3(2f, 2f, 2f);
                vannRend.enabled = true;
            }
        }
    }
}
