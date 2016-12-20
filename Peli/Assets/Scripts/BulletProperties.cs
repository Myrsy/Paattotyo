using UnityEngine;
using System.Collections;

public class BulletProperties : MonoBehaviour 
{
	public float shotSpeed;
	public int bulletDamage = 50;
	public GameObject bullet;
	Experience experience;

	float rotationX, rotationY, rotationZ;
	public float minSpread, maxSpread;

	void Awake ()
	{
		experience = GameObject.Find ("GameController").GetComponent <Experience> ();
		rotationY = Random.Range (minSpread, maxSpread);
	}

	void Start () 
	{
		Destroy (gameObject, 3f);
		// Jos fire rate level on max, panokset hajaantuvat enemmän muodosten viiden panoksen kuvion.
		if (experience.fireRateLevel == 4)
		{
			minSpread -= 10f;
			maxSpread += 10f;
			rotationY = Random.Range (minSpread, maxSpread);
		}
		// Panokset eivät kulje suoraan, vaan hajaantuvat hieman
		// Hajonta kasvaa, mitä isompi tulinopeus
		gameObject.transform.Rotate (0, rotationY, 0);
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
	}

	void Update ()
	{
		rotationY = Random.Range (minSpread, maxSpread);
	}

	void OnTriggerEnter(Collider other)
	{	
		// Jos panos osuu viholliseen, vihollinen ottaa damagea
		EnemyHealth enemyHealth = other.GetComponent <EnemyHealth> ();
		if (enemyHealth != null) 
		{
			enemyHealth.EnemyTakeDamage (bulletDamage);
		} 
		// Ammus tuhoutuu osuessaan viholliseen ellei maxlevufirerate, jolloin panokset läpäisevät viholliset.
		// Huom taas lvl2 testimielessä!
		if (other.gameObject != bullet && experience.fireRateLevel != 4 && other.gameObject.name != ("Shield"))
			Destroy (gameObject);
	}
}
