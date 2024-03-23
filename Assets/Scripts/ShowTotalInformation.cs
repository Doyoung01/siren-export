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

    [Header("Active Content")]
    public GameObject gnum1;
    public GameObject gnum2;
    public GameObject gnum3;
    public GameObject gnum4;
    public GameObject gnum5;
    public GameObject gnum6;
    public GameObject gnum7;

    [Header("Buttons Number")]
    public Button bnum1;
    public Button bnum2;
    public Button bnum3;
    public Button bnum4;
    public Button bnum5;
    public Button bnum6;
    public Button bnum7;

    [Header("Back Button")]
    public Button backButton;

    // public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableCanvas();

        //Hook events
        bnum1.onClick.AddListener(() => ShowCanvas(gnum1));
        bnum2.onClick.AddListener(() => ShowCanvas(gnum2));
        bnum3.onClick.AddListener(() => ShowCanvas(gnum3));
        bnum4.onClick.AddListener(() => ShowCanvas(gnum4));
        bnum5.onClick.AddListener(() => ShowCanvas(gnum5));
        bnum6.onClick.AddListener(() => ShowCanvas(gnum6));
        bnum7.onClick.AddListener(() => ShowCanvas(gnum7));

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
        gnum1.SetActive(true);
    }

    public void HideAll()
    {
        gnum1.SetActive(false);
        gnum2.SetActive(false);
        gnum3.SetActive(false);
        gnum4.SetActive(false);
        gnum5.SetActive(false);
        gnum6.SetActive(false);
        gnum7.SetActive(false);
    }

    public void DisableCanvas()
    {
        canvas.SetActive(false);
        returnCanvas.SetActive(true);
    }
}
