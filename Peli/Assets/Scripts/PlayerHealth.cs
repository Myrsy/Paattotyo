using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageFlash;
	public float flashDuration = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 1f);
	public GameObject youDied;
	public GameObject shield;
	bool damaged;
	new Rigidbody rigidbody;
	new Collider collider;
	public AudioClip gameOverSound;
	AudioSource source;
	PlayerController playerController;
	Shooting shooting;
//	ShieldProperties shieldProperties;
	public bool death;

	void Awake()
	{
		death = false;
		rigidbody = gameObject.GetComponent<Rigidbody> ();
		collider = gameObject.GetComponent<Collider> ();
		currentHealth = maxHealth;
		playerController = GetComponent<PlayerController> ();
		shooting = GameObject.Find ("Shot Spawn").GetComponent <Shooting> ();
		source = GetComponent <AudioSource> ();
//		shieldProperties = shield.GetComponent<ShieldProperties> ();
	}

	// Jos pelaaja ottaa damagea, ruutu välähtää punaisena ja pelaaja menettää HP:tä
	void Update()
	{
		healthSlider.value = currentHealth;

		if (damaged == true) 
		{
			damageFlash.color = flashColor;
		}
		else 
		{
			damageFlash.color = Color.Lerp (damageFlash.color, Color.clear, flashDuration * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage (int amount) 
	{
		damaged = true;
		//if (shieldProperties.shieldActive == false) 
		{
			currentHealth -= amount;
		}
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Death ();
		} 
	}

	// Pelaajan kuollessa tulee kuolemismusa (joka joskus toistuu useammin kuin kerran (pitää korjata joskus)), 
	// pelaajaa ei voi ohjata eikä ampua, 
	// pelaajan vauhti hidastuu ja viholliset pääsevät kulkemaan sen läpi
	// ja lisäksi peli ilmoittaa "You Died"
	void Death ()
	{
		death = true;
		source.PlayOneShot (gameOverSound);
		playerController.enabled = false;
		shooting.enabled = false;
		rigidbody.freezeRotation = true;
		rigidbody.drag = 0.5f;
		collider.isTrigger = true;
		youDied.SetActive (true);
	}
}
