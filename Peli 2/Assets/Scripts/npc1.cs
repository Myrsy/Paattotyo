using UnityEngine;
using System.Collections;

public class npc1 : MonoBehaviour 
{
	PlayerMovement playerMovement;
	public Animator anim, animPelaaja;
	public GameObject lantern, playersLantern, dialoguePanel;
	bool isColliding;
	public bool isSleeping;

	public string[] dialogue;
	public string[] sleeping;
	public string name;

	void Awake ()
	{
		playerMovement = GameObject.Find ("Pelaaja").GetComponent <PlayerMovement> ();
		isSleeping = false;
	}

	void Update ()
	{
		isColliding = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Pelaaja" && !isColliding && isSleeping == false)
		{
			isColliding = true;
			DialogueSystem.Instance.AddNewDialogue (dialogue, name);
			animPelaaja.enabled = false;
			playerMovement.speed = 0;
		}
		if (isSleeping == true)
		{
			DialogueSystem.Instance.AddNewDialogue (sleeping, name);

		}
	}
		
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.name == "Pelaaja" && isSleeping == false) 
		{
			anim.SetInteger ("state", 2);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Pelaaja")
		{
			anim.SetInteger ("state", 1);
			lantern.SetActive (false);
			playersLantern.SetActive (true);
			dialoguePanel.SetActive (false);
			isSleeping = true;
		}
	}
}
