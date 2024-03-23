using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClear : MonoBehaviour
{
    // All Info Canvas에 해당 스크립트를 추가할 것
    [Header("All Information Windows")]
    public int infoWindows; // 모든 인포창 개수
    private bool flag; // 모두 비활성화 됐는가?
    private bool execute = false; // 스크립트가 한 번 실행되었는가?

    [Header("Clear Window")]
    public GameObject clear; // 클리어창

    private GameObject tmpObject;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        tmpObject = GameObject.Find("GameManager");
        gm = tmpObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isActiveInfo())
        {
            if (checkingActive() && !execute)
            {
                clear.SetActive(true);
                execute = true;
            }
        }
    }

    private bool checkingActive()
    {
        flag = true;

        for (int i = 0; i < infoWindows; i++)
        {
            // Debug.Log("infoW : " + infoWindows + ", i : " + i);
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                // Debug.Log(transform.GetChild(i).gameObject.name);
                flag = false;
                break;
            }
        }

        return flag;
    }
}
