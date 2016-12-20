using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{
	public GameObject enemyShot;
	public Transform enemyShotSpawn;
	public float fireRate;
	public GameObject shotParticles;
	float nextFire;
	public AudioClip shootSound;
	AudioSource source;

	PlayerHealth playerHealth;

	void Awake ()
	{
		playerHealth = GameObject.Find ("Player").GetComponent <PlayerHealth> ();
		source = GetComponent <AudioSource> ();
	}

	void Start ()
	{
		// Vihollisten tulinopeus vaihtelee yksilöiden välillä
		fireRate = Random.Range (1f, 4f);
	}

	void Update ()
	{
		nextFire += Time.deltaTime;
		if (nextFire > fireRate && playerHealth.currentHealth > 0) 
		{
			Shoot ();
		}
	}

	void Shoot ()
	{
		nextFire = 0f;
		Instantiate (shotParticles, enemyShotSpawn.position, enemyShotSpawn.rotation);
		Instantiate (enemyShot, enemyShotSpawn.position, enemyShotSpawn.rotation);
		source.PlayOneShot (shootSound);
	}

}
