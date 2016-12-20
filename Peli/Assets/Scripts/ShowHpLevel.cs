using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowHpLevel : MonoBehaviour 
{
	// Kun pelaaja saa levun, tämän skriptin avulla pelaaja näkee HP:n levun
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
			text.text = ("Level " + experience.healthLevel).ToString ();
		}
	}
}