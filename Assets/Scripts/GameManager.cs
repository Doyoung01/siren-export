using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Threading;
using Unity.VisualScripting;
using System.Data;
using Oculus.Interaction.UnityCanvas;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [Header("Game Over")]
    public AudioClip audioClip; // Siren mp3
    public GameObject fires;
    private float sirenTime = 10f;
    private float sirenTimeLimit = 0;

    [Header("Timer")]
    public GameObject Player;
    public GameObject Timer;
    public GameObject RestartButton;
    public Text timeText;
    private float time;
    private float timeLimit;
    public GameObject CoverImage;
    int min;
    float sec;
    private bool isChecked = false;
    private bool hasAppeared = false;

    [Header("BGM")]
    private AudioSource audio;
    private float speed;

    [Header("Is Clear")]
    private Objectcount countScript;
    private bool isclear = false;
    public GameObject canvases;
    public AudioClip applause;

    [Header("Clear Window")]
    public GameObject clear; // 클리어창
    public GameObject Info;//각 인포창
    public GameObject totalInfo;

    [Header("Pause")]
    public InputActionAsset actionAsset;
    public GameObject pauseWindow;
    private bool isPause;
    float saveButton = 0;

    private static int gamePlay = 0;

    public bool isActiveInfo()
    {
        return canvases.activeSelf;
    }

    public bool getIsclear()
    {
        return isclear;
    }

    public bool getReturnCanvasActive()
    {
        return RestartButton.activeSelf;
    }

    public float getTime()
    {
        return time;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        RestartButton.SetActive(false);
        fires.SetActive(false);
        clear.SetActive(false);
        Info.SetActive(false);
        totalInfo.SetActive(false);
        pauseWindow.SetActive(false);
        canvases.SetActive(false);
        audio = GetComponent<AudioSource>();
        countScript = GetComponent<Objectcount>();
    }

    public void OnClickStartButton()
    {
        PlayerPrefs.SetInt("Loop", 0);
        time = 100f; // 제한 시간 설정
        timeLimit = 0.0f;
        CoverImage.SetActive(false);
        isChecked = true;
        timeText.color = Color.green;
        audio.Play();
    }

    public void Restart()
    {
        audio.Stop();
        fires.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    private void volume()
    {
        audio.volume = 0.01f; // 초기 볼륨 설정
        audio.Play();
        while (sirenTime > sirenTimeLimit)
        {
            audio.volume += 0.1f; // 음량을 점진적으로 증가
            sirenTime -= 0.5f;
        }
        audio.volume = 0.2f; // 최종 볼륨을 낮추는 부분 추가
    }
    public void OnclickInfoButton()
    {
        clear.SetActive(false);
        totalInfo.SetActive(true);
    }

    public void OnclickClearButton()
    {
        totalInfo.SetActive(false);
        clear.SetActive(true);
    }

    public void BacktoLobby()
    {
        PlayerPrefs.SetInt("PlayCount", 0);
        SceneManager.LoadScene(1);
    }

    private void speedUp(float spd)
    {
        audio.pitch = spd;
        // audio.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / spd);
    }



    // Update is called once per frame
    void Update()
    {
        // Player.transform.position = new Vector3(0, 6, 0);

        if (isChecked == true)
        {
            var rightAButton = actionAsset.actionMaps[5].actions[0].ReadValue<float>();

            if (rightAButton == 1)
            {
                saveButton = 1;
            }
            else
            {
                if (isPause == true && pauseWindow.activeSelf == false)
                {
                    saveButton = 0;
                }
            }
            if (isPause == false && saveButton == 1)
            {
                pauseWindow.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
                return;
            }
            else if (isPause == true && pauseWindow.activeSelf == false)
            {
                Time.timeScale = 1;
                isPause = false;
                return;
            }


            if (!hasAppeared && isPause == false)
            {
                if (countScript.getCount() == countScript.getObcount())
                {
                    isChecked = false;
                    isclear = true;
                    canvases.SetActive(true);
                    Info.SetActive(true);
                    audio.Stop();
                    audio.clip = applause;
                    audio.Play();
                }
                if (time >= 60f)
                {
                    if (time <= 60f)
                    {
                        speed = 1.7f;
                        speedUp(speed);
                    }
                    else if (time <= 90f)
                    {
                        speed = 1.5f;
                        speedUp(speed);
                    }
                    else if (time <= 110)
                    {
                        speed = 1.2f;
                        speedUp(speed);
                    }
                    time -= Time.deltaTime;
                    min = (int)time / 60;
                    sec = time % 60;
                    timeText.text = min + ":" + (int)sec;
                }
                if (time < 60f)
                {
                    if (time == 30f)
                    {
                        speed = 2f;
                        speedUp(speed);
                    }
                    time -= Time.deltaTime;
                    min = (int)time / 60;
                    sec = time % 60;
                    timeText.text = "0:" + (int)sec;
                    timeText.color = Color.red;
                }
                if (time <= timeLimit)
                {
                    RestartButton.SetActive(true);
                    hasAppeared = true;
                    fires.SetActive(true);
                    audio.Stop();
                    audio.clip = audioClip;
                    audio.volume = 0.2f; // 여기서도 음량을 낮춤
                    audio.pitch = 0.7f;
                    volume();
                    PlayerPrefs.SetInt("PlayCount", ++gamePlay);
                }
            }
        }
    }
}
