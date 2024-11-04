using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class IsClear : MonoBehaviour
{
    [Header("All Information Windows")]
    public int infoWindows;
    private bool execute = false;

    [Header("Clear Window")]
    public GameObject clearWindow;

    private GameManager gm;
    private modifyTextMeshPro mtm;

    // Localization
    public LocalizeStringEvent titleLocalizationEvent;
    public LocalizeStringEvent contentLocalizationEvent;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mtm = GameObject.Find("GameManager").GetComponent<modifyTextMeshPro>();

        // 창을 기본적으로 비활성화
        clearWindow.SetActive(false);
    }

    private void Update()
    {
        // 조건을 충족하면 창 활성화 및 로컬라이징 적용
        if (gm.isActiveInfo() && mtm.countChildren() == 0 && !execute && mtm.activeCanvases())
        {
            clearWindow.SetActive(true);
            ApplyLocalization(); // 로컬라이징 적용
            execute = true;
        }
    }

    private void ApplyLocalization()
    {
        if (titleLocalizationEvent != null && contentLocalizationEvent != null)
        {
            titleLocalizationEvent.RefreshString();
            contentLocalizationEvent.RefreshString();
        }
        else
        {
            Debug.LogError("Localization events are not assigned.");
        }
    }
}
