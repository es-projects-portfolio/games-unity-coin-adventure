/*using System;
using System.Net.Http;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using Proyecto26;

public class NewBackend : MonoBehaviour
{
    public static NewBackend Instance { get; private set; }

    public string bearer;
    *//*public string bearer_mainnet;*//*
    public string auth;
    public string baseUrl;
    public string token_name;
    public string token_id;
    
    public string game_id;
    public static string username;
    public static int tokenAmount = 0;
    public TMP_Text authText;
    public TMP_Text amountText;
    public float originalFontSize = 0;
    // public TMP_Text tokentext;
    public HttpClient client = new HttpClient();
    public string deeplinkURL;

    //public string bearer ;
    public TMP_Text bearerText;



    private void Awake()
    {
        PlayerPrefs.SetString("bearer", bearer);

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
            GetDBToken();
        }));
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

    *//*public void SetDBScore(int score)
    {
        var newscore = PlayerPrefs.GetInt("score-" + username) + score;
        PlayerPrefs.SetInt("score-" + username, score);
    }*//*

    public void GetDBToken()
    {
 
    }



    public IEnumerator GetUser(Action callback)
    {

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
            username = jsonData["username"];
            PlayerPrefs.SetString("name", username);

            name = PlayerPrefs.GetString("name");
            RestClient.Put("https://fir-token-ccdbb-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json", user);

            authText.text = username;
            Debug.Log("User retrieved.");
            callback.Invoke();
        }
    }

    public static string nama()
    {
        string n = PlayerPrefs.GetString("name");
        return n;
    }

    public static int point()
    {
        int s = PlayerPrefs.GetInt("Score");
        return s;
    }


    public void VoidClaimToken()
    {
        Debug.Log("Clicked claim button");
        StartCoroutine(ClaimToken());
        *//*StartCoroutine(ClaimToken_Mainnet());*//*
    }


    public IEnumerator ClaimToken()
    {
        //bearer = PlayerPrefs.GetString("Bearer");
        //Get from firestore
        int score = PlayerPrefs.GetInt("Score");
        var amount = score/20*5;
        var id_igt = token_id;
        var cert = new ForceAcceptAll();

        Debug.Log("Total token recieved: " + amount);
        //var amount = PlayerPrefs.GetInt("IGT");
        Debug.Log("Claiming Token in Testnet " + id_igt);

        UnityWebRequest request = new UnityWebRequest($"{baseUrl}/api/v1/transactions/distribute?TokenId={id_igt}&Amount={amount}&Auth={auth}", "POST");
        request.SetRequestHeader("Authorization", "Bearer " + bearer);

        request.certificateHandler = cert;

        // Send
        cert?.Dispose();

        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Claim token amount: " + amount);
            Debug.Log("Error :(");
            // onErrorCallback(request.result);
            Debug.LogError(request.error, this);
        }
        else
        {
            Debug.Log("Claim token amount: " + amount);
            PlayerPrefs.SetInt("Score", 0);
            //PlayerPrefs.SetInt("score-" + username, 0);
            GetDBToken();
            Debug.Log("Claimed Token. Please check Xarcade.");
            
        }
    }

    *//*public IEnumerator ClaimToken_Mainnet()
    {
        //bearer = PlayerPrefs.GetString("Bearer");
        //Get from firestore
        int score = PlayerPrefs.GetInt("Score");
        var amount = score / 20 * 5;
        var id_igt = token_id_mainnet;
        var cert = new ForceAcceptAll();

        Debug.Log("Total token recieved: " + amount);
        //var amount = PlayerPrefs.GetInt("IGT");
        Debug.Log("Claiming Token in Mainnet " + id_igt);

        UnityWebRequest request = new UnityWebRequest($"{baseUrl}/api/v1/transactions/distribute?TokenId={id_igt}&Amount={amount}&Auth={auth}", "POST");
        request.SetRequestHeader("Authorization", "Bearer " + bearer);

        request.certificateHandler = cert;

        // Send
        cert?.Dispose();

        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Claim token amount: " + amount);
            Debug.Log("Error :(");
            // onErrorCallback(request.result);
            Debug.LogError(request.error, this);
        }
        else
        {
            Debug.Log("Claim token amount: " + amount);
            PlayerPrefs.SetInt("Score", 0);
            //PlayerPrefs.SetInt("score-" + username, 0);
            GetDBToken();
            Debug.Log("Claimed Token. Please check Xarcade.");
            string claim = "Claimed!";
        }
    }*//*



    public IEnumerator Login(string email, string password)
    {
        var cert = new ForceAcceptAll();
        //bearer = PlayerPrefs.GetString("Bearer");
        Debug.Log("login lmao ");
        string url = "https://xarcade-api.proximaxtest.com";
        string body = "{ \"username\":\"" + username + "\", \"password\":\"" + password + "\"}";

        using (UnityWebRequest request = UnityWebRequest.Put(url + "/users/login", body))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            request.certificateHandler = cert;

            // Send
            cert?.Dispose();

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error :(");
                Debug.LogError(request.error, this);
            }
            else
            {
                Debug.Log("login Success!");

            }
        }
    }

    public void OpenLogin()
    {
        //bearer = PlayerPrefs.GetString("Bearer");
        Application.OpenURL("https://xarcade-gamer.proximaxtest.com/android-auth/" + game_id + "/tt:%2F%2Fauth");
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
            GetDBToken();
        }));

        //login.SetActive(false);
        Debug.Log("Opened from deeplink!");
    }

}
*/