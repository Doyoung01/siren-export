using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.ParticleSystemModule;
#endif

public class fireScale : MonoBehaviour
{
    public GameObject fire;

    [SerializeField, Range(0f, 1f)] private float currentIntensity = 1.0f;
    private float startIntensity = 0f;

    [SerializeField] private ParticleSystem firePS = null;

    private float time = 0f;

    private void Start()
    {
        startIntensity = firePS.emission.rateOverTime.constant;
        UnityEngine.Debug.Log(startIntensity);
    }

    private void Update()
    {
        ChangeIntensity();
    }

    private void ChangeIntensity()
    {
        var emission = firePS.emission;
        emission.rateOverTime = currentIntensity * startIntensity;
    }

    /*
     * if(fire.activeSelf)
        {
            time = 0;
            time += Time.deltaTime;
            var emission = firePS.emission;
            emission.rateOverTime = currentIntensity * (0.001f * time);
            
        }
     */
}
