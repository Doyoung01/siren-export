using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClear : MonoBehaviour
{
    [Header("All Information Windows")]
    public GameObject InformationCanvas_Restaurant; // 부모 오브젝트 (All Info Canvas)
    public int infoWindows; // 비활성화되어야 하는 정보 창 개수
    private bool execute = false; // 스크립트가 한 번 실행되었는가?

    [Header("Clear Window")]
    public GameObject clear; // 클리어창

    private GameManager gm;
    private modifyTextMeshPro mtm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mtm = GameObject.Find("GameManager").GetComponent<modifyTextMeshPro>();
    }

    void Update()
    {
        // Step 1: InformationCanvas_Restaurant의 비활성화된 자식 오브젝트 수가 infoWindows와 같은지 확인
        if (CountInactiveChildren() >= infoWindows && !execute)
        {
            clear.SetActive(true); // 클리어 창 활성화
            execute = true; // 스크립트가 한 번 실행되었음을 표시
        }
    }

    // 비활성화된 자식 오브젝트의 개수를 세는 메서드
    private int CountInactiveChildren()
    {
        int inactiveCount = 0;

        foreach (Transform child in InformationCanvas_Restaurant.transform)
        {
            if (!child.gameObject.activeSelf) // 자식이 비활성화 상태일 경우
            {
                inactiveCount++;
            }
        }

        return inactiveCount; // 비활성화된 자식 오브젝트 수 반환
    }
}
