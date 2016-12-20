using UnityEngine;
using System.Collections;

public class MaxLevelHp : MonoBehaviour 
{
	// Tää skripti on vielä kesken
	// Sen tarkoitus on luoda pelaajalle jokin erikoistehoste, jos hän levutta HP:n max levulle
	Experience experience;
	public GameObject shield;
	ShieldProperties shieldProperties;
	public GameObject shieldHpDisplay;
	public bool shieldActive;
	public bool shieldReady;
	public float shieldTime;
	public float shieldCd;
	PlayerHealth playerHealth;

	void Awake ()
	{
		shieldActive = false;
		shieldReady = true;
		experience = GetComponent <Experience> ();
		playerHealth = GameObject.Find ("Player").GetComponent <PlayerHealth> ();
	}

	void Update ()
	{
		if (experience.healthLevel == 4 && Input.GetButton ("Fire2") && shieldReady == true && playerHealth.death == false)
		{
			shieldActive = true;
		}
		if (shieldActive == true)
		{
			shield.SetActive (true);
			StartCoroutine (disableShield());
		}
		if (shieldActive == false) 
		{
			StartCoroutine (shieldCooldown ());
		}
	}

	IEnumerator disableShield ()
	{
		yield return new WaitForSeconds (shieldTime);
		shield.SetActive (false);
		shieldActive = false;
		shieldReady = false;
	}

	IEnumerator shieldCooldown ()
	{
		yield return new WaitForSeconds (shieldCd);
		shieldReady = true;
	}
}
