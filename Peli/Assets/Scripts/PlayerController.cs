using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// Tä on sit muuten kokonaa ihan valmis koodi jonka revin jostai (en ite varmaan osais)
	// Liikkuminen
	public float playerSpeed;
	//Esto hahmon pääsystä alueen ulkopuolelle
	public float xMin, xMax, zMin, zMax;
	// Hahmon kääntyminen hiiren suntaan
	public float rotationSpeed;
	public Vector3 movement;

	void FixedUpdate () 
	{
		// Liikkuminen
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		/*Vector3 movement*/movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * playerSpeed;

		// Esto hahmon pääsystä alueen ulkopuolelle
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, xMin, xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, zMin, zMax)
			);

		// Hahmon kääntyminen hiiren suntaan
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		float hitdist = 0.0f;

		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);

			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		}
	}
}