using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Backend.Database;
using Backend;
using UnityEngine.SceneManagement;

public class EndGameDb : MonoBehaviour
{
    public DBHandler dbh;
    public InternalDB idb;

    public TMP_Text Score;
    // Start is called before the first frame update

    public string SceneName = "";

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void PostScore()
    {
        float score = PlayerPrefs.GetFloat("score")*10;
        dbh.PostDailyScore((int)score);
        PlayerPrefs.SetFloat("score", 0);
        LoadTargetScene();
/*        Score.text = score + "";*/
    }

    public void RefreshPage()
    {
        string url = "https://test-games.metaxar.io/game-play/99F6E542A45BA61E";
        Application.OpenURL(url);
    }
}
