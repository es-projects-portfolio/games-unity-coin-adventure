/*using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Proyecto26;

/// <summary>
/// Handle the Level load event.
/// </summary>
public class TriggerLevelLoad : MonoBehaviour
{

	public string nameOfLevelToLoad = "";
	public string db_url = "https://coin-adventure-a4119-default-rtdb.asia-southeast1.firebasedatabase.app/";

	/// <summary>
	/// Called when the Collider "other" enters the trigger.
	/// Used for things like bullets, which are triggers.
	/// See https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
	/// </summary>
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			int CurrentScore = PlayerPrefs.GetInt("CurrentScore");
			PostToDb();

			*//*int ScoreFromDB = PlayerPrefs.GetInt("TotalScore");
			int TotalScore = CurrentScore + ScoreFromDB;
			PlayerPrefs.SetInt("TotalScore", TotalScore);
			Debug.Log("Total Score = " + TotalScore);*//*

			SceneManager.LoadScene(nameOfLevelToLoad);
		}
	}

	private void PostToDb()
	{
		User user = new User();
		name = PlayerPrefs.GetString("username");
		RestClient.Put(db_url + name + ".json", user);
	}
}
*/