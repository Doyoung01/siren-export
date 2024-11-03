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

    [Header("Back Button")]
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mtm = GameObject.Find("GameManager").GetComponent<modifyTextMeshPro>();

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            title.text = mtm.ftitleList[0];
            content.text = "\n" + mtm.fcontentList1[0] + "\n\n\n" + mtm.fcontentList2[0];
        } else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            title.text = mtm.rtitleList[0];
            content.text = "\n" + mtm.rcontentList1[0] + "\n\n\n" + mtm.rcontentList2[0];
        } else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            title.text = mtm.htitleList[0];
            content.text = "\n" + mtm.hcontentList1[0] + "\n\n\n" + mtm.hcontentList2[0];
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
                if (button != null && button.name != "TotalBackButton" && button.name != "ClearButton" && button.name != "BackButton")
                {
                    button.onClick.AddListener(() => { fenableCanvas(int.Parse(button.name) - 1); });
                } 
            }
        } else if (SceneManager.GetActiveScene().buildIndex== 3  && gm.getIsclear())
        {
            Button[] childButtons = GetComponentsInChildren<Button>();
            foreach (Button button in childButtons)
            {
                if (button != null && button.name != "TotalBackButton" && button.name != "ClearButton" && button.name != "BackButton")
                {
                    button.onClick.AddListener(() => { renableCanvas(int.Parse(button.name) - 1); });
                }
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 4 && gm.getIsclear())
        {
            Button[] childButtons = GetComponentsInChildren<Button>();
            foreach (Button button in childButtons)
            {
                if (button != null && button.name != "TotalBackButton" && button.name != "ClearButton" && button.name != "BackButton")
                {
                    button.onClick.AddListener(() => { henableCanvas(int.Parse(button.name) - 1); });
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
    public void renableCanvas(int i)
    {
        Debug.Log(i);

        title.text = mtm.rtitleList[i];
        content.text = "\n" + mtm.rcontentList1[i] + "\n\n\n" + mtm.rcontentList2[i];
    }
    public void henableCanvas(int i)
    {
        Debug.Log(i);

        title.text = mtm.htitleList[i];
        content.text = "\n" + mtm.hcontentList1[i] + "\n\n\n" + mtm.hcontentList2[i];
    }
}
