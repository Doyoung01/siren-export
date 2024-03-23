using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayTimeMain : MonoBehaviour
{
    [SerializeField] private Text TextTime;
    private bool Timebool = true;
    public int DelayCount = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���� ������ ������ 0 �̶��

        if (DelayCount == 0)
        {
            //�ڷ�ƾ ����

            StopCoroutine("TimeDelay");
        }

        //���� ���� ������ �� �̶��

        if (Timebool)
        {
            //�ڷ�ƾ ȣ��

            StartCoroutine("TimeDelay");
        }

    }
    IEnumerator TimeDelay()

    {

        Timebool = false;

        //UI Text�� ������ ���� ����

        TextTime.text = DelayCount.ToString();



        //1�� ��

        yield return new WaitForSeconds(1.0f);

        Debug.Log(DelayCount);

        //������ ���� 1����

        DelayCount--;

        //���� ������ ������ 0�̸�

        if (DelayCount == 0)

        {

            //�ؽ�Ʈ �ǳ��� ������� ��

            GameObject.Find("TimePanel").SetActive(false);

        }

        //�ٽ� ���� ���� ������ �ڷ�ƾ ȣ��

        Timebool = true;

    }
}
