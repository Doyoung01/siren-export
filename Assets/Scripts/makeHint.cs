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

    //   ȣ ۿ              ̸ 
    Dictionary<int, string> objectName = new Dictionary<int, string>();
    //   ȣ ۿ              ε     ѹ 
    Dictionary<string, int> factory = new Dictionary<string, int>();
    Dictionary<string, int> restaurant = new Dictionary<string, int>();
    Dictionary<string, int> house = new Dictionary<string, int>();
    string[] fhintString = {
        "오 이런! 어디선가 연기가 나는 것 같은데... 공장에서?",
        "음, 저 소화기가 작동하고 있을까?",
        "조심해! 저 기계가 너무 뜨거워 보이는데...",
        "가스를 껐나요? 무언가 새고 있는 것 같아요...",
        "오 이런! 저 담배 꽁초가 아직 타고 있는 건가요?",
        "불 근처에 종이가 있나요?",
        "불 근처에 가연성 물질이 있나요?"
    };
    string[] rhintString = {
        "수건을 어디다 뒀더라..?",
        "어디서 기름 냄새가 나는데..?",
        "왜 썩은 달걀 냄새가 나지..",
        "매장이 너무 써늘한데.",
        "소화기가 이상하다..?",
        "후드에서 기름이 떨어져...!"
    };
    string[] hhintString = {
	    "어디서 타는 냄새가..?",
	    "아직도 타는 냄새가 나는데..!",
        "나갈때 콘센트를 껐었나?",
        "주방에서 아직도 담배냄새가 나네.",
        "화장실에서 무슨 소리가..",
	"아침에 침대에서 전기장판을 껐었나..?"
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
        } else if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            restaurantObjectNames();
        } else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            houseObjectNames();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            makeHints(2);
        } else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            makeHints(3);
        } else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            makeHints(4);
        }
        
    }

    public void makeHints(int scene)
    {
        if(scene == 2)
        {
            //       ÷                  ȣ ۿ              ̸        
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(factory[objName]))
                {
                    // Add( ش    ȣ ۿ        Ʈ           ѹ ,  ׿         Ʈ     )
                    objectName.Add(factory[objName], fhintString[factory[objName]]);
                }
            }
            //      Ŭ                ĵ         Ʈ      
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play); //  ÷    Ƚ      ҷ   
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                PlayerPrefs.SetInt("PlayCount", num + 1);
                PlayerPrefs.SetInt("Loop", 1);

                Debug.Log("this is num: " + num);

                if (num < 13 && isloop != 1)
                {
                    for (int i = 0; i < num && i < fhintString.Length; i++)
                    {
                        //   ȣ ۿ        ʾҰ 
                        //  ̹       ִ          ƴ 
                        if (!(objectName.ContainsKey(i)))
                            hintText.text += fhintString[i] + "\n";
                    }
                }
            }
        }
        else if (scene == 3)
        {
            //       ÷                  ȣ ۿ              ̸        
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(restaurant[objName]))
                {
                    // Add( ش    ȣ ۿ        Ʈ           ѹ ,  ׿         Ʈ     )
                    objectName.Add(restaurant[objName], rhintString[restaurant[objName]]);
                }
            }
            //      Ŭ                ĵ         Ʈ      
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play); //  ÷    Ƚ      ҷ   
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                PlayerPrefs.SetInt("PlayCount", num + 1);
                PlayerPrefs.SetInt("Loop", 1);

                Debug.Log("this is num: " + num);

                if (num < 13 && isloop != 1)
                {
                    for (int i = 0; i < num && i < rhintString.Length; i++)
                    {
                        //   ȣ ۿ        ʾҰ 
                        //  ̹       ִ          ƴ 
                        if (!(objectName.ContainsKey(i)))
                            hintText.text += rhintString[i] + "\n";
                    }
                }
            }
        } else if (scene == 4)
        {
            //       ÷                  ȣ ۿ              ̸        
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(house[objName]))
                {
                    // Add( ش    ȣ ۿ        Ʈ           ѹ ,  ׿         Ʈ     )
                    objectName.Add(house[objName], hhintString[house[objName]]);
                }
            }
            //      Ŭ                ĵ         Ʈ      
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play); //  ÷    Ƚ      ҷ   
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                PlayerPrefs.SetInt("PlayCount", num + 1);
                PlayerPrefs.SetInt("Loop", 1);

                Debug.Log("this is num: " + num);

                if (num < 13 && isloop != 1)
                {
                    for (int i = 0; i < num && i < hhintString.Length; i++)
                    {
                        //   ȣ ۿ        ʾҰ 
                        //  ̹       ִ          ƴ 
                        if (!(objectName.ContainsKey(i)))
                            hintText.text += hhintString[i] + "\n";
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
    
    private void restaurantObjectNames()
    {
        restaurant.Add("Ventilator", 0);
        restaurant.Add("Air conditioner", 1);
        restaurant.Add("Dishcloth", 2);
        restaurant.Add("Gas pipe", 3);
        restaurant.Add("Fryer", 4);
        restaurant.Add("Fireextinguisher_Gen", 5);
    }

    private void houseObjectNames()
    {
        house.Add("Smoke3", 0);
        house.Add("powerBar", 1);
        house.Add("electricBlanket", 2);
        house.Add("Hairdryer", 3);
        house.Add("Toaster", 4);
        house.Add("deeppan", 5);
    }
}


