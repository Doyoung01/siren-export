using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class LocalizeOnEnable : MonoBehaviour
{
    public LocalizeStringEvent titleLocalizationEvent;
    public LocalizeStringEvent contentLocalizationEvent;

    void OnEnable()
    {
        RefreshLocalization();
    }

    void Start()
    {
        RefreshLocalization();
    }

    void RefreshLocalization()
    {
        if (titleLocalizationEvent != null)
        {
            titleLocalizationEvent.RefreshString();
        }

        if (contentLocalizationEvent != null)
        {
            contentLocalizationEvent.RefreshString();
        }
    }
}
