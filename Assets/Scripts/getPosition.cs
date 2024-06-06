using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
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

    // value of the dynamic canvas
    private float origin = 0;
    private float count = 0;

    public RectTransform content;

    private Vector2 leftbarInitialSize;
    private Vector2 rightbarInitialSize;
    private Vector3 panelInitialSize;

    private static float gap;

    void Start()
    {
        // 초기값 설정
        leftbarInitialSize = leftbar.sizeDelta;
        rightbarInitialSize = rightbar.sizeDelta;
        panelInitialSize = panel.sizeDelta;

        // Restart Canvas Component Script
        origin = content.rect.height;
        count = wordCount(contentText.text, "\n") + 1;
    }

    void Update()
    {
        // height of dynamic panel
        var currentHeight = content.rect.height;
        
        count = wordCount(contentText.text, "\n");
        gap = (currentHeight - origin) / 2;

        // if the height is changed
        if (gap != 0)
        {
            leftbar.sizeDelta = new Vector2(leftbarInitialSize.x, leftbarInitialSize.y + gap);
            rightbar.sizeDelta = new Vector2(rightbarInitialSize.x, rightbarInitialSize.y + gap);
            panel.sizeDelta = new Vector2(panelInitialSize.x, panelInitialSize.y + gap);

            top.localPosition += new Vector3(0, gap, 0);
            bottom.localPosition += new Vector3(0, -gap, 0);

            origin = currentHeight;

            Debug.Log("count: "+count + " gap: " + gap + "gapcount " + gap*count);
        }
    }

    // contentText.text에 "\n"이 몇 개가 포함되어 있는지 계산
    private int wordCount(string s, string word)
    {
        string[] stringArray = s.Split(new string[] { word }, System.StringSplitOptions.None);
        return stringArray.Length - 1;
    }
}
