using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClear : MonoBehaviour
{
    [Header("All Information Windows")]
    public GameObject InformationCanvas_Restaurant; // �θ� ������Ʈ (All Info Canvas)
    public int infoWindows; // ��Ȱ��ȭ�Ǿ�� �ϴ� ���� â ����
    private bool execute = false; // ��ũ��Ʈ�� �� �� ����Ǿ��°�?

    [Header("Clear Window")]
    public GameObject clear; // Ŭ����â

    private GameManager gm;
    private modifyTextMeshPro mtm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mtm = GameObject.Find("GameManager").GetComponent<modifyTextMeshPro>();
    }

    void Update()
    {
        // Step 1: InformationCanvas_Restaurant�� ��Ȱ��ȭ�� �ڽ� ������Ʈ ���� infoWindows�� ������ Ȯ��
        if (CountInactiveChildren() >= infoWindows && !execute)
        {
            clear.SetActive(true); // Ŭ���� â Ȱ��ȭ
            execute = true; // ��ũ��Ʈ�� �� �� ����Ǿ����� ǥ��
        }
    }

    // ��Ȱ��ȭ�� �ڽ� ������Ʈ�� ������ ���� �޼���
    private int CountInactiveChildren()
    {
        int inactiveCount = 0;

        foreach (Transform child in InformationCanvas_Restaurant.transform)
        {
            if (!child.gameObject.activeSelf) // �ڽ��� ��Ȱ��ȭ ������ ���
            {
                inactiveCount++;
            }
        }

        return inactiveCount; // ��Ȱ��ȭ�� �ڽ� ������Ʈ �� ��ȯ
    }
}
