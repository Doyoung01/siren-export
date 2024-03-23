using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClear : MonoBehaviour
{
    // All Info Canvas�� �ش� ��ũ��Ʈ�� �߰��� ��
    [Header("All Information Windows")]
    public int infoWindows; // ��� ����â ����
    private bool flag; // ��� ��Ȱ��ȭ �ƴ°�?
    private bool execute = false; // ��ũ��Ʈ�� �� �� ����Ǿ��°�?

    [Header("Clear Window")]
    public GameObject clear; // Ŭ����â

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
