using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour 
{
	PlayerMovement playerMovement;
	public Animator animPelaaja;
	public GameObject textBox;
	public Text text;
	public TextAsset textFile;
	public string[] textLines;
	public int currentLine;
	public int endAtLine;
	bool dialogEnd;

	void Awake ()
	{
		playerMovement = GameObject.Find ("Pelaaja").GetComponent<PlayerMovement> ();
		dialogEnd = false;
	}

	void Start ()
	{
		if (textFile != null) 
		{
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length;
		}
	}

	void Update ()
	{
		text.text = textLines [currentLine];
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			currentLine += 1;
		}
		if (!dialogEnd && currentLine == endAtLine) 
		{
			dialogEnd = true;
		}
//		dialogEnd = false;

		if (dialogEnd == true) 
//		if (!dialogEnd)
		{
//			EndOfDialog ();
			Debug.Log ("dialogin lkppou");
			textBox.SetActive (false);
			playerMovement.enabled = true;
			animPelaaja.enabled = true;
//			animPelaaja.SetInteger ("State", 0);
		}
		Debug.Log (currentLine);
		Debug.Log (endAtLine);
	}
/*	void EndOfDialog ()
	{
		Debug.Log ("dialogin lkppou");
		textBox.SetActive (false);
		playerMovement.enabled = true;
		animPelaaja.enabled = true;
		animPelaaja.SetInteger ("State", 0);
//		playerMovement.speed = 0;
	}*/
}
