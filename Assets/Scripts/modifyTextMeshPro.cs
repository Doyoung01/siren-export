using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;


public class modifyTextMeshPro : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public int[] canvasNumber;
    public Vector3[] flocation = { new Vector3(1.687f, 2.15f, -0.306f), new Vector3(-6.76f, 2f, -7.6f),
        new Vector3(4.217f, 2.15f,-10.426f), new Vector3(-7.85f, 2.5f, -2.25f),  new Vector3(4f, 2.5f, 14.45f),
        new Vector3(-9.14f, 2.5f, 13.06f), new Vector3(-1.91f, 2.3f, 0.24f), new Vector3(-8.08f, 2.15f, 4.462f),
        new Vector3(5.21f, 2.15f, 11.66f), new Vector3(-10.95f, 2.15f, 7.16f)};
    public Vector3[] rlocation = {  };
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

    public string[] ftitleList = {
        "When working with a welding machine",
        "Smoking",
        "Where to store combustible materials in a fire-use area",
        "Where to store combustible materials in a fire-use area",
        "Where to store combustible materials in a fire-use area",
        "Where to store combustible materials in a fire-use area",
        "Overheating of the machine",
        "Machine collision",
        "Spark fire caused by dust",
        "Obstacles around the extinguisher"
    };
    public string[] fcontentList1 = {
        "Yesterday's welding fire was alive.",
        "A lit cigarette was touched on a coat, which is a combustible material.",
        "A welding spark came into contact with unprotected combustible material and ignited.",
        "A welding spark came into contact with unprotected combustible material and ignited.",
        "A welding spark came into contact with unprotected combustible material and ignited.",
        "A welding spark came into contact with unprotected combustible material and ignited.",
        "The machine has been running for a long time, causing the motor and engine to become too hot.",
        "A worker operated the machines incorrectly and they collided with each other.",
        "A welding spark met with dust in the air and exploded.",
        "There were too many boxes around the fire extinguisher to put out the embers quickly."
    };
    public string[] fcontentList2 = {
        "It is necessary to check the site again after work and before leaving work. It's also a good idea to keep a fire extinguisher or fire extinguisher right next to you.",
        "Only Smoke in smoking areas, and make sure that the embers are completely extinguished before throwing it away. Also, use a hard, deep, non-burnt porcelain or glass ashtray not a paper cup. Pouring water into the ashtray is also a way to prevent cigarette embers from splashing out.",
        "Remove anything that could catch fire from the surrounding area far away, at least 11m, or protect it with fire covers, metal shields or fire protection materials(heat-resistant protective materials).",
        "Remove anything that could catch fire from the surrounding area far away, at least 11m, or protect it with fire covers, metal shields or fire protection materials(heat-resistant protective materials).",
        "Remove anything that could catch fire from the surrounding area far away, at least 11m, or protect it with fire covers, metal shields or fire protection materials(heat-resistant protective materials).",
        "Remove anything that could catch fire from the surrounding area far away, at least 11m, or protect it with fire covers, metal shields or fire protection materials(heat-resistant protective materials).",
        "Check and maintain the machine regularly. Also, if the space where the machine is located is hot, install cooling fans or consider proper ventilation. In addition, it is recommended to establish relevant work procedures to ensure thorough management.",
        "A worker operated the machines incorrectly and they collided with each other.",
        "To prevent such dust explosion accidents, it is necessary to prevent the accumulation of dust with a vacuum cleaner, dust collector, etc. and remove elements that can be ignition sources.",
        "If the fire extinguisher is surrounded by a lot of luggage, it may not be used properly when needed. Fire extinguishers should be placed in a visible location that does not cause inconvenience to people's passage, and it is recommended to avoid direct sunlight in places with high temperatures or humidity."
    };

    // Restaurant Canvas
    public string[] rtitleList =
    {
        "Combustible materials near a gas flame",
        "Not turning off the power after using the fryer",
        "Gas leak in gas pipeline",
        "Long-term use of air conditioner",
        "Problems using regular fire extinguishers",
        "Grease stains on the kitchen hood"
    };

    public string[] rcontentList1 =
    {
        "Placing flammable materials near a gas flame can cause a fire to spread.",
        "If the fryer is continuously turned on, the fryer and oil may overheat and cause a fire.",
        "There is a gas leak.",
        "The air conditioner overheated due to prolonged use.",
        "Fire safety standards require restaurants to have Class K fire extinguishers.",
        "Fire may spread due to grease stains accumulated in the hood from cooking food."
    };
    public string[] rcontentList2 = {
        "Keep flammable materials (materials that can catch fire) away from the gas stove.",
        "When there is no food to cook, turn off the power to lower the temperature of the fryer and oil.",
        "Conduct regular inspections of gas pipelines and connections, stoves. Additionally, safety valves or automatic shut-off systems can be installed in gas pipelines to automatically shut off the gas supply when a leak is detected.",
        "Excessive use of air conditioners can cause electrical sparks in the cord, and condenser(outdoor units) can can also overheat. Regularly inspect the air conditioner's wiring for any issues, and avoid overheating by frequently turning off the air conditioner.",
        "Kitchens up to 25m² should be equipped with a class K fire extinguisher, while those larger than 25m^2 require both a class K and a powder fire extinguisher. Additionally, it is necessary to regularly check the fire extinguisher's pressure gauge.",
        "Filters in the hood should be cleaned regularly to prevent grease accumulation. To clean the filter, first turn off the hood and remove the filter. Then, clean it with a neutral detergent, rinse, and dry thoroughly."
    };

    public string[] htitleList =
    {
        "Electric pad",
        "Cooking food",
        "Multi-tap fire",
        "Cigarette butts fire",
        "Hair dryer fire",
        "Toaster fire"
    };

    public string[] hcontentList1 =
    {
        "Electric floorboards were used with thick blankets for a long time. This prevents heat from escaping and can cause fires due to high temperatures.",
        "Food left in the cooking. Long periods of gas fire use can lead to fires.",
        "Overloaded with multi-tap octopus, resulting in fire. Excessive current flow may cause a fire.",
        "The fire started because the cigarette butts did not check the embers after smoking. It's one of the many accidents that occur due to carelessness every year.",
        "The hair dryer was left on, causing a fire. Turning on the hair dryer for a long time may cause a fire due to heat.",
        "The fire was caused by bread crumbs, dust, etc. inside the toaster. You need to be careful as it is a device that uses heat.",
    };

    public string[] hcontentList2 =
    {
        "Avoid using electric floorboards, thick yarns, blankets, etc. together. Additionally, you must verify that the product is safety certified and unplug it if not in use.",
        "Do not leave food as much as possible while cooking. Make sure the gas heat is turned off after cooking, and no additional combustible substances are placed near the fire.",
        "You should refrain from using a multi-tap octopus, and we recommend using a multi-tap with overload protection. It is also recommended that you refrain from using it if there is a problem with the wire cladding.",
        "Always check for embers before throwing away cigarette butts after smoking, and never throw them near combustible substances. Additionally, you should be careful when discarding the ashtray as there may still be embers left.",
        "It is recommended to turn off the hair dryer after use and to pull out the cord line. In addition, care must be taken for foreign substances or dust in the inlet and do not store it in a damp place.",
        "Periodic cleaning of dust and breadcrumbs is required, and unplugging is recommended after use. Additionally, metal substances should not be inserted after use of the toaster, and the toaster should not be applied with butter.",        
    };

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        t += Time.deltaTime;
        if (t >= 1 && loop == false)
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
            } else if (clear && SceneManager.GetActiveScene().buildIndex == 3)
            {
                for (int j = 0; j < canvasNumber.Length; j++)
                {
                    rmakeInstance(canvasNumber[j] - 1, j);
                }
                loop = true;
                active = true;
            } else if (clear && SceneManager.GetActiveScene().buildIndex == 4)
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
        Quaternion newVRotation = Quaternion.Euler(0, frotation[j], 0);
        myInstance.transform.rotation = newVRotation;

        // Button clonedBtn = myInstance.transform.Find("OkButton").GetComponent<Button>();
        // OnbtnClick(clonedBtn);

        Button clonedBtn = Instantiate(btn, myInstance.transform);
        RectTransform rectTransform = clonedBtn.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);  // Anchor를 부모의 중앙으로 설정
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);      // pivot을 중앙으로 설정
        rectTransform.anchoredPosition = new Vector2(0, -210.9025f);

        // clonedBtn.transform.position = pos;
        TMP_Text btnText = clonedBtn.GetComponentInChildren<TMP_Text>();
        btnText.text = "OK";
        clonedBtn.onClick.AddListener(() => Destroy(myInstance));

        this.title = myInstance.transform.Find("TitleText").gameObject.GetComponent<TMP_Text>();
        this.content1 = myInstance.transform.Find("ContentText1").gameObject.GetComponent<TMP_Text>();
        this.content2 = myInstance.transform.Find("ContentText2").gameObject.GetComponent<TMP_Text>();

        this.title.text = ftitleList[i];
        this.content1.text = fcontentList1[i];
        this.content2.text = fcontentList2[i];

        myInstance.SetActive(true);
    }

    private void rmakeInstance(int i, int j)
    {
        GameObject myInstance = Instantiate(prefab, parent, true);
        myInstance.transform.position = parent.position + rlocation[j];
        Quaternion newVRotation = Quaternion.Euler(0, rrotation[j], 0);
        myInstance.transform.rotation = newVRotation;

        Button clonedBtn = Instantiate(btn, myInstance.transform);
        RectTransform rectTransform = clonedBtn.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);  // Anchor를 부모의 중앙으로 설정
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);      // pivot을 중앙으로 설정
        rectTransform.anchoredPosition = new Vector2(0, -210.9025f);

        TMP_Text btnText = clonedBtn.GetComponentInChildren<TMP_Text>();
        btnText.text = "OK";
        clonedBtn.onClick.AddListener(() => Destroy(myInstance));

        this.title = myInstance.transform.Find("TitleText").gameObject.GetComponent<TMP_Text>();
        this.content1 = myInstance.transform.Find("ContentText1").gameObject.GetComponent<TMP_Text>();
        this.content2 = myInstance.transform.Find("ContentText2").gameObject.GetComponent<TMP_Text>();

        this.title.text = rtitleList[i];
        this.content1.text = rcontentList1[i];
        this.content2.text = rcontentList2[i];

        myInstance.SetActive(true);
    }

    private void hmakeInstance(int i, int j)
    {
        GameObject myInstance = Instantiate(prefab, parent, true);
        myInstance.transform.position = parent.position + hlocation[j];
        Quaternion newVRotation = Quaternion.Euler(0, hrotation[j], 0);
        myInstance.transform.rotation = newVRotation;

        Button clonedBtn = Instantiate(btn, myInstance.transform);
        RectTransform rectTransform = clonedBtn.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);  // Anchor를 부모의 중앙으로 설정
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);      // pivot을 중앙으로 설정
        rectTransform.anchoredPosition = new Vector2(0, -210.9025f);

        TMP_Text btnText = clonedBtn.GetComponentInChildren<TMP_Text>();
        btnText.text = "OK";
        clonedBtn.onClick.AddListener(() => Destroy(myInstance));

        this.title = myInstance.transform.Find("TitleText").gameObject.GetComponent<TMP_Text>();
        this.content1 = myInstance.transform.Find("ContentText1").gameObject.GetComponent<TMP_Text>();
        this.content2 = myInstance.transform.Find("ContentText2").gameObject.GetComponent<TMP_Text>();

        this.title.text = htitleList[i];
        this.content1.text = hcontentList1[i];
        this.content2.text = hcontentList2[i];

        myInstance.SetActive(true);
    }

    public int countChildren()
    {
        return parent.transform.childCount;
    }

    public bool activeCanvases()
    {
        return active;
    }
}