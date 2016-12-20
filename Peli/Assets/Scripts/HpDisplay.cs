using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpDisplay : MonoBehaviour 
{
	PlayerHealth playerHealth;
	Text text;

	void Awake ()
	{
		playerHealth = GameObject.Find ("Player").GetComponent <PlayerHealth> ();
		text = GetComponent <Text> ();
	}

	void Update ()
	{
		text.text = ("HP " + playerHealth.currentHealth + "/" + playerHealth.maxHealth).ToString ();
	}

}
