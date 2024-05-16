using Oculus.Voice.Core.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class showTotalInformation : MonoBehaviour
{
    [Header("Return Canvas")]
    public GameObject returnCanvas;

    [Header("The Total Information Canvas")]
    public GameObject totalCanvas;
    public Button[] btns;
    public TMP_Text title;
    public TMP_Text content;
    private GameManager gm;
    private modifyTextMeshPro mtm;
    private clickWhat cw;

    [Header("Back Button")]
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        cw = GameObject.Find("Buttons").GetComponent<clickWhat>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mtm = GameObject.Find("GameManager").GetComponent<modifyTextMeshPro>();

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            title.text = mtm.ftitleList[0];
            content.text = "\n" + mtm.fcontentList1[0] + "\n\n\n" + mtm.fcontentList2[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && gm.getIsclear())
        {
            Button[] childButtons = GetComponentsInChildren<Button>();
            foreach (Button button in childButtons)
            {
                if (button != null && button.name != "TotalBackButton" && button.name != "ClearButton")
                {
                    button.onClick.AddListener(() => { fenableCanvas(int.Parse(button.name) - 1); });
                }
            }
        }
    }

    public void fenableCanvas(int i)
    {
        Debug.Log(i);

        title.text = mtm.ftitleList[i];
        content.text = "\n" + mtm.fcontentList1[i] + "\n\n\n" + mtm.fcontentList2[i];
    }

    public void DisableCanvas()
    {
        totalCanvas.SetActive(false);
        returnCanvas.SetActive(true);
    }
}
