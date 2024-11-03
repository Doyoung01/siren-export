using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager_h : MonoBehaviour
{
    public GameManager Play;
    public GameManager hasAppeared;
    public GameObject boiling;
    public GameObject dryer;
    public GameObject blanket;
    public GameObject smoke;
    public GameObject powerbar;
    public bool isPlayed;
    public bool obj1_Found;
    public bool obj1_Stop;
    public bool obj2_Found;
    public bool obj2_Stop;
    public bool obj3_Found; // blanket 관련 변수
    public bool obj3_Stop;  // blanket 관련 변수
    public bool obj4_Found; // smoke 관련 변수
    public bool obj4_Stop;  // smoke 관련 변수
    public bool obj5_Found; // powerbar 관련 변수
    public bool obj5_Stop;  // powerbar 관련 변수

    // Start is called before the first frame update
    void Start()
    {
        boiling.GetComponent<AudioSource>().Stop();
        dryer.GetComponent<AudioSource>().Stop();
        blanket.GetComponent<AudioSource>().Stop();
        smoke.GetComponent<AudioSource>().Stop();
        powerbar.GetComponent<AudioSource>().Stop();

        isPlayed = false;
        obj1_Stop = false;
        obj2_Stop = false;
        obj3_Stop = false;
        obj4_Stop = false;
        obj5_Stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Main audio play control
        if (Play != null && Play.getIsclear() && !isPlayed && !hasAppeared.getReturnCanvasActive())
        {
            boiling.GetComponent<AudioSource>().Play();
            boiling.GetComponent<AudioSource>().loop = true;
            dryer.GetComponent<AudioSource>().Play();
            dryer.GetComponent<AudioSource>().loop = true;
            blanket.GetComponent<AudioSource>().Play();
            blanket.GetComponent<AudioSource>().loop = true;
            smoke.GetComponent<AudioSource>().Play();
            smoke.GetComponent<AudioSource>().loop = true;
            powerbar.GetComponent<AudioSource>().Play();
            powerbar.GetComponent<AudioSource>().loop = true;

            isPlayed = true;
        }

        // Stopping specific objects' audio if found
        if (obj1_Found && !obj1_Stop)
        {
            boiling.GetComponent<AudioSource>().Stop();
            obj1_Stop = true;
        }
        if (obj2_Found && !obj2_Stop)
        {
            dryer.GetComponent<AudioSource>().Stop();
            obj2_Stop = true;
        }
        if (obj3_Found && !obj3_Stop)
        {
            blanket.GetComponent<AudioSource>().Stop();
            obj3_Stop = true;
        }
        if (obj4_Found && !obj4_Stop)
        {
            smoke.GetComponent<AudioSource>().Stop();
            obj4_Stop = true;
        }
        if (obj5_Found && !obj5_Stop)
        {
            powerbar.GetComponent<AudioSource>().Stop();
            obj5_Stop = true;
        }

        // Stopping all audios if hasAppeared is true
        if (hasAppeared != null && hasAppeared.getReturnCanvasActive())
        {
            boiling.GetComponent<AudioSource>().Stop();
            dryer.GetComponent<AudioSource>().Stop();
            blanket.GetComponent<AudioSource>().Stop();
            smoke.GetComponent<AudioSource>().Stop();
            powerbar.GetComponent<AudioSource>().Stop();
        }
    }
}

