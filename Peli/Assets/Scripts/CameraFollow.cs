using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject player;
	Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void Update ()
	{
//		Debug.Log (player.transform.position);
	}
	void LateUpdate ()
	{
	
		transform.position = player.transform.position + offset;
		transform.position = new Vector3 
			(
				Mathf.Clamp (transform.position.x, - 18, 18),
				Mathf.Clamp (transform.position.y, - 20, 20),
				Mathf.Clamp (transform.position.z, - 10, 10)
			//	transform.position.y = 15
			);
//		Debug.Log (transform.position);

//		gameObject.transform.position = new Vector3 (gameObject.GetComponent<Camera> ().ScreenToWorldPoint (player.transform.position));

		//transform.position = new Vector3 
		//	(
		/*Mathf.Clamp (transform.position.x, -10, 10);
		Mathf.Clamp (transform.position.z, -10, 10);*/
			//Mathf.Clamp (transform.position.y, -20, 20)
		//	);
	}
}