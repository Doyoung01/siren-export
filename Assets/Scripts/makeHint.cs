using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class makeHint : MonoBehaviour
{
    private GameManager gm;
    private Objectcount oc;
    public TMP_Text hintText;

    Dictionary<int, string> objectName = new Dictionary<int, string>();
    Dictionary<string, int> factory = new Dictionary<string, int>();
    Dictionary<string, int> restaurant = new Dictionary<string, int>();
    Dictionary<string, int> house = new Dictionary<string, int>();

    // 한국어 및 영어 힌트 배열
    string[] fhintString_ko = {
        "오 이런! 어디선가 연기가 나는 것 같은데... 공장에서?",
        "음, 저 소화기가 작동하고 있을까?",
        "조심해! 저 기계가 너무 뜨거워 보이는데...",
        "가스를 껐나요? 무언가 새고 있는 것 같아요...",
        "오 이런! 저 담배 꽁초가 아직 타고 있는 건가요?",
        "불 근처에 종이가 있나요?",
        "불 근처에 가연성 물질이 있나요?"
    };

    string[] fhintString_en = {
        "Oops! It seems like there's smoke coming from somewhere... In the factory?",
        "Hmm, is that fire extinguisher working?",
        "Careful! That machine looks really hot...",
        "Did you turn off the gas? Something seems like it's leaking...",
        "Oh no! Is that cigarette smoldering?",
        "Is there any paper near the flames?",
        "Are there any flammable objects near the fire?"
    };

    string[] rhintString_ko = {
        "후드에서 기름이 떨어져...!",
        "매장이 너무 써늘한데.",
        "수건을 어디다 뒀더라..?",
        "왜 썩은 달걀 냄새가 나지..",
	    "어디서 기름 냄새가 나는데..?",
        "소화기가 이상하다..?"
    };

    string[] rhintString_en = {
        "There's oil dripping from the hood...!",
        "It's too cold in the store.",
        "Where did I put the towel..?",
        "Why does it smell like rotten eggs..?",
        "Where is that smell of oil coming from..?",
        "Is there something wrong with the fire extinguisher..?",
    };

    string[] hhintString_ko = {
        "주방에서 아직도 담배냄새가 나네.",
        "나갈때 콘센트를 껐었나?",
        "아침에 침대에서 전기장판을 껐었나..?",
        "화장실에서 무슨 소리가..",
        "어디서 타는 냄새가..?",
        "아직도 타는 냄새가 나는데..!"
    };

    string[] hhintString_en = {
        "There's still a smell of cigarettes in the kitchen.",
        "Did I turn off the power socket when I left?",
        "Did I turn off the electric blanket in the morning?",
        "What is that sound in the bathroom..?",
        "Where is the burning smell coming from..?",
        "It still smells like something is burning..!"
    };

    private int localeIndex;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        oc = GameObject.Find("GameManager").GetComponent<Objectcount>();

        // 초기 로케일 인덱스를 설정
        localeIndex = GetLocaleIndex();

        // 언어 변경 시 이벤트 리스너 추가
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;

        PlayerPrefs.SetInt("PlayCount", 0);
        PlayerPrefs.SetInt("Loop", 0);

        if (SceneManager.GetActiveScene().buildIndex == 2)
            factoryObjectNames();
        else if (SceneManager.GetActiveScene().buildIndex == 3)
            restaurantObjectNames();
        else if (SceneManager.GetActiveScene().buildIndex == 4)
            houseObjectNames();
    }

    void Update()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        makeHints(scene);
    }

    private int GetLocaleIndex()
    {
        string currentLocaleCode = LocalizationSettings.SelectedLocale.Identifier.Code;
        return currentLocaleCode == "ko" ? 0 : 1; // 기본값은 한국어(0)
    }

    private void OnLocaleChanged(Locale locale)
    {
        localeIndex = GetLocaleIndex();
        UpdateHintText(SceneManager.GetActiveScene().buildIndex); // 언어가 변경될 때 기존 힌트 수 유지
    }

    public void makeHints(int scene)
    {
        if (scene == 2)
        {
            // Factory scene
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(factory[objName]))
                {
                    objectName.Add(factory[objName], localeIndex == 0 ? fhintString_ko[factory[objName]] : fhintString_en[factory[objName]]);
                }
            }
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play);
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                if (num < fhintString_ko.Length && isloop != 1)
                {
                    PlayerPrefs.SetInt("PlayCount", num + 1);
                    PlayerPrefs.SetInt("Loop", 1);
                }

                UpdateHintText(scene);
            }
        }
        else if (scene == 3)
        {
            // Restaurant scene
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(restaurant[objName]))
                {
                    objectName.Add(restaurant[objName], localeIndex == 0 ? rhintString_ko[restaurant[objName]] : rhintString_en[restaurant[objName]]);
                }
            }
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play);
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                if (num < rhintString_ko.Length && isloop != 1)
                {
                    PlayerPrefs.SetInt("PlayCount", num + 1);
                    PlayerPrefs.SetInt("Loop", 1);
                }

                UpdateHintText(scene);
            }
        }
        else if (scene == 4)
        {
            // House scene
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(house[objName]))
                {
                    objectName.Add(house[objName], localeIndex == 0 ? hhintString_ko[house[objName]] : hhintString_en[house[objName]]);
                }
            }
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play);
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                if (num < hhintString_ko.Length && isloop != 1)
                {
                    PlayerPrefs.SetInt("PlayCount", num + 1);
                    PlayerPrefs.SetInt("Loop", 1);
                }

                UpdateHintText(scene);
            }
        }
    }

    private void UpdateHintText(int scene)
    {
        hintText.text = ""; // 기존 힌트를 초기화
        int num = PlayerPrefs.GetInt("PlayCount", 0);

        string[] hintArray_ko;
        string[] hintArray_en;

        if (scene == 2) // Factory scene
        {
            hintArray_ko = fhintString_ko;
            hintArray_en = fhintString_en;
        }
        else if (scene == 3) // Restaurant scene
        {
            hintArray_ko = rhintString_ko;
            hintArray_en = rhintString_en;
        }
        else if (scene == 4) // House scene
        {
            hintArray_ko = hhintString_ko;
            hintArray_en = hhintString_en;
        }
        else
        {
            return;
        }

        for (int i = 0; i < num && i < hintArray_ko.Length; i++)
        {
            hintText.text += (localeIndex == 0 ? hintArray_ko[i] : hintArray_en[i]) + "\n";
        }
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


