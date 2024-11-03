using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class UserLanguage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickLanguage (int index){
    LocalizationSettings.SelectedLocale = 
        LocalizationSettings.AvailableLocales.Locales [index];
    }
}