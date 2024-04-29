using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using Unity.VisualScripting;
using System.Data;

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
    bool isChecked = false;
    bool hasAppeared = false;

    [Header("BGM")]
    private AudioSource audio;
    private float speed;

    [Header("Is Clear?")]
    private Objectcount countScript;
    private bool isclear = false;
    public GameObject infoWindows;
    public AudioClip applause;

    [Header("Clear Window")]
    public GameObject clear; // 클리어창
    public GameObject totalInfo;

    public bool isActiveInfo()
    {
        return infoWindows.activeSelf;
    }
    
    public bool getIsclear()
    {
        return isclear;
    }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false);
        fires.SetActive(false);
        clear.SetActive(false);
        totalInfo.SetActive(false);
        infoWindows.SetActive(false);
        audio = GetComponent<AudioSource>();
        countScript = GetComponent<Objectcount>();
    }

    public void OnClickStartButton()
    {
        time = 100f;
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
        audio.volume = 0.01f;
        audio.Play();
        while (sirenTime > sirenTimeLimit)
        {
            audio.volume += 0.5f;
            sirenTime -= 0.5f;
        }
    }
    public void OnclickInfoButton()
    {
        clear.SetActive(false);
        totalInfo.SetActive(true);
    }
    public void BacktoLobby()
    {
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

        if (isChecked == true){
            if (!hasAppeared) {
                if (countScript.getCount() == countScript.getObcount())
                {
                    isChecked = false;
                    infoWindows.SetActive(true);
                    isclear = true;
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
                    timeText.text = "0:" +  (int)sec;
                    timeText.color = Color.red;
                }
                if(time <= timeLimit)
                {
                    RestartButton.SetActive (true);
                    hasAppeared = true;
                    fires.SetActive(true);
                    audio.Stop();
                    audio.clip = audioClip;
                    audio.pitch = 0.7f;
                    volume();
                }
            }
        }
        
        

        
    }




}
