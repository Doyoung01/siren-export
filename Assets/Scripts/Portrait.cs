using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Portrait : MonoBehaviour
{
    public RectTransform rect; // 전체적인 return canvas
    public RectTransform left; // 왼쪽 이미지 바
    public RectTransform right; // 오른쪽 이미지 바
    private GameManager gm;
    private Objectcount oc;
    public TMP_Text hintText;
    private int gap = 50;

    Dictionary<string, int> objectName = new Dictionary<string, int>(); // 상호작용한 아이템의 이름
    private string[] names;

    string[] fhintString = {
        "불에 잘 타는 물건이... 공장에?", "어우, 이 매캐한 냄새는 뭐야?", 
        "콜록콜록! 공기가 너무 안 좋은데...", "여기 좀 많이 덥지 않아? 원래 이렇게 뜨겁지 않았는데...",
        "어우, 시끄러워! 이 쇠소리는 뭐야?", "어디서 타닥타닥 소리가 나는데?",
        "여기 있던 소화기 어디갔어?"
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
        // 게임 플레이 진행중일 때 상호작용한 아이템의 이름을 저장
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
        // 게임 클리어에 실패했을 때 캔버스에 힌트를 띄움
        else if (!gm.getIsclear() && gm.getReturnCanvasActive())
        {
            int play = 0;
            int num = PlayerPrefs.GetInt("PlayCount", play); // 플레이 횟수를 불러옴

            for (int i = 0; i < num; i++)
            {
                // 상호작용 하지 않았고
                // 이미 써져있는 문구가 아닌
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
