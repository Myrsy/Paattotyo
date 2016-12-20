using UnityEngine;
using System.Collections;

public class LevelUpPause : MonoBehaviour 
{
	public GameObject lvlUpPause;

	// Jos peli pysähtyy (pelaaja saanut levun), esiin tulee tekstiä, joka informoi pelaajaa levuista
	void Update ()
	{
		if (Time.timeScale == 0) 
		{
			lvlUpPause.SetActive (true);
		}
		else 
		{
			lvlUpPause.SetActive (false);
		}

	}
}
