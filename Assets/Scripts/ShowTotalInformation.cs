using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTotalInformation : MonoBehaviour
{
    [Header("Return Canvas")]
    public GameObject returnCanvas;

    [Header("The Total Information Canvas")]
    public GameObject canvas;

    [Header("The number of Active Contents")]
    public int countContents; // 활성화 될 인포창 개수

    [Header("Active Content")]
    public GameObject[] contents; // 활성화 될 인포창 배열

    [Header("Buttons Number")]
    public int buttonNumbers;

    [Header("Buttons Number")]
    public Button[] buttons;

    [Header("Back Button")]
    public Button backButton;

    private int first = 1;

    // public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableCanvas();

        //Hook events
        for(int i = 0; i < countContents; i++)
        {
            if (buttons[i].onClick.AddListener())
                ShowCanvas(contents[i]);
        }

        backButton.onClick.AddListener(DisableCanvas);

        // foreach (var item in returnButtons)
        // {
        //     item.onClick.AddListener(EnableMainMenu);
        // }
    }

    public void ShowCanvas(GameObject tmp)
    {
        HideAll();
        tmp.SetActive(true);
    }

    public void EnableCanvas()
    {
        HideAll();
        contents[first].SetActive(true);
    }

    public void HideAll()
    {
        for(int i = 0;i < countContents; i++)
        {
            contents[i].SetActive(false);
        }
    }

    public void DisableCanvas()
    {
        canvas.SetActive(false);
        returnCanvas.SetActive(true);
    }
}
