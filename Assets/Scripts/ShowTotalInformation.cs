using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowTotalInformation : MonoBehaviour
{
    [Header("Return Canvas")]
    public GameObject returnCanvas;

    [Header("The Total Information Canvas")]
    public GameObject canvas;

    [Header("Active Content")]
    public GameObject[] contents; // 활성화 될 인포창 배열

    [Header("Buttons Number")]
    public Button[] buttons;

    [Header("Back Button")]
    public Button backButton;

    private int first = 0;

    // public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableCanvas();

        //Hook events
        foreach (var item in buttons.Select((value, index) => new { Value = value, Index = index })) {
            if (item.Value != null)
            {
                item.Value.onClick.AddListener(() => ShowCanvas(contents[item.Index]));
            }
            // item.onClick.AddListener(ShowCanvas(contents[index])) ;
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
        for(int i = 0;i < contents.Length; i++)
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
