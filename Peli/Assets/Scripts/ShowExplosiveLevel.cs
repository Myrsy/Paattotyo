using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowExplosiveLevel : MonoBehaviour 
{
	// Kun pelaaja saa levun, tämän skriptin avulla pelaaja näkee räjähteen levun
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
			text.text = ("Level " + experience.explosionLevel).ToString ();
		}
	}
}