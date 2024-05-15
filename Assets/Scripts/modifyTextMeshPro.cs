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

    public int[] canvasNumber = { 1, 2, 3, 3, 3, 3, 4, 5, 6, 7 };
    public Vector3[] flocation = { new Vector3(1.687f, 2.15f, -0.306f), new Vector3(-6.76f, 2f, -7.6f),
        new Vector3(4.217f, 2.15f,-10.426f), new Vector3(-7.85f, 2.5f, -2.25f),  new Vector3(4f, 2.5f, 14.45f),
        new Vector3(-9.14f, 2.5f, 13.06f), new Vector3(-1.91f, 2.3f, 0.24f), new Vector3(-8.08f, 2.15f, 4.462f),
        new Vector3(5.21f, 2.15f, 11.66f), new Vector3(-10.95f, 2.15f, 7.16f)};

    public float[] frotation = { -90f, -270f, -183.092f, -159.444f, 44.486f, -90f, -270f, -270f, 50f, 270f };

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

    public int countChildren()
    {
        return parent.transform.childCount;
    }

    public bool activeCanvases()
    {
        return active;
    }
}