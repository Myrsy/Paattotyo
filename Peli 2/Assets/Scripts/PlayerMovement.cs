using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public int playerSpeed;
	public int jumpSpeed;
	public int speed;
	bool readyToJump;
	Rigidbody2D rb;
	Animator anim;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		rb = GetComponent <Rigidbody2D> ();
		readyToJump = false;
	}

	void Update () 
	{
		Movement (playerSpeed);

		anim.SetInteger ("speed", speed);

		if (Input.GetKey (KeyCode.A)) 
		{
			speed = -playerSpeed;
		}
		
		if (Input.GetKeyUp (KeyCode.A))
		{
			speed = 0;
		}
		if (Input.GetKey (KeyCode.D))
		{
			speed = playerSpeed;
		}
		
		if (Input.GetKeyUp (KeyCode.D))
		{
			speed = 0;
		}
		if (Input.GetKeyDown (KeyCode.W) && readyToJump == true)
		{
			rb.velocity = new Vector3 (rb.velocity.x, jumpSpeed, 0);
		}

		if (readyToJump == false) {
			anim.SetBool ("isJumping", true);
		} else
			anim.SetBool ("isJumping", false);
	}

	void Movement (float playerSpeed)
	{
		rb.velocity = new Vector3 (speed, rb.velocity.y, 0);
	}

	void OnCollisionStay2D (Collision2D coll)
	{
		readyToJump = true;
	}
	void OnCollisionExit2D (Collision2D coll)
	{
		readyToJump = false;
	}
}
