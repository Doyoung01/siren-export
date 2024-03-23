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
    public bool isPlayed;
    public bool obj1_Found;
    public bool obj1_Stop;
    public bool obj2_Found;
    public bool obj2_Stop;

    // Start is called before the first frame update
    void Start()
    {
        boiling.GetComponent<AudioSource>().Stop();
        dryer.GetComponent<AudioSource>().Stop();
        isPlayed = false;
        obj1_Stop = false;
        obj2_Stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Play != false &&  isPlayed != false && hasAppeared != true)
        {
            boiling.GetComponent<AudioSource>().Play();
            boiling.GetComponent<AudioSource>().loop = true;
            dryer.GetComponent<AudioSource>().Play();
            dryer.GetComponent<AudioSource>().loop = true;

            isPlayed = true;
        }
        if(obj1_Found == true && obj1_Stop == false)
        {
            boiling.GetComponent<AudioSource>().Stop();
            obj1_Stop = true;
        }
        if (obj2_Found == true && obj2_Stop == false)
        {
            boiling.GetComponent<AudioSource>().Stop();
            obj2_Stop = true;
        }
        if(hasAppeared == true)
        {
            boiling.GetComponent<AudioSource>().Stop();
            boiling.GetComponent<AudioSource>().Stop();
        }
    }
}
