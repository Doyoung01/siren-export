using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
//����
public class Objectcount : MonoBehaviour
{
    private int count;
    private GameObject[] obcount;
    public Text Score_count;

    // XR Ray Interactor�� ���� ����
    public XRRayInteractor rightrayInteractor; 
    public XRRayInteractor leftrayInteractor;

    [Header("Interactive Objects")]
    public GameObject empty;        // ��ȣ�ۿ� �� ����� ������Ʈ���� afterobj�� EmptyObject(empty) �ֱ�
    public GameObject[] beforeobj;  // ��ȣ�ۿ� �� ������Ʈ
    public GameObject[] afterobj;   // ��ȣ�ۿ� �� ������Ʈ

    private string interact;

    public string getName()
    {
        return interact;
    }

    public int getCount()
    {
        return count;
    }

    public int getObcount()
    {
        return obcount.Length;
    }

    private void Start()
    {
        rightrayInteractor.selectEntered.AddListener(OnSelectEntered);
        leftrayInteractor.selectEntered.AddListener(OnSelectEntered);

        count = 0;
        obcount = GameObject.FindGameObjectsWithTag("GameController");
        Score_count = GameObject.Find("Score_count").GetComponent<Text>();
    }

    private void Update()
    {
        Score_count.text = count + " / " + obcount.Length;
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed: " + args.interactableObject.transform.gameObject.name);

        // ���õ� ������Ʈ�� ���ϴ� Ÿ���̳� �±׸� ������ �ִ��� Ȯ��
        if (args.interactableObject.transform.CompareTag("GameController"))
        {
            Debug.Log("check tag");

            for(int i = 0; i < obcount.Length; i++)
            {
                if (args.interactableObject.transform.gameObject == beforeobj[i])
                {
                    interact = args.interactableObject.transform.name;
                    if (afterobj[i] == empty)
                    {
                        beforeobj[i].SetActive(false);
                    } else
                    {
                        beforeobj[i].SetActive(false);
                        afterobj[i].SetActive(true);
                    }
                    SetCountText();
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (rightrayInteractor != null || leftrayInteractor != null)
        {
            rightrayInteractor.selectEntered.RemoveListener(OnSelectEntered);
            leftrayInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void SetCountText()
    {
        count++;
        Score_count.text = count + " / " + obcount.Length;
    }
}