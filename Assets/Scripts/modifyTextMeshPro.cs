using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class modifyTextMeshPro : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public int[] canvasNumber;
    public Vector3[] flocation = { new Vector3(1.687f, 2.15f, -0.306f), new Vector3(-6.76f, 2f, -7.6f),
        new Vector3(4.217f, 2.15f, -10.426f), new Vector3(-7.85f, 2.5f, -2.25f), new Vector3(4f, 2.5f, 14.45f),
        new Vector3(-9.14f, 2.5f, 13.06f), new Vector3(-1.91f, 2.3f, 0.24f), new Vector3(-8.08f, 2.15f, 4.462f),
        new Vector3(5.21f, 2.15f, 11.66f), new Vector3(-10.95f, 2.15f, 7.16f) };
    public Vector3[] rlocation = { };
    public Vector3[] hlocation = { };

    private float[] frotation = { -90f, -270f, -183.092f, -159.444f, 44.486f, -90f, -270f, -270f, 50f, 270f };
    private float[] rrotation = { 90f, -90f, 90f, 90f, -90f, 90f };
    private float[] hrotation = { -0.345f, 87.959f, 176.996f, -57.428f, -180f, 74.735f };

    private GameManager gm;
    private float t = 0;
    private bool loop = false;
    private bool active = false;
    public Button btn;

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text content1;
    [SerializeField] private TMP_Text content2;

    private int localeIndex; // 언어 인덱스

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        localeIndex = GetLocaleIndex(); // 초기 로케일 인덱스 설정
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged; // 언어 변경 이벤트 추가

        if (SceneManager.GetActiveScene().buildIndex == 2)
            factoryObjectNames();
        else if (SceneManager.GetActiveScene().buildIndex == 3)
            restaurantObjectNames();
        else if (SceneManager.GetActiveScene().buildIndex == 4)
            houseObjectNames();
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t >= 1 && !loop)
        {
            bool clear = gm.getIsclear();
            if (clear && SceneManager.GetActiveScene().buildIndex == 2)
            {
                for (int j = 0; j < canvasNumber.Length; j++)
                {
                    fmakeInstance(canvasNumber[j] - 1, j);
                }
                loop = true;
                active = true;
            }
            else if (clear && SceneManager.GetActiveScene().buildIndex == 3)
            {
                for (int j = 0; j < canvasNumber.Length; j++)
                {
                    rmakeInstance(canvasNumber[j] - 1, j);
                }
                loop = true;
                active = true;
            }
            else if (clear && SceneManager.GetActiveScene().buildIndex == 4)
            {
                for (int j = 0; j < canvasNumber.Length; j++)
                {
                    hmakeInstance(canvasNumber[j] - 1, j);
                }
                loop = true;
                active = true;
            }
            t = 0;
        }
    }

    private void fmakeInstance(int i, int j)
    {
        GameObject myInstance = Instantiate(prefab, parent, false);
        myInstance.transform.position = flocation[j];
        myInstance.transform.rotation = Quaternion.Euler(0, frotation[j], 0);

        Button clonedBtn = Instantiate(btn, myInstance.transform);
        clonedBtn.GetComponentInChildren<TMP_Text>().text = "OK";
        clonedBtn.onClick.AddListener(() => Destroy(myInstance));

        title = myInstance.transform.Find("TitleText").gameObject.GetComponent<TMP_Text>();
        content1 = myInstance.transform.Find("ContentText1").gameObject.GetComponent<TMP_Text>();
        content2 = myInstance.transform.Find("ContentText2").gameObject.GetComponent<TMP_Text>();

        title.text = localeIndex == 0 ? ftitleList_kr[i] : ftitleList_en[i];
        content1.text = localeIndex == 0 ? fcontentList1_kr[i] : fcontentList1_en[i];
        content2.text = localeIndex == 0 ? fcontentList2_kr[i] : fcontentList2_en[i];
    }

    private void rmakeInstance(int i, int j)
    {
        GameObject myInstance = Instantiate(prefab, parent, true);
        myInstance.transform.position = rlocation[j];
        myInstance.transform.rotation = Quaternion.Euler(0, rrotation[j], 0);

        Button clonedBtn = Instantiate(btn, myInstance.transform);
        clonedBtn.GetComponentInChildren<TMP_Text>().text = "OK";
        clonedBtn.onClick.AddListener(() => Destroy(myInstance));

        title = myInstance.transform.Find("TitleText").gameObject.GetComponent<TMP_Text>();
        content1 = myInstance.transform.Find("ContentText1").gameObject.GetComponent<TMP_Text>();
        content2 = myInstance.transform.Find("ContentText2").gameObject.GetComponent<TMP_Text>();

        title.text = localeIndex == 0 ? rtitleList_kr[i] : rtitleList_en[i];
        content1.text = localeIndex == 0 ? rcontentList1_kr[i] : rcontentList1_en[i];
        content2.text = localeIndex == 0 ? rcontentList2_kr[i] : rcontentList2_en[i];
    }

    private void hmakeInstance(int i, int j)
    {
        GameObject myInstance = Instantiate(prefab, parent, true);
        myInstance.transform.position = hlocation[j];
        myInstance.transform.rotation = Quaternion.Euler(0, hrotation[j], 0);

        Button clonedBtn = Instantiate(btn, myInstance.transform);
        clonedBtn.GetComponentInChildren<TMP_Text>().text = "OK";
        clonedBtn.onClick.AddListener(() => Destroy(myInstance));

        title = myInstance.transform.Find("TitleText").gameObject.GetComponent<TMP_Text>();
        content1 = myInstance.transform.Find("ContentText1").gameObject.GetComponent<TMP_Text>();
        content2 = myInstance.transform.Find("ContentText2").gameObject.GetComponent<TMP_Text>();

        title.text = localeIndex == 0 ? htitleList_kr[i] : htitleList_en[i];
        content1.text = localeIndex == 0 ? hcontentList1_kr[i] : hcontentList1_en[i];
        content2.text = localeIndex == 0 ? hcontentList2_kr[i] : hcontentList2_en[i];
    }

    private int GetLocaleIndex()
    {
        string localeCode = LocalizationSettings.SelectedLocale.Identifier.Code;
        return localeCode == "ko" ? 0 : 1; // 0: 한국어, 1: 영어
    }

    private void OnLocaleChanged(Locale locale)
    {
        localeIndex = GetLocaleIndex();
    }

    public int countChildren()
    {
        return parent.transform.childCount;
    }

    public bool activeCanvases()
    {
        return active;
    }

    public string[] ftitleList => localeIndex == 0 ? ftitleList_kr : ftitleList_en;
    public string[] fcontentList1 => localeIndex == 0 ? fcontentList1_kr : fcontentList1_en;
    public string[] fcontentList2 => localeIndex == 0 ? fcontentList2_kr : fcontentList2_en;

    public string[] rtitleList => localeIndex == 0 ? rtitleList_kr : rtitleList_en;
    public string[] rcontentList1 => localeIndex == 0 ? rcontentList1_kr : rcontentList1_en;
    public string[] rcontentList2 => localeIndex == 0 ? rcontentList2_kr : rcontentList2_en;

    public string[] htitleList => localeIndex == 0 ? htitleList_kr : htitleList_en;
    public string[] hcontentList1 => localeIndex == 0 ? hcontentList1_kr : hcontentList1_en;
    public string[] hcontentList2 => localeIndex == 0 ? hcontentList2_kr : hcontentList2_en;

public string[] ftitleList_en = {
    "When working with a welding machine\n",
    "Smoking\n",
    "Where to store combustible materials in a fire-use area\n",
    "Overheating of the machine\n",
    "Machine collision\n",
    "Spark fire caused by dust\n",
    "Obstacles around the extinguisher\n"
};
public string[] fcontentList1_en = {
    "Yesterday's welding fire was alive.\n",
    "A lit cigarette was touched on a coat, which is a combustible material.\n",
    "A welding spark came into contact with unprotected combustible material and ignited.\n",
    "The machine has been running for a long time, causing the motor and engine to become too hot.\n",
    "A worker operated the machines incorrectly and they collided with each other.\n",
    "A welding spark met with dust in the air and exploded.\n",
    "There were too many boxes around the fire extinguisher to put out the embers quickly.\n"
};
public string[] fcontentList2_en = {
    "Check the site after work. Keep a fire extinguisher nearby.",
    "Smoke only in smoking areas and extinguish embers completely.",
    "Remove combustible materials at least 11m away.",
    "Check and maintain the machine regularly.",
    "Workers should operate machines correctly to avoid collisions.",
    "Prevent dust accumulation with a vacuum cleaner.",
    "Place fire extinguishers in visible, accessible locations."
};

// 공장 장면 텍스트 - 한국어
public string[] ftitleList_kr = {
    "용접 기계 사용 시",
    "흡연",
    "화재 위험 구역의 가연성 물질 보관",
    "기계 과열",
    "기계 충돌",
    "먼지로 인한 불꽃 화재",
    "소화기 주변 장애물"
};
public string[] fcontentList1_kr = {
    "어제의 용접 불씨가 아직 살아 있습니다.",
    "불 붙은 담배가 가연성 물질인 코트에 닿았습니다.",
    "용접 불꽃이 보호되지 않은 가연성 물질과 접촉하여 점화되었습니다.",
    "기계가 장시간 가동되어 모터와 엔진이 과열되었습니다.",
    "작업자가 기계를 잘못 작동시켜 충돌했습니다.",
    "용접 불꽃이 공기 중의 먼지와 만나 폭발했습니다.",
    "소화기 주변에 너무 많은 상자가 있어 신속한 사용이 어렵습니다."
};
public string[] fcontentList2_kr = {
    "퇴근 전 현장을 점검하고 소화기를 가까이 둡니다.",
    "흡연 구역에서만 흡연하고 불씨를 완전히 소멸시킵니다.",
    "가연성 물질을 최소 11m 이상 떨어뜨려 보관합니다.",
    "기계를 정기적으로 점검하고 유지보수합니다.",
    "작업자가 기계를 올바르게 작동하여 충돌을 방지합니다.",
    "진공청소기로 먼지 축적을 방지합니다.",
    "소화기는 잘 보이고 접근하기 쉬운 곳에 둡니다."
};

// Restaurant Canvas - 영어
public string[] rtitleList_en = {
    "Combustible materials near a gas flame",
    "Not turning off the power after using the fryer",
    "Gas leak in gas pipeline",
    "Long-term use of air conditioner",
    "Problems using regular fire extinguishers",
    "Grease stains on the kitchen hood"
};
public string[] rcontentList1_en = {
    "Placing flammable materials near a gas flame can cause a fire to spread.",
    "If the fryer is continuously turned on, the fryer and oil may overheat and cause a fire.",
    "There is a gas leak.",
    "The air conditioner overheated due to prolonged use.",
    "Fire safety standards require restaurants to have Class K fire extinguishers.",
    "Fire may spread due to grease stains accumulated in the hood from cooking food."
};
public string[] rcontentList2_en = {
    "Keep flammable materials (materials that can catch fire) away from the gas stove.",
    "When there is no food to cook, turn off the power to lower the temperature of the fryer and oil.",
    "Conduct regular inspections of gas pipelines and connections, stoves. Additionally, safety valves or automatic shut-off systems can be installed in gas pipelines to automatically shut off the gas supply when a leak is detected.",
    "Excessive use of air conditioners can cause electrical sparks in the cord, and condenser(outdoor units) can also overheat. Regularly inspect the air conditioner's wiring for any issues, and avoid overheating by frequently turning off the air conditioner.",
    "Kitchens up to 25m² should be equipped with a class K fire extinguisher, while those larger than 25m² require both a class K and a powder fire extinguisher. Additionally, it is necessary to regularly check the fire extinguisher's pressure gauge.",
    "Filters in the hood should be cleaned regularly to prevent grease accumulation. To clean the filter, first turn off the hood and remove the filter. Then, clean it with a neutral detergent, rinse, and dry thoroughly."
};

// Restaurant Canvas - 한국어
public string[] rtitleList_kr = {
    "가스 불 근처의 가연성 물질\n",
    "프라이어 사용 후 전원을 끄지 않음\n",
    "가스 배관의 가스 누출\n",
    "에어컨 장시간 사용\n",
    "일반 소화기 사용 문제\n",
    "주방 후드의 기름때\n"
};
public string[] rcontentList1_kr = {
    "가스 불 가까이에 가연성 물질을 놓으면 화재가 번질 수 있습니다\n.",
    "프라이어가 계속 켜져 있으면 프라이어와 기름이 과열되어 화재가 발생할 수 있습니다.\n",
    "가스가 누출되고 있습니다.\n",
    "장시간 사용으로 에어컨이 과열되었습니다.\n",
    "화재 안전 기준에 따라 식당은 K급 소화기를 비치해야 합니다.\n",
    "음식을 조리하면서 후드에 쌓인 기름때로 인해 화재가 확산될 수 있습니다.\n"
};
public string[] rcontentList2_kr = {
    "가연성 물질(불이 붙을 수 있는 물질)은 가스레인지에서 멀리 두세요.\n",
    "조리할 음식이 없을 때는 전원을 꺼서 프라이어와 기름의 온도를 낮추세요.\n",
    "가스 배관과 연결부, 가스레인지를 정기적으로 점검하세요. 또한, 가스 누출이 감지되면 자동으로 가스 공급을 차단하는 안전 밸브나 자동 차단 시스템을 가스 배관에 설치할 수 있습니다.\n",
    "에어컨 과도한 사용은 전원 코드에 전기 스파크를 일으킬 수 있으며, 실외기 또한 과열될 수 있습니다. 에어컨 배선의 문제를 정기적으로 점검하고 자주 꺼서 과열을 방지하세요.\n",
    "면적이 25m² 이하인 주방에는 K급 소화기를 비치하고, 25m²를 초과하는 주방에는 K급 소화기와 함께 분말 소화기도 비치해야 합니다. 또한, 소화기의 압력 게이지를 정기적으로 점검하세요.\n",
    "기름이 쌓이지 않도록 후드의 필터를 정기적으로 청소하세요. 필터를 청소하려면 먼저 후드를 끄고 필터를 분리한 뒤, 중성 세제로 닦고 깨끗이 헹군 후 완전히 건조시켜 다시 장착합니다.\n"
};

// House Canvas - 영어
public string[] htitleList_en = {
    "Electric pad",
    "Cooking food",
    "Multi-tap fire",
    "Cigarette butts fire",
    "Hair dryer fire",
    "Toaster fire"
};
public string[] hcontentList1_en = {
    "Electric floorboards were used with thick blankets for a long time. This prevents heat from escaping and can cause fires due to high temperatures.",
    "Food left in the cooking. Long periods of gas fire use can lead to fires.",
    "Overloaded with multi-tap octopus, resulting in fire. Excessive current flow may cause a fire.",
    "The fire started because the cigarette butts did not check the embers after smoking. It's one of the many accidents that occur due to carelessness every year.",
    "The hair dryer was left on, causing a fire. Turning on the hair dryer for a long time may cause a fire due to heat.",
    "The fire was caused by bread crumbs, dust, etc. inside the toaster. You need to be careful as it is a device that uses heat."
};
public string[] hcontentList2_en = {
    "Avoid using electric floorboards, thick yarns, blankets, etc. together. Additionally, you must verify that the product is safety certified and unplug it if not in use.",
    "Do not leave food as much as possible while cooking. Make sure the gas heat is turned off after cooking, and no additional combustible substances are placed near the fire.",
    "You should refrain from using a multi-tap octopus, and we recommend using a multi-tap with overload protection. It is also recommended that you refrain from using it if there is a problem with the wire cladding.",
    "Always check for embers before throwing away cigarette butts after smoking, and never throw them near combustible substances. Additionally, you should be careful when discarding the ashtray as there may still be embers left.",
    "It is recommended to turn off the hair dryer after use and to pull out the cord line. In addition, care must be taken for foreign substances or dust in the inlet and do not store it in a damp place.",
    "Periodic cleaning of dust and breadcrumbs is required, and unplugging is recommended after use. Additionally, metal substances should not be inserted after use of the toaster, and the toaster should not be applied with butter."
};

// House Canvas - 한국어
public string[] htitleList_kr = {
    "전기 장판",
    "조리 중인 음식",
    "멀티탭 화재",
    "담배 꽁초 화재",
    "헤어드라이어 화재",
    "토스터 화재"
};
public string[] hcontentList1_kr = {
    "전기 장판을 두꺼운 담요와 함께 오랜 시간 사용하면 열이 빠져나가지 못해 고온으로 인한 화재가 발생할 수 있습니다.",
    "조리 중 방치된 음식은 화재로 이어질 수 있습니다.",
    "멀티탭의 문어발식 사용으로 과부하가 발생하여 화재가 발생할 수 있습니다.",
    "흡연 후 담배 꽁초의 불씨를 확인하지 않아 화재가 발생했습니다. 이는 매년 부주의로 인해 발생하는 사고 중 하나입니다.",
    "헤어드라이어를 켜둔 채로 두어 화재가 발생했습니다. 오랜 시간 켜두면 열로 인해 화재가 발생할 수 있습니다.",
    "토스터기 내부의 빵 부스러기와 먼지로 인해 화재가 발생했습니다. 열을 사용하는 기기이므로 주의가 필요합니다."
};
public string[] hcontentList2_kr = {
    "전기 장판, 두꺼운 실, 담요 등을 함께 사용하지 마세요. 또한, 제품이 안전 인증을 받았는지 확인하고 사용하지 않을 때는 플러그를 뽑아 두세요.",
    "조리 중 가능한 한 음식을 방치하지 마세요. 조리가 끝난 후 가스 불을 꼭 끄고, 불 주변에 추가적인 가연성 물질이 없는지 확인하세요.",
    "멀티탭의 문어발식 사용을 자제하고, 과부하 보호 기능이 있는 멀티탭을 사용하는 것을 권장합니다. 또한, 전선 피복에 문제가 있는 경우 사용을 피하는 것이 좋습니다.",
    "흡연 후 담배 꽁초를 버리기 전에 반드시 불씨가 남아 있지 않은지 확인하고, 가연성 물질 근처에는 버리지 마세요. 또한, 재떨이를 버릴 때도 불씨가 남아 있을 수 있으니 주의하세요.",
    "사용 후에는 헤어드라이어를 반드시 끄고 전원 코드를 뽑는 것이 좋습니다. 또한, 흡입구에 이물질이나 먼지가 없는지 주의하고, 습기가 많은 곳에 보관하지 않도록 하세요.",
    "먼지와 빵 부스러기를 주기적으로 청소하고, 사용 후에는 플러그를 뽑아 두는 것이 좋습니다. 또한, 금속 물질을 삽입하지 말고, 토스터기에는 버터를 발라 사용하지 마세요."
};
    private void factoryObjectNames() { /*...*/ }
    private void restaurantObjectNames() { /*...*/ }
    private void houseObjectNames() { /*...*/ }
}
