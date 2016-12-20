using UnityEngine;
using System.Collections;

public class EnemyLevelling : MonoBehaviour 
{
	Experience experience;
	EnemyMovement enemyMovement;
//	EnemyShooting enemyShooting;
	EnemyHealth enemyHealth, enemy2Health;
	public CircleSpawn circleSpawn;
	public GameObject enemy1, enemy2;
//	public bool enemyLvlling;
//	bool enemyLvlUp;
//	GameObject enemy = enemy1 && enemy2;

	void Awake ()
	{
		experience = gameObject.GetComponent<Experience> ();
		enemyMovement = enemy1.GetComponent <EnemyMovement> ();
//		enemyShooting = enemy2.GetComponent <EnemyShooting> ();
		enemyHealth = enemy1.GetComponent <EnemyHealth> ();
		enemy2Health = enemy2.GetComponent <EnemyHealth> ();
//		enemyLvlUp = false;
		enemyHealth.startingHealth = 40;
		enemy2Health.startingHealth = 50;
		enemyMovement.speed = 4;
	}

	void Update ()
	{
//		Debug.Log (enemyHealth.startingHealth);
//		Debug.Log (enemyMovement.speed);
		if (experience.enemyLvlUp == true)
		{
			experience.enemyLvlUp = false;
			enemyHealth.startingHealth += 5;
			enemy2Health.startingHealth += 10;
			enemyMovement.speed += 0.5f;
			circleSpawn.SpawnAcceleration ();
			if (experience.fireRateLevel == 4 || experience.movementSpeedLevel == 4 || experience.explosionLevel == 4 || experience.healthLevel == 4)
			{
				enemyMovement.speed += 1;
				circleSpawn.acceleration += 0.2f;
			}
		}
		else 
		{
			return;
		}
	}
}
