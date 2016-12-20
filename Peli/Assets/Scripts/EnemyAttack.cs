using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public int attackDamage = 20;
	public float timeBetweenAttacks = 0.50f;
	float timer;
	bool playerInRange;


	// Jos pelaaja koskettaa vihollista, pelaaja on vihollisen hyökkäysalueella
	void OnCollisionEnter (Collision other)
	{
		if (other.collider.name == "Player" || other.collider.name == "Weapon")
		{
			playerInRange = true;
		}
	}

	// Jos pelaaja ei enää kosketa vihollista, pelaaja ei ole vihollisen hyökkäysalueella
	void OnCollisionExit (Collision other)
	{
		if (other.collider.name == "Player" || other.collider.name == "Weapon")
		{
			playerInRange = false;
		}
	}

	void Update ()
	{
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange) 
		{
			Attack ();
		}
	}

	void Attack ()
	{
		timer = 0f;
		GameObject player = GameObject.Find ("Player");
		player.GetComponent<PlayerHealth> ().TakeDamage (attackDamage);
	}
}