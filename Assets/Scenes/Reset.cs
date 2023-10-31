/*using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public void ResetValue()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("TotalScore", 0);
        PlayerPrefs.SetInt("TokensClaimed", 0);
        *//*PlayerPrefs.SetString("username", "");*//*
        DisplayValue();
        PostToDb();
    }

    private void DisplayValue()
    {
        int CurrentScore = PlayerPrefs.GetInt("CurrentScore");
        int TotalScore = PlayerPrefs.GetInt("TotalScore");
        int TokensClaimed = PlayerPrefs.GetInt("TokensClaimed");

        Debug.Log("Resetting ..");
        Debug.Log("Current score = " + CurrentScore);
        Debug.Log("Total score = " + TotalScore);
        Debug.Log("Tokens Claimed = " + TokensClaimed);
    }

    private void PostToDb()
    {
        string db_url = PlayerPrefs.GetString("db_url");
        string db_key = PlayerPrefs.GetString("db_key");
        string db_key_write = PlayerPrefs.GetString("db_key_write");
        User user = new User();
        name = PlayerPrefs.GetString("username");
        if (name != null || name != "")
        {
            RestClient.Put(db_url + name + db_key_write, user);
        }
    }


}
*/