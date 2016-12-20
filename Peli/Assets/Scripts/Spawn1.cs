using UnityEngine;
using System.Collections;

public class Spawn1 : MonoBehaviour
{
	// En osannut tehdä yhtä skriptiä, joka synnyttäisi vihollisia yhtä aikaa joka puolelta, joten tein joka puolelle yhden
	public GameObject enemy1;
	public GameObject enemy2;
	float spawnTime;						//Spawni aika enemy1
	float otherSpawnTime;					//Spawni aika enemy2
	public float spawnRate;
	public float acceleration;
		
	void Update ()
	{
		if (spawnRate > 0f && Time.time > spawnTime) 
		{
			// Spawni aika lyhenee joten vihollisia alkaa tulla enemmän
			spawnRate -= Time.deltaTime * acceleration;
			Spawn ();
		}

		if (spawnRate > 0f && Time.time > otherSpawnTime)
		{
			OtherSpawn ();
		}

		if (spawnRate <= 1f) 
		{
			spawnRate = 1f;
		}
	}

	// Enemy1 spawnaus
	void Spawn ()
	{
		spawnTime = Time.time + spawnRate;
		Vector3 spawnPosition = new Vector3 (27.5f, 0f, Random.Range(-15f,15f));
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (enemy1, spawnPosition, spawnRotation);
	}

	// Enemy2 spawnaus
	void OtherSpawn ()
	{
		otherSpawnTime = Time.time + Random.Range (10f, 25f);
		Vector3 spawnPosition = new Vector3 (27.5f, 0f, Random.Range(-15f,15f));
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (enemy2, spawnPosition, spawnRotation);
	}

	// Spawni tuhoaa kaikki panokset, jotka osuvat siihen
	void OnTriggerEnter (Collider other)
	{ 
		if (other.gameObject != GameObject.Find ("Player"))	
		{
			Destroy (other.gameObject);
		}
	}
}