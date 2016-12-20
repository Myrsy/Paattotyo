using UnityEngine;
using System.Collections;

public class DestroyExplosionEffect : MonoBehaviour
{
	// Tämä skripti tuhoaa räjähdyksessä syntyvön particle systemin ja soittaa samalla räjähdysäänen
	public AudioClip explosionSound;
	AudioSource source;
	public float destroyTime;

	void Awake ()
	{
		source = GetComponent <AudioSource> ();
	}
	void Start ()
	{
		source.PlayOneShot (explosionSound);
		Destroy (gameObject, destroyTime);
	}

}
