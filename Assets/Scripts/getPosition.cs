using System.Collections;
using UnityEngine;
using TMPro;

public class getPosition : MonoBehaviour
{
    public RectTransform rect;
    public RectTransform leftbar;
    public RectTransform rightbar;
    public RectTransform top;
    public RectTransform panel;
    public RectTransform bottom;

    public TMP_Text contentText;

    // 동적 캔버스의 기본값 변수
    private float originHeight = 0;
    private int lineCount = 0;

    public RectTransform content;

    private Vector2 leftbarInitialSize;
    private Vector2 rightbarInitialSize;
    private Vector2 panelInitialSize;

    private static float gap;

    void Start()
    {
        // 초기값 설정
        leftbarInitialSize = leftbar.sizeDelta;
        rightbarInitialSize = rightbar.sizeDelta;
        panelInitialSize = panel.sizeDelta;

        // 시작 시 원래의 content 높이 저장
        originHeight = content.rect.height;
        lineCount = CountLines(contentText.text, "\n") + 1;
    }

    void Update()
    {
        // 현재 content 높이 확인
        float currentHeight = content.rect.height;

        // 텍스트 줄 수와 높이 차이(gap) 계산
        lineCount = CountLines(contentText.text, "\n");
        gap = (currentHeight - originHeight) / 2;

        // 높이에 변화가 있을 때만 업데이트 수행
        if (Mathf.Abs(gap) > 0.1f) // gap이 일정 값 이상일 때만 업데이트
        {
            // 각 요소의 높이 조정
            leftbar.sizeDelta = new Vector2(leftbarInitialSize.x, leftbarInitialSize.y + gap);
            rightbar.sizeDelta = new Vector2(rightbarInitialSize.x, rightbarInitialSize.y + gap);
            panel.sizeDelta = new Vector2(panelInitialSize.x, panelInitialSize.y + gap);

            // top과 bottom의 위치 조정
            top.localPosition += new Vector3(0, gap, 0);
            bottom.localPosition += new Vector3(0, -gap, 0);

            // originHeight를 현재 높이로 업데이트
            originHeight = currentHeight;

            Debug.Log("Line count: " + lineCount + ", Gap: " + gap + ", Total height adjustment: " + gap * lineCount);
        }
    }

    // contentText.text의 줄 수를 세는 메서드
    private int CountLines(string text, string delimiter)
    {
        string[] lines = text.Split(new string[] { delimiter }, System.StringSplitOptions.None);
        return lines.Length - 1;
    }
}

