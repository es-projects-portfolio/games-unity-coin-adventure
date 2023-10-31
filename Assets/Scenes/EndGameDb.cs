/*using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameDb : MonoBehaviour
{
    public Time time;
    public TMP_Text CurrentScoreText;
    public int currentScore = 0;

    User user = new User();
    public int TotalScore;

    [SerializeField] public string db_url = "https://fir-claim-default-rtdb.asia-southeast1.firebasedatabase.app/";
    private void Awake()
    {
        //Current Score post to database
        User user = new User();
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        CurrentScoreText.text = "" + currentScore;

        name = PlayerPrefs.GetString("username");
        RestClient.Put(db_url + name + ".json", user);
    }

    public string TimeOfEvents()
    {
        int hour = System.DateTime.Now.Hour;
        int minutes = System.DateTime.Now.Minute;
        int seconds = System.DateTime.Now.Second;

        string toe = "" + hour + ":" + minutes + ":" + seconds;
        return toe;
    }

    //This will happen when the user proceed to mainnn menu or play again scene
    //Call CurrentScore (PlayerPrefs) to add with TotalScore (Db)
    //TotalScore = TotalScore + CurrentScore
    public void NextScene()
    {

        currentScore = PlayerPrefs.GetInt("CurrentScore");
        name = PlayerPrefs.GetString("username");
        *//*RestClient.Get<User>(db_url + name + ".json").Then(response =>
        {
            user = response;
            *//*int ScoreFromDb = user.TotalScore;
            TotalScore = currentScore + ScoreFromDb;*//*
            PlayerPrefs.SetInt("TotalScore", user.TotalScore);
        });*//*
        TotalScore = TotalScoreDB(currentScore);
        string time = TimeOfEvents();
        PlayerPrefs.SetString("Time_TotalScoreUpdated", time);
        PostToDb();
        Debug.Log("Total Score = " + TotalScore);
        Debug.Log("Current score resets. Current score = " + CurrentScoreReset());

    }

    private void PostToDb()
    {
        User user = new User();
        name = PlayerPrefs.GetString("username");
        RestClient.Put(db_url + name + ".json", user);
    }

    public int TotalScoreDB(int cs)
    {
        int ScoreFromDB = PlayerPrefs.GetInt("TotalScore");
        int finalScore = ScoreFromDB + cs;
        PlayerPrefs.SetInt("TotalScore", finalScore);
        return finalScore;
        
    }

    public int CurrentScoreReset()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        return currentScore;
    }
}
*/