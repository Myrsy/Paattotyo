using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	//Suoraan taas netistä kopioitu

	public static DialogueSystem Instance { get; set; }
	public GameObject dialoguePanel;
	public string npcName;
	public List<string> dialogueLines = new List<string> ();

	Text dialogueText, nameText;
	int dialogueIndex;

	PlayerMovement playerMovement;
	npc1 npcScript;
	npc2 npc2Script;
	public Animator animPelaaja;

	void Awake ()
	{
		if (Instance != null && Instance != this) 
		{
			Destroy (gameObject);
		} 
		else 
		{
			Instance = this; 
		}
		dialogueText = dialoguePanel.transform.FindChild ("Text").GetComponent<Text> ();
		nameText = dialoguePanel.transform.FindChild ("NPC name").GetChild(0).GetComponent<Text> ();
		playerMovement = GameObject.Find ("Pelaaja").GetComponent<PlayerMovement> ();
		npcScript = GameObject.Find ("Mr. Sleepy").GetComponent<npc1> ();
		npc2Script = GameObject.Find ("Mr. Grumpy").GetComponent<npc2> ();
		dialoguePanel.SetActive (false);
	}

	void Update ()
	{
		if (dialoguePanel.active == true && Input.GetKeyDown(KeyCode.Space)) 
		{
			ContinueDialogue ();
		}
	}

	public void AddNewDialogue (string[] lines, string npcName)
	{
		dialogueIndex = 0;
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);
		this.npcName = npcName;
		CreateDialogue ();
	}


	public void CreateDialogue()
	{
		dialogueText.text = dialogueLines [dialogueIndex];
		nameText.text = npcName;
		dialoguePanel.SetActive (true);
		if (npcScript.isSleeping != true || npc2Script.isInactive != true)
		playerMovement.enabled = false;
	}

	public void ContinueDialogue()
	{
		if (dialogueIndex < dialogueLines.Count - 1) 
		{
			dialogueIndex++;
			dialogueText.text = dialogueLines [dialogueIndex];
		} 
		else 
		{
			dialoguePanel.SetActive (false);
			playerMovement.enabled = true;
			animPelaaja.enabled = true;
		}
	}

}
