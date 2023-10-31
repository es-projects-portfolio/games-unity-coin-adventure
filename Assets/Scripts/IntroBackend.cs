/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Http;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using Proyecto26;

public class IntroBackend : MonoBehaviour
{
    public static IntroBackend Instance { get; private set; }

    public HttpClient client = new HttpClient();
    public string deeplinkURL;

    public string bearer;
    public string auth;
    public string baseUrl;
    public string token_id;

    public TMP_Text authText;
    public TMP_Text amountText;

    private void Awake()
    {
        PlayerPrefs.SetString("bearer", bearer);
        GetScoreFromDB();
        if (Instance == null)
        {
            Instance = this;
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                onDeepLinkActivated(Application.absoluteURL);
            }
            // Initialize DeepLink Manager global variable.
            else deeplinkURL = "[none]";
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void onDeepLinkActivated(string url)
    {
        //bearer = PlayerPrefs.GetString("Bearer");
        // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
        deeplinkURL = url;
        // Decode the URL to determine action. 
        // In this example, the app expects a link formatted like this:
        // unitydl://mylink?scene1
        this.auth = url.Split("?"[0])[1].Split("=")[1];
        authText.text = this.auth;
        StartCoroutine(GetUser(() =>
        {
            
        }));

        //login.SetActive(false);
        Debug.Log("Opened from deeplink!");
    }

    public void Start()
    {
        //Global.backend = this;
        DontDestroyOnLoad(this.gameObject);
        client = new HttpClient();
        string callbearer = PlayerPrefs.GetString("bearer");
        // originalFontSize = tokentext.fontSize;
        Debug.Log("baseurl: " + baseUrl);
        Debug.Log("bearer: " + callbearer);
        Debug.Log("user: " + auth);
#if UNITY_WEBGL
        GetAuthFromWebGL();
#endif

#if UNITY_EDITOR
        StartCoroutine(GetUser(() =>
        {
         
        }));

        GetScoreFromDB();
#endif
    }
    public class ForceAcceptAll : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }

    public void GetAuthFromWebGL()
    {
        int pm = Application.absoluteURL.IndexOf("?");
        if (pm != -1)
        {
            auth = Application.absoluteURL.Split("?"[0])[1].Split("=")[1];
            Debug.Log("new user: " + auth);
        }
    }

    public IEnumerator GetUser(Action callback)
    {
        User user = new User();
        var cert = new ForceAcceptAll();
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        // bearer = PlayerPrefs.GetString("Bearer");
        UnityWebRequest request = UnityWebRequest.Get($"{baseUrl}/api/v1/users/{auth}");
        request.SetRequestHeader("Authorization", "Bearer " + bearer);
        request.certificateHandler = cert;

        // Send
        cert?.Dispose();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error :(");
            // onErrorCallback(request.result);
            authText.text = "login error";
            Debug.LogError(request.error, this);
        }
        else
        {
            var jsonData = JSON.Parse(request.downloadHandler.text);
            string username = jsonData["username"];
            PlayerPrefs.SetString("name", username);

            name = PlayerPrefs.GetString("name");
            RestClient.Put("https://fir-token-ccdbb-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json", user);

            authText.text = username;
            Debug.Log("User retrieved.");
            callback.Invoke();
        }
    }

    public static string uname()
    {
        string name = PlayerPrefs.GetString("name");
        return name;
    }

    public static int amount()
    {
        int score = PlayerPrefs.GetInt("Score");
        return score;
    }

    User user = new User();
    private void GetScoreFromDB()
    {
        RestClient.Get<User>("https://fir-token-ccdbb-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json").Then(response =>
        {
            user = response;
            //amountText.text = "" + user.score;
        });
    }
}
*/