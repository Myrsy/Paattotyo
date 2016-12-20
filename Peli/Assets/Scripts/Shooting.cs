using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{

	public GameObject shot;
	public Transform shotSpawn;
	public GameObject shotParticles;
	public float fireRate;
	private float nextFire;
	public AudioClip shootSound;
	AudioSource source;
	PlayerController playerController;
	Experience experience;
	bool shooting;

	void Awake ()
	{
		playerController = GameObject.Find ("Player").GetComponent <PlayerController> ();
		experience = GameObject.Find ("GameController").GetComponent <Experience> ();
		source = GetComponent <AudioSource> ();
	}

	// Jos pelaaja painaa mouse1, hahmo ampuu ja samalla sen liikkumisnopeus laskee hieman
	// Koodaus ratkaisu vaikuttaa minusta huonolta, mutta muuta ei tule mieleen ja tuo toimii
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			playerController.playerSpeed -= experience.movementSpeedLevel; 
		}

		if (Input.GetButtonUp ("Fire1"))
		{
			playerController.playerSpeed += experience.movementSpeedLevel;
		}

		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			Shoot ();
		}
	}

	void Shoot ()
	{
		nextFire = Time.time + fireRate;
		Instantiate (shotParticles, shotSpawn.position, shotSpawn.rotation);
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		source.PlayOneShot (shootSound);
	}
}
