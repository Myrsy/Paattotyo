using UnityEngine;
using System.Collections;

public class MaxLevelMoveSpeed : MonoBehaviour 
{
	// Tää skripti on vielä kesken
	// Sen tarkoitus on luoda pelaajalle jokin erikoistehoste, jos hän levutta nopeuden max levulle
	Experience experience;
	PlayerController playerController;
	public GameObject player;
	bool maxLvlMoveSpeed;
	bool dashReady;
	bool isDashing;

	float dashSpeed = 5f;

	void Awake ()
	{
		experience = GetComponent <Experience> ();
		playerController = GameObject.Find ("Player").GetComponent <PlayerController> ();
		maxLvlMoveSpeed = false;
		dashReady = false;
		
	}

	void Update ()
	{
		if (experience.movementSpeedLevel == 4) //Testimielessä laiton lvl2. Lopullisesti varmaa lvl4
		{
			maxLvlMoveSpeed = true;
		}

		if (Input.GetKeyDown ("space") && maxLvlMoveSpeed == true) 
		{
			dashReady = true;
		}
		if (dashReady == true && Input.GetKeyDown ("space")) 
		{
//			dashReady = false;
			//	player.transform.position = Vector3.Lerp (playerPos.position, transform.forward, (dashSpeed / dashLength));
			isDashing = true;
			//player.GetComponent<Rigidbody> ().velocity = (playerController.movement * dashSpeed);
//			StartCoroutine (dashCd ());
		}
		if (isDashing == true) 
		{
			player.GetComponent<Rigidbody> ().AddForce (playerController.movement * dashSpeed, ForceMode.Impulse);
			StartCoroutine (dashing ());


		}
	}
/*	IEnumerator dashCd ()
	{
		yield return new WaitForSeconds (3);
		dashReady = true;
	}*/
	IEnumerator dashing ()
	{
		yield return new WaitForSeconds (0.2f);
		isDashing = false;
	}
}
