using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getPosition : MonoBehaviour
{
    public RectTransform rect;
    public RectTransform leftbar;
    public RectTransform rightbar;
    public RectTransform top;
    public RectTransform panel;
    public RectTransform bottom;

    public TMP_Text contentText;
    public RectTransform content;

    private float initialHeight;

    void Start()
    {
        // 초기 content 높이를 저장
        initialHeight = content.rect.height;
    }

    void Update()
    {
        // 현재 content 높이를 가져와서 초기 높이와 비교
        float currentHeight = content.rect.height;
        float heightDifference = currentHeight - initialHeight;

        if (Mathf.Abs(heightDifference) > 0.01f)
        {
            AdjustUIElements(heightDifference);
            initialHeight = currentHeight;  // 초기 높이를 업데이트하여 무한 업데이트 방지
        }
    }

    private void AdjustUIElements(float heightDifference)
    {
        // leftbar, rightbar, panel의 높이를 높이 차이에 맞게 업데이트
        leftbar.sizeDelta = new Vector2(leftbar.sizeDelta.x, leftbar.sizeDelta.y + heightDifference);
        rightbar.sizeDelta = new Vector2(rightbar.sizeDelta.x, rightbar.sizeDelta.y + heightDifference);
        panel.sizeDelta = new Vector2(panel.sizeDelta.x, panel.sizeDelta.y + heightDifference);

        // top과 bottom의 위치를 높이 차이에 맞게 업데이트
        top.localPosition += new Vector3(0, heightDifference / 2, 0);
        bottom.localPosition += new Vector3(0, -heightDifference / 2, 0);
    }
}

