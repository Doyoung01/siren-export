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
    public XRRayInteractor rayInteractor; // XR Ray Interactor�� ���� ����
    private GameManager gm;

    [Header("Interactive Objects")]
    public GameObject empty;
    public GameObject[] beforeobj;
    public GameObject[] afterobj;
    /*
     * public GameObject FireLeft;
    public GameObject FireRight;
    public GameObject BoxLeft;
    public GameObject BoxLeft2;
    public GameObject Box;
    public GameObject Cigarette;
    */

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
        Debug.Log("hi");
        rayInteractor.selectEntered.AddListener(OnSelectEntered);

        count = 0;
        obcount = GameObject.FindGameObjectsWithTag("GameController");
        Score_count = GameObject.Find("Score_count").GetComponent<Text>();
        gm = GetComponent<GameManager>();
        // Score_count.text = count + " / " + obcount.Length;
        /*
         * for(int i=0; i<16;  i++)
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("GameController")[i].name);
        }
         */
    }

    private void Update()
    {
        if(gm.timeText.color == Color.green)
        {
            Score_count.text = count + " / " + obcount.Length;
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed: " + args.interactable.transform.gameObject.name);

        // ���õ� ������Ʈ�� ���ϴ� Ÿ���̳� �±׸� ������ �ִ��� Ȯ���մϴ�.
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
        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void SetCountText()
    {
        count++;
        Score_count.text = count + " / " + obcount.Length;
    }
}