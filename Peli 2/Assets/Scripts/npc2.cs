using UnityEngine;
using System.Collections;

public class npc2 : MonoBehaviour
{
	PlayerMovement playerMovement;
	public Animator anim, animPelaaja;
	public GameObject dialoguePanel;
	bool isColliding;
	public bool isInactive;

	public string[] dialogue2;
	public string[] afterDialogue;
	public string name;

	void Awake ()
	{
		playerMovement = GameObject.Find ("Pelaaja").GetComponent <PlayerMovement> ();
		isInactive = false;
	}

	void Update ()
	{
		isColliding = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Pelaaja" && !isColliding && isInactive == false)
		{
			isColliding = true;
			DialogueSystem.Instance.AddNewDialogue (dialogue2, name);
			animPelaaja.enabled = false;
			playerMovement.speed = 0;
		}
		if (isInactive == true)
		{
			DialogueSystem.Instance.AddNewDialogue (afterDialogue, name);
			anim.SetInteger ("state", 1);
			playerMovement.speed = 0;
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.name == "Pelaaja" && isInactive == false) 
		{
			anim.SetInteger ("state", 1);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Pelaaja")
		{
			anim.SetInteger ("state", 0);
			dialoguePanel.SetActive (false);
			isInactive = true;
		}
	}
}
