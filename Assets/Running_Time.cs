using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Running_Time : MonoBehaviour
{
    private float Timer;
    private Text text;
    private DelayTimeMain DelayCount;
    // Start is called before the first frame update
    void Start()
    {
        DelayCount = GameObject.Find("Canvas").GetComponent<DelayTimeMain>();

        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ǽð� Time.deltaTime �ʱ�ȭ.

        Timer = Timer + Time.deltaTime;

        //�Ǽ��� ���� ù��° �ڸ����� �����Ͽ� UI Text �� ����ȭ

        text.text = string.Format("", Timer);
    }
}
