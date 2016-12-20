using UnityEngine;
using System.Collections;

public class MaxLevelExplosion : MonoBehaviour 
{
	// Tää skripti on vielä kesken
	// Sen tarkoitus on luoda pelaajalle jokin erikoistehoste, jos hän levutta räjähteen max levulle
	Experience experience;

	void Awake ()
	{
		experience = GetComponent <Experience> ();
	}

	void Update ()
	{
		if (experience.explosionLevel == 4)
		{
			explosionMax ();
		}
	}

	void explosionMax ()
	{
		// Katso PowerUpsSpawn
	}
}
