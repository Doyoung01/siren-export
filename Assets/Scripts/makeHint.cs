using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class makeHint : MonoBehaviour
{
    private GameManager gm;
    private Objectcount oc;
    public TMP_Text hintText;

    Dictionary<int, string> objectName = new Dictionary<int, string>(); // 상호작용한 아이템의 이름
    Dictionary<string, int> factory = new Dictionary<string, int>();    // 상호작용한 아이템의 인덱스 넘버
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

        PlayerPrefs.SetInt("PlayCount", 0);
        PlayerPrefs.SetInt("Loop", 0);

        if(SceneManager.GetActiveScene().buildIndex == 2 )
        {
            factoryObjectNames();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            makeHints(2);
        }
        
    }

    public void makeHints(int scene)
    {
        if(scene == 2)
        {
            // 게임 플레이 진행중일 때 상호작용한 아이템의 이름을 저장
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(factory[objName]))
                {
                    // Add(해당 상호작용 오브젝트에 설정된 넘버, 그에 관한 힌트 설명)
                    objectName.Add(factory[objName], fhintString[factory[objName]]);
                }
            }
            // 게임 클리어에 실패했을 때 캔버스에 힌트를 띄움
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play); // 플레이 횟수를 불러옴
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                PlayerPrefs.SetInt("PlayCount", num + 1);
                PlayerPrefs.SetInt("Loop", 1);

                Debug.Log("this is num: " + num);

                if (num < 13 && isloop != 1)
                {
                    for (int i = 0; i < num && i < fhintString.Length; i++)
                    {
                        // 상호작용 하지 않았고
                        // 이미 써져있는 문구가 아닌
                        if (!(objectName.ContainsKey(i)))
                        {
                            hintText.text += fhintString[i] + "\n";
                        }
                    }
                }
            }
        }
    }

    public TMP_Text returnHints()
    {
        return hintText;
    }

    private void factoryObjectNames()
    {
        factory.Add("Boxes", 0);
        factory.Add("Boxes1", 0);
        factory.Add("Boxes2", 0);
        factory.Add("rightBoxSet", 0);
        factory.Add("leftBoxSet2", 0);
        factory.Add("leftBoxSet3", 0);

        factory.Add("CigaretteSet", 1);

        factory.Add("DustCollector1", 2);
        factory.Add("DustCollector2", 2);
        factory.Add("DustCollector3", 2);

        factory.Add("OverheatingRobot", 3);
        factory.Add("CollisionRobots", 4);

        factory.Add("weldingTable", 5);

        factory.Add("fireLeft", 6);
        factory.Add("fireRight", 6);
    }
}
