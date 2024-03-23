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
        //실시간 Time.deltaTime 초기화.

        Timer = Timer + Time.deltaTime;

        //실수형 변수 첫번째 자리까지 포맷하여 UI Text 로 가시화

        text.text = string.Format("", Timer);
    }
}
