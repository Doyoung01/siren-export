using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class modifyTextMeshPro : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public int[] canvasNumber = { 1, 2, 3, 3, 3, 4, 5, 6, 7 };
    private GameManager gm;
    private float t = 0;
    private bool loop = false;

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text content1;
    [SerializeField] private TMP_Text content2;

    private string[] titleList = {
        "When working with a welding machine",
        "Smoking",
        "Where to store combustible materials in a fire-use area",
        "Overheating of the machine",
        "Machine collision",
        "Spark fire caused by dust",
        "Obstacles around the extinguisher"
    };
    private string[] contentList1 = {
        "Yesterday's welding fire was alive.",
        "A lit cigarette was touched on a coat, which is a combustible material.",
        "A welding spark came into contact with unprotected combustible material and ignited.",
        "The machine has been running for a long time, causing the motor and engine to become too hot.",
        "A worker operated the machines incorrectly and they collided with each other.",
        "A welding spark met with dust in the air and exploded.",
        "There were too many boxes around the fire extinguisher to put out the embers quickly."
    };
    private string[] contentList2 = {
        "It is necessary to check the site again after work and before leaving work. It's also a good idea to keep a fire extinguisher or fire extinguisher right next to you.",
        "Only Smoke in smoking areas, and make sure that the embers are completely extinguished before throwing it away. Also, use a hard, deep, non-burnt porcelain or glass ashtray not a paper cup. Pouring water into the ashtray is also a way to prevent cigarette embers from splashing out.",
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
        for (t = 0; t < 10; t += Time.deltaTime) ;
        if (t >= 4 && loop == false)
        {
            bool clear = gm.getIsclear();
            if (clear)
            {
                for (int j = 0; j < canvasNumber.Length; j++)
                {
                    makeInstance(canvasNumber[j] - 1);
                }
                loop = true;
            }
        }
    }

    private void makeInstance(int i)
    {
        GameObject myInstance = Instantiate(prefab, parent);
        myInstance.transform.position = new Vector3(0, i * 2, 0);

        this.title = myInstance.transform.Find("TitleText").gameObject.GetComponent<TMP_Text>();
        this.content1 = myInstance.transform.Find("ContentText1").gameObject.GetComponent<TMP_Text>();
        this.content2 = myInstance.transform.Find("ContentText2").gameObject.GetComponent<TMP_Text>();

        this.title.text = titleList[i];
        this.content1.text = contentList1[i];
        this.content2.text = contentList2[i];

        myInstance.SetActive(true);
    }
}