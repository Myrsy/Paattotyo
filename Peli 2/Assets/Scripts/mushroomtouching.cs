using UnityEngine;
using System.Collections;

public class mushroomtouching : MonoBehaviour 
{
	Animator anim;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		anim.SetBool ("isTouching", false);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.name == "Pelaaja")
			anim.SetBool ("isTouching", true);
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.name == "Pelaaja")
			anim.SetBool ("isTouching", false);
	}

}
