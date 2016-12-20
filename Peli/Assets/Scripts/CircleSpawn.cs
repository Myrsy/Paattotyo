using UnityEngine;
using System.Collections;

public class CircleSpawn : MonoBehaviour 
{
	public float radius;
	public Transform enemy1, enemy2;
	public GameObject player;
	public float e1SpawnTime, e2SpawnTime;
	public float spawnRate;
	public float acceleration;
	int numOfEnemy1 = 2;
	int numOfEnemy2 = 3;
	Experience experience;
	public GameObject gameController;

	void Awake ()
	{
		experience = gameController.GetComponent <Experience> ();
	}

	void Update ()
	{
		if (spawnRate > 0f && Time.time > e1SpawnTime) 
		{
			e1Spawn ();
		}

		if (spawnRate > 0f && Time.time > e2SpawnTime && experience.currentLevel >= 2) 
		{
			e2Spawn ();
		}
	}

	public void SpawnAcceleration ()
	{
		spawnRate -= acceleration;
	}
	void e1Spawn ()
	{
		e1SpawnTime = Time.time + spawnRate;
		for (int i = 0; i < numOfEnemy1; i++)
		{
			float randomAngle = 360 / Random.value;
			float currentRotation = randomAngle * i;
			Transform enemy;

			enemy = Instantiate (enemy1, player.transform.position, player.transform.rotation) as Transform;
			enemy.transform.Rotate (new Vector3 (0, currentRotation, 0));
			enemy.transform.Translate (new Vector3 (radius, 0, 0));
		}
	}

	void e2Spawn ()
	{
		e2SpawnTime = Time.time + Random.Range (15f, 20f);
		for (int i = 0; i < numOfEnemy2; i++) 
		{
			float randomAngle = 360 / Random.value;
			float currentRotation = randomAngle * i;
			Transform enemy;

			enemy = Instantiate (enemy2, player.transform.position, player.transform.rotation) as Transform;
			enemy.transform.Rotate (new Vector3 (0, currentRotation, 0));
			enemy.transform.Translate (new Vector3 (radius, 0, 0));
		}

	}
}
