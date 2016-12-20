using UnityEngine;
using System.Collections;

public class MaxLevelFireRate : MonoBehaviour 
{
	// Jos pelaaja levuttaa fire raten max levuun, pelaaja alkaa ampumaan viiden panoksen sarjoja, jotka lävistävät kaikki viholliset
	// En osaa vielä kuitenkaan sanoa onko se pelin tasapainon kannalta vielä muuntelun tarpeessa
	public GameObject bullet;
	Experience experience;
	public Shooting shooting;
	float nextFire;
	public float fireRate;
	public Transform shotSpawn;
	public GameObject shotParticles;
	public AudioClip shootSound;
	AudioSource source;
	PlayerHealth playerHealth;

	int numOfBullets = 5;

	void Awake ()
	{
		experience = GetComponent <Experience> ();
		source = GetComponent <AudioSource> ();
		playerHealth = GameObject.Find("Player").GetComponent <PlayerHealth> ();
	}

	void Update ()
	{
		nextFire += Time.deltaTime;
		if (experience.fireRateLevel == 4)
		{
			fireRateMax ();
		}
	}

	void fireRateMax ()
	{
		shooting.enabled = false;
		if (Input.GetButton ("Fire1") && nextFire >= fireRate && playerHealth.death == false) 
		{
			nextFire = 0f;
			source.PlayOneShot (shootSound);
			for (int i = 0; i < numOfBullets; i++) 
			{
				Instantiate (shotParticles, shotSpawn.position, shotSpawn.rotation);
				Instantiate (bullet, shotSpawn.position, shotSpawn.rotation);
			}
		}
	}
}
