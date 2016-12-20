using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour
{
	// Skripti laskee pelaajan pisteet ja päivittää ne ruudulle
	public int currentScore;
	public Text text;

	void Awake ()
	{
		currentScore = 0;
	}

	public void GetScore (int amount)
	{
		currentScore += amount;
	}

	void Update ()
	{
		text.text = currentScore.ToString ();
	}
}
