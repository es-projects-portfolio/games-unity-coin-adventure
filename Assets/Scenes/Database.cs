/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.Networking;
using TMPro;

public class Database : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text TotalScoreDbText;
    public TMP_Text TotalTokenText;
    *//*public Backend backend;*//*
    [SerializeField] public string db_url;
    private string db_key = ".json?auth=vFTi0PFeEYUCpNYcSphKBWieUqeGbc1B8Mto7MAK";
    private string db_key_write = ".json?auth=Wdcaq7c6R7i0FRSmxpJrFNHF3TK4HI52amuwgfT6";

    public GameObject claimButton;
    User user = new User();

    public string TimeOfEvents()
    {
        int hour = System.DateTime.Now.Hour;
        int minutes = System.DateTime.Now.Minute;
        int seconds = System.DateTime.Now.Second;

        string toe = "" + hour + ":" + minutes + ":" + seconds;
        return toe;
    }

    public static string LastLogin()
    {
        string login = PlayerPrefs.GetString("LoginTime");
        return login;
    }
    public static string LastTotalScoreUpdated()
    {
        string t_tscu = PlayerPrefs.GetString("Time_TotalScoreUpdated");
        return t_tscu;
    }

    public static string LastTokensClaimedUpdated()
    {
        string t_tcu = PlayerPrefs.GetString("Time_TokensClaimedUpdated");
        return t_tcu;
    }


    public static string token_id()
    {
        string token = PlayerPrefs.GetString("token_id");
        return token;
    }

    public static int CurrentScore()
    {
        int cs = PlayerPrefs.GetInt("CurrentScore");
        return cs;
    }

    public static int TotalScore()
    {
        int ts = PlayerPrefs.GetInt("TotalScore");
        return ts;
    }

    public static int TokensClaimed()
    {
        int tc = PlayerPrefs.GetInt("TokensClaimed");
        return tc;
    }

   *//* public void ClaimingToken()
    {
        int finalAmountTokens = TotalScore() + TokensClaimed();
        PlayerPrefs.SetInt("TokensClaimed", finalAmountTokens);
        PlayerPrefs.SetInt("TotalScore", 0);
        Debug.Log("'Claimed button' clicked! Processing in db ...");
        Debug.Log("Total tokens claimed in db = " + finalAmountTokens);
        Debug.Log("Total score in database resets to 0");
        TotalScoreDbText.text = "" + TotalScore();
        string time = TimeOfEvents();
        PlayerPrefs.SetString("Time_TokensClaimedUpdated", time);
        PostToDb();
    }*//*

    private void PostToDb()
    {
        User user = new User();
        name = PlayerPrefs.GetString("username");

        if (name != null || name != "") {
            RestClient.Put(db_url + name + db_key_write, user);
        }
            
    }

    public void GetFromDb()
    {
        name = PlayerPrefs.GetString("username");
        RestClient.Get<User>(db_url + name + db_key).Then(response =>
        {
            user = response;
            TotalScoreDbText.text = "" + user.e_TotalScore;
        });
        Debug.Log("hello");
    }

    public void Start()
    {
        Time.timeScale = 1;
        string username = PlayerPrefs.GetString("username");
        usernameText.text = "" + username;
        Debug.Log("user in db: " + username);
        Debug.Log("token id: " + token_id());
        Debug.Log("total score in db: " + TotalScore());
        

    }

    public void Login()
    {
        string time = TimeOfEvents();
        PlayerPrefs.SetString("LoginTime", time);
        PostToDb();
    }

    private void Awake()
    {
        PlayerPrefs.SetString("db_key", db_key);
        PlayerPrefs.SetString("db_url", db_url);
        PlayerPrefs.SetString("db_key_write", db_key_write);
        name = PlayerPrefs.GetString("username");
        RestClient.Get<User>(db_url + name + db_key).Then(response =>
        {
            user = response;
            PlayerPrefs.SetInt("TotalScore", user.e_TotalScore);
            PlayerPrefs.SetInt("TokensClaimed", user.g_TokensClaimed);

            if (user.e_TotalScore == 0)
            {
                claimButton.SetActive(false);
            }
            else { claimButton.SetActive(true); }

            if (user.g_TokensClaimed >= 10000)
            {
                claimButton.SetActive(false);
            }
            else { claimButton.SetActive(true); }
        });

        Debug.Log("Total score = " + TotalScore());

        string username = PlayerPrefs.GetString("username");
        usernameText.text = "" + username;
        TotalScoreDbText.text = "" + TotalScore();
        TotalTokens();
    }

    private void TotalTokens()
    {
        float score = (float)TotalScore();
        TotalTokenText.text = "" + score + " " + token_id();
    }

    private void Update()
    {
        //adding delay for get data
        float time = 0f;
        float timeDelay = 10f;
        time = time + 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            time = 0f;
            GetScoreFromDB();
        }
    }


    private void GetScoreFromDB()
    {
        name = PlayerPrefs.GetString("username");
        RestClient.Get<User>(db_url + name + db_key).Then(response =>
        {
            user = response;
            PlayerPrefs.SetInt("TotalScore", user.e_TotalScore);
            PlayerPrefs.SetInt("TokensClaimed", user.g_TokensClaimed);

            if (user.e_TotalScore == 0)
            {
                claimButton.SetActive(false);
            }
            else { claimButton.SetActive(true); }
        });
        Debug.Log("Get data.. Done!");
    }




}
*/