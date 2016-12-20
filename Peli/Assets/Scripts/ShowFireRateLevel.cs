using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowFireRateLevel : MonoBehaviour 
{
	// Kun pelaaja saa levun, tämän skriptin avulla pelaaja näkee tulinopeuden levun
	Experience experience;
	Text text;

	void Awake ()
	{
		experience = GameObject.Find ("GameController").GetComponent <Experience> ();
		text = GetComponent <Text> ();
	}

	void Update ()
	{
		if (experience.lvlUp == true) 
		{
			text.text = ("Level " + experience.fireRateLevel).ToString ();
		}
	}
}