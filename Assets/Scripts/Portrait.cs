using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Portrait : MonoBehaviour
{
    public RectTransform rect; // ��ü���� return canvas
    public RectTransform left; // ���� �̹��� ��
    public RectTransform right; // ������ �̹��� ��
    private GameManager gm;
    private Objectcount oc;
    public TMP_Text hintText;
    private int gap = 50;

    Dictionary<string, int> objectName = new Dictionary<string, int>(); // ��ȣ�ۿ��� �������� �̸�
    private string[] names;

    string[] fhintString = {
        "�ҿ� �� Ÿ�� ������... ���忡?", "���, �� ��ĳ�� ������ ����?", 
        "�ݷ��ݷ�! ���Ⱑ �ʹ� �� ������...", "���� �� ���� ���� �ʾ�? ���� �̷��� �߰��� �ʾҴµ�...",
        "���, �ò�����! �� ��Ҹ��� ����?", "��� Ÿ��Ÿ�� �Ҹ��� ���µ�?",
        "���� �ִ� ��ȭ�� ��𰬾�?"
    };
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        oc = GameObject.Find("GameManager").GetComponent<Objectcount>();

        rect = GetComponent<RectTransform>();
        left = transform.GetChild(1).GetComponent<RectTransform>();
        right = transform.GetChild(2).GetComponent<RectTransform>();

        setSizeDelta(rect, 989, 229);
        setHeight(left, 150);
        setHeight(right, 150);
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �÷��� �������� �� ��ȣ�ۿ��� �������� �̸��� ����
        if(!gm.getReturnCanvasActive() && oc.getCount() <= oc.getObcount())
        {
            names = oc.getInteractableObjects();
            for (int i=0; i<oc.getObcount(); i++)
            {
                if (!objectName.ContainsKey(names[i]))
                {
                    objectName.Add(names[i], i);
                }
            }
        }
        // ���� Ŭ��� �������� �� ĵ������ ��Ʈ�� ���
        else if (!gm.getIsclear() && gm.getReturnCanvasActive())
        {
            int play = 0;
            int num = PlayerPrefs.GetInt("PlayCount", play); // �÷��� Ƚ���� �ҷ���

            for (int i = 0; i < num; i++)
            {
                // ��ȣ�ۿ� ���� �ʾҰ�
                // �̹� �����ִ� ������ �ƴ�
                foreach(int j in objectName.Values)
                {
                    if (!(i == j))
                    {
                        hintText.text += "\n" + fhintString[i];
                        setHeight(left, 150 + gap * i);
                        setHeight(right, 150 + gap * i);
                    }
                }
            }
        }
    }

    private void setWidth(RectTransform rect, float width)
    {
        rect.sizeDelta= new Vector2(width, rect.sizeDelta.y);
    }

    private void setHeight(RectTransform rect, float height)
    {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, height);
    }

    private void setSizeDelta(RectTransform rect, float width, float height)
    {
        rect.sizeDelta = new Vector2(width, height);
    }
}
