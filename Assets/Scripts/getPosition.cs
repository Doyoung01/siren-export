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
    public RectTransform bottom;
    public RectTransform fail;

    // value of the dynamic canvas
    private float height = 0;

    public TMP_Text content;

    private static float gap = 40.25f;
    private static float original = 0;
    private static int loop = 0;

    void Start()
    {
        // Restart Canvas Component Script
        height = rect.sizeDelta.y;
        original = height;

        Debug.Log(height);
    }

    void Update()
    {
        // height of dynamic panel
        height = rect.sizeDelta.y;

        // if the height is changed
        if (height > original && loop <= wordCount(content.text, "\n"))
        {
            // leftbar.sizeDelta = new Vector2(leftbar.sizeDelta.x, leftbar.sizeDelta.y + gap);
            // rightbar.sizeDelta = new Vector2(rightbar.sizeDelta.x, rightbar.sizeDelta.y + gap);

            top.position = new Vector3(top.transform.position.x, top.transform.position.y + gap, top.transform.position.z);
            bottom.position = new Vector3(bottom.transform.position.x, bottom.transform.position.y - gap, bottom.transform.position.z);

            fail.transform.position = new Vector2(fail.transform.position.x, fail.transform.position.y + gap);

            loop++;

            Debug.Log(gap + " " + height + loop);
        } else if (height > original && loop > wordCount(content.text, "\n"))
        {
            // leftbar. = new Vector2(leftbar.rect.x, leftbar.rect.y - gap);
            // rightbar.sizeDelta = new Vector2(rightbar.rect.x, rightbar.rect.y - gap);

            top.position = new Vector3(top.transform.position.x, top.transform.position.y - gap, top.transform.position.z);
            bottom.position = new Vector3(bottom.transform.position.x, bottom.transform.position.y + gap, bottom.position.z);

            fail.transform.position = new Vector2(fail.transform.position.x, fail.transform.position.y - gap);

            loop--;

            Debug.Log(gap + " " + height + loop);
        }
    }

    private int wordCount(string s, string word)
    {
        string[] stringArray = s.Split(new string[] { word }, System.StringSplitOptions.None);
        return stringArray.Length - 1;
    }
}
