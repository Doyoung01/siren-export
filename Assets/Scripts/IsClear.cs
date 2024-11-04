using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class IsClear : MonoBehaviour
{
    [Header("All Information Windows")]
    public List<GameObject> infoWindows; // 인포메이션 창 리스트 (6개의 정보 창을 리스트로 설정)
    private bool flag; // 모든 창이 닫혀 있는지 확인하는 플래그
    private bool execute = false; // 클리어 창이 한 번만 실행되도록 하는 플래그

    [Header("Clear Window")]
    public GameObject clear; // 클리어 창

    private GameManager gm;
    private modifyTextMeshPro mtm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mtm = GameObject.Find("GameManager").GetComponent<modifyTextMeshPro>();

        // 모든 창을 비활성화 상태로 시작
        clear.SetActive(false);
        foreach (var window in infoWindows)
        {
            window.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // GameManager에서 정보 창이 활성화 상태인지 확인
        if (gm.isActiveInfo())
        {
            // 모든 정보 창이 닫혔고, 클리어 창이 아직 실행되지 않았으며 활성화 가능할 때
            if (mtm.countChildren() == 0 && !execute && mtm.activeCanvases())
            {
                // 클리어 창과 모든 정보 창을 활성화
                clear.SetActive(true);
                foreach (var window in infoWindows)
                {
                    window.SetActive(true);
                }

                // 모든 창의 LocalizeStringEvent 새로 고침
                RefreshAllLocalizeStringEvents(clear);
                foreach (var window in infoWindows)
                {
                    RefreshAllLocalizeStringEvents(window);
                }

                execute = true; // 클리어 창이 한 번만 실행되도록 설정
            }
        }
    }

    // 주어진 창의 모든 LocalizeStringEvent 컴포넌트를 새로 고침
    private void RefreshAllLocalizeStringEvents(GameObject window)
    {
        LocalizeStringEvent[] localizeEvents = window.GetComponentsInChildren<LocalizeStringEvent>(true);
        foreach (var localizeEvent in localizeEvents)
        {
            localizeEvent.RefreshString();
        }
    }
}

