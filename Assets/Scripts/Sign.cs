using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using UnityEngine.UI;

public class userData
{
    public string id;
    public string pw;
    public string factoryTime;
    public string restaurantTime;
    public string houseTime;
}

public class user
{
    public string email;
    public string password;
}

public class Sign : MonoBehaviour
{
    public Button LoginButton;
    public Button SignupSubmitButton;
    public TMP_Text loginID;
    public TMP_Text loginPwd;
    public TMP_Text txtUID;
    public TMP_Text txtPwd;
    public TMP_Text errorText; // Add this to show error messages
    public GameObject errorCanvas;

    private string serverPath = "http://localhost:8000/api/users";

    private void Start()
    {
        this.LoginButton.onClick.AddListener(() =>
        {
            Debug.Log("Login button clicked");
            this.Login(loginID.text, loginPwd.text);
        });

        this.SignupSubmitButton.onClick.AddListener(() =>
        {
            Debug.Log("Signup button clicked");
            this.Signup(txtUID.text, txtPwd.text);
        });
    }

    private void Signup(string id, string pw)
    {

        var json = JsonConvert.SerializeObject(new user { email = id, password = pw});
        Debug.Log(json);

        StartCoroutine(this.Post("register", json));
    }
    private void Login(string id, string pw)
    {
        var json = JsonConvert.SerializeObject(new user { email = id, password = pw});

        StartCoroutine(this.Post("login", json));
    }

    private IEnumerator Post(string uri, string data)
    {
        var url = string.Format("{0}/{1}", this.serverPath, uri);
        Debug.Log(url);
        Debug.Log(data);

        var req = new UnityWebRequest(url, "POST");
        byte[] body = Encoding.UTF8.GetBytes(data);
        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.ConnectionError ||
            req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error: {req.error}, Response Code: {req.responseCode}");
        }
        else
        {
            Debug.Log(req.downloadHandler.text);
        }
    }
}