using UnityEngine;
using System.Collections;

public class EnemyBulletProperties : MonoBehaviour 
{
	// Tämä skripti sisältää vihollisten ampumien ammusten ominaisuudet
	public float shotSpeed;
	public int bulletDamage = 25;
	public GameObject shield;
//	ShieldProperties shieldProperties;

/*	void Awake ()
	{
		shieldProperties = shield.GetComponent <ShieldProperties> ();
	}*/

	void Start () 
	{
		Destroy (gameObject, 6f);
		GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
	}

	void OnTriggerEnter(Collider other)
	{	
		// Jos ammus osuu pelaajan, pelaaja ottaa damagea ja ammus tuhoutuu
		PlayerHealth playerHealth = other.GetComponent <PlayerHealth> ();
		if (playerHealth != null)
		{
			playerHealth.TakeDamage (bulletDamage);
			Destroy (gameObject);
		}
		if (other.name == "Shield")
			Destroy (gameObject);
/*		shieldProperties = other.GetComponent <ShieldProperties> ();
		if (shieldProperties != null )//&& shieldProperties.shieldActive == true) 
		{
			Destroy (gameObject);
		}*/
	}
}
