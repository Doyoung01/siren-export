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

    private GameManager gm;
    private modifyTextMeshPro mtm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mtm = GameObject.Find("GameManager").GetComponent<modifyTextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isActiveInfo())
        {
            if (mtm.countChildren() == 0 && !execute && mtm.activeCanvases())
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
            if(this.transform.childCount != 0) {
            flag = false;
                break;
            }
        }

        return flag;
    }
}
