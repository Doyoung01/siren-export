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

    private GameManager gm;

    [Header("Interactive Objects")]
    public GameObject empty;        // ��ȣ�ۿ� �� ����� ������Ʈ���� afterobj�� EmptyObject(empty) �ֱ�
    public GameObject[] beforeobj;  // ��ȣ�ۿ� �� ������Ʈ
    public GameObject[] afterobj;   // ��ȣ�ۿ� �� ������Ʈ

    string[] interactableObjects = null;

    public string[] getInteractableObjects()
    {
        return interactableObjects;
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
        gm = GetComponent<GameManager>();
    }

    private void Update()
    {
        Score_count.text = count + " / " + obcount.Length;
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed: " + args.interactable.transform.gameObject.name);

        // ���õ� ������Ʈ�� ���ϴ� Ÿ���̳� �±׸� ������ �ִ��� Ȯ��
        if (args.interactableObject.transform.CompareTag("GameController"))
        {
            Debug.Log("check tag");

            for(int i = 0; i < obcount.Length; i++)
            {
                if (args.interactableObject.transform.gameObject == beforeobj[i])
                {
                    if(afterobj[i] == empty)
                    {
                        beforeobj[i].SetActive(false);
                        interactableObjects[i] = args.interactable.transform.gameObject.name;
                    } else
                    {
                        beforeobj[i].SetActive(false);
                        afterobj[i].SetActive(true);
                        interactableObjects[i] = args.interactable.transform.gameObject.name;
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