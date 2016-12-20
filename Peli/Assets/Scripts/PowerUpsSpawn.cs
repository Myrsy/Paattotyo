using UnityEngine;
using System.Collections;

public class PowerUpsSpawn : MonoBehaviour 
{
	// En ole varma tuleeko pelissä olemaan muita kerättäviä bonuksia kuin räjähde
	public Transform explosive;
	public GameObject player;
	public float spawnRate;
	float spawnTime;
	Experience experience;
	public float radius;
	public bool maxLvlExplosion;

	int numOfExplosions;

	void Awake ()
	{
		experience = GameObject.Find ("GameController").GetComponent<Experience> ();
		//maxLvlExplosion = false;
		numOfExplosions = 1;
	}

	void Start ()
	{
		InvokeRepeating ("PowerUpSpawn", spawnRate, spawnRate);
	}

	void Update ()
	{
		if (experience.explosionLevel == 4) 
		{
			maxLvlExplosion = true;
		} 
		else 
		{
			maxLvlExplosion = false;
		}
	}

	public void PowerUpSpawn ()
	{
		for (int i = 0; i < numOfExplosions; i++)
		{
//			Instantiate (explosive, new Vector3 (Random.Range (-44f, 44f), 0f, Random.Range (-24f, 24f)), Quaternion.identity);
			float randomAngle = 360 / Random.value;
			float currentRotation = randomAngle * i;
			Transform powerUp;

			powerUp = Instantiate (explosive, player.transform.position, player.transform.rotation) as Transform;
			powerUp.transform.Rotate (new Vector3 (0, currentRotation, 0));
			powerUp.transform.Translate (new Vector3 (radius, 0, 0));
		}

		if (maxLvlExplosion == true) 
		{
			numOfExplosions = 3;
		}
	}
}
