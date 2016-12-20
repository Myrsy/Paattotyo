using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Experience : MonoBehaviour 
{
	// Tästä tuli vähän hurjempi koodi
	// Luulen että tän sais toteutettuu paljon paremmin
	// Mut en oikee tiiä mitä mä teen tän hirviön kaa
	public float currentExp;
	public int expToLevel;
	public Slider expSlider;
	public Slider HPSlider;
	public GameObject bullet;
	public GameObject explosive;
	public int currentLevel;
	public int fireRateLevel;
	public int movementSpeedLevel;
	public int explosionLevel;
	public int healthLevel;
	public Text text;
	BulletProperties bulletProperties;
	PlayerHealth playerHealth;
	Shooting shooting;
	PlayerController playerMovement;
	Explosion explosion;
	PowerUpsSpawn powerUpSpawn;
	public bool lvlUp;
	public bool enemyLvlUp;
	public AudioClip lvlupSound;
	AudioSource source;

	void Awake ()
	{
		lvlUp = false;
		enemyLvlUp = false;
		expSlider.maxValue = (float)(expToLevel);
		currentExp = 0f;
		currentLevel = 1;
		fireRateLevel = 1;
		movementSpeedLevel = 1;
		explosionLevel = 1;
		healthLevel = 1;
		bulletProperties = bullet.GetComponent <BulletProperties> ();
		playerHealth = GameObject.Find ("Player").GetComponent <PlayerHealth> ();
		shooting = GameObject.Find ("Shot Spawn").GetComponent <Shooting> ();
		playerMovement = GameObject.Find ("Player").GetComponent <PlayerController> ();
		explosion = explosive.GetComponent <Explosion> ();
		powerUpSpawn = GameObject.Find ("PowerUps").GetComponent <PowerUpsSpawn> ();
		source = GetComponent <AudioSource> ();
		// Panoksien alkuperäinen hajonta
 		bulletProperties.minSpread = -2f;
 		bulletProperties.maxSpread = 2f;
	}

	// Tässä kohtaa on kaikki mitä tapahtuu kun pelaaja levuttaa jotain skilliä
	void Update ()
	{
		text.text = "Level: " + currentLevel.ToString ();

		//Taikanappi josta levutus
		/*if (Input.GetKeyDown (KeyCode.Q))
		{
			currentExp = expToLevel;
		}*/

		if (lvlUp == true) 
		{
			// Ykkösestä levuttuu tulinopeus
			if (Input.GetKeyDown (KeyCode.Alpha1))
			{
				if (fireRateLevel >= 4) 
				{
					return;
				}
				source.PlayOneShot (lvlupSound);
				fireRateLevel += 1;
				shooting.fireRate -= 0.05f;
				bulletProperties.minSpread -= 0.5f;
				bulletProperties.maxSpread += 0.5f;
				Time.timeScale = 1;
				lvlUp = false;
				LvlUpEnemy ();
			}
			// Kakkosesta levuttuu pelaajan nopeus
			if (Input.GetKeyDown (KeyCode.Alpha2)) 
			{
				if (movementSpeedLevel >= 4) 
				{
					return;
				}
				source.PlayOneShot (lvlupSound);
				movementSpeedLevel += 1;
				playerMovement.playerSpeed += 2f;
				Time.timeScale = 1;	
				lvlUp = false;
				LvlUpEnemy ();
			}
			// Kolmosesta levuttuu räjähteiden spawnausnopeus ja niiden damage radius
			if (Input.GetKeyDown (KeyCode.Alpha3)) 
			{
				if (explosionLevel >= 4) 
				{
					return;
				}
				source.PlayOneShot (lvlupSound);
				explosionLevel += 1;
				powerUpSpawn.spawnRate -= 0.5f;
				explosion.maxDamageRadius += 2f;
				powerUpSpawn.radius -= 3f;
				Time.timeScale = 1;			
				lvlUp = false;
				LvlUpEnemy ();
			}
			// Nelosesta levuttuu pelaajan HP
			if (Input.GetKeyDown (KeyCode.Alpha4)) 
			{
				if (healthLevel >= 4) 
				{
					return;
				}
				source.PlayOneShot (lvlupSound);
				healthLevel += 1;
				playerHealth.maxHealth += 40;
				playerHealth.currentHealth = playerHealth.maxHealth;
				HPSlider.maxValue = playerHealth.maxHealth;
				HPSlider.value = playerHealth.currentHealth;
				Time.timeScale = 1;				
				lvlUp = false;
				LvlUpEnemy ();
			}
		}
	}
	void LvlUpEnemy ()
	{
		enemyLvlUp = true;
	}

	public void GetExp (float amount)
	{
		expSlider.value = currentExp;
		currentExp += amount;
		Levelling ();
	}

	void Levelling ()
	{
		if (currentExp >= (expToLevel))
		{
			expToLevel = (int)(expToLevel * currentLevel * 0.2) + (expToLevel);	// Tä on jonkinlainen kaava, jonka pitäis lisätä
			currentLevel += 1;													// tarvittavan xp:n määrää levujen kasvaessa
			playerHealth.currentHealth = playerHealth.maxHealth;
			expSlider.maxValue = (float) (expToLevel);
			expSlider.value = 0f;
			currentExp = 0f;
			lvlUp = true;
		}
		// Aika pysähtyy, kun saa levun ja jatkuu levutuksen jälkeen
		if (lvlUp == true) 
		{
			Time.timeScale = 0;
		}
	}
}
