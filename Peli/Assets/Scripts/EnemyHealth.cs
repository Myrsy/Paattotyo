using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public float startingHealth = 100f;
	public float currentHealth;
	public int score = 5;				// Vihollisen taposta saadut pisteet
	public float exp = 10f;				// Vihollisen taposta saadut kokemuspisteet
	public GameObject explosion;

	Scoring scoring;
	Experience experience;

	void Awake ()
	{
		currentHealth = startingHealth;
		scoring = GameObject.FindGameObjectWithTag ("GameController").GetComponent <Scoring> ();
		experience = GameObject.FindGameObjectWithTag ("GameController").GetComponent <Experience> ();
	}

	// Vihollinen kuolee, jos sen hp on 0 tai pienempi
	// Pelaaja saa silloin pisteitä ja xp:tä
	// Vihollisen kuollessa syntyy myös pieni räjähdysefekti
	public void EnemyTakeDamage (float amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0) 
		{
			Instantiate (explosion, transform.position, Quaternion.LookRotation (Vector3.up));
			scoring.GetScore (score);
			experience.GetExp (exp);
			Destroy (gameObject);
		}
	}
}
