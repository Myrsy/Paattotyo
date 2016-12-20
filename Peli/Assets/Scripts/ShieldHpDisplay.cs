using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShieldHpDisplay : MonoBehaviour 
{
	ShieldProperties shieldProperties;
	Experience experience;
	Text text;
	MaxLevelHp maxLevelHp;
	public GameObject gameController;
	float shieldCountDown;
	float shieldCdCountDown;

	void Awake ()
	{
		experience = gameController.GetComponent<Experience> ();
		text = GetComponent<Text> ();
		maxLevelHp = gameController.GetComponent<MaxLevelHp> ();
		shieldCountDown = maxLevelHp.shieldTime;
		shieldCdCountDown = maxLevelHp.shieldCd;
	}

	void Update ()
	{
		if (maxLevelHp.shieldReady == true && experience.healthLevel == 4) 
		{
			text.text = ("Shield Ready").ToString ();
		}
		if (maxLevelHp.shieldActive == true && experience.healthLevel == 4) 
		{
			text.text = ("Shield Time " + Mathf.Round (shieldCountDown -= Time.deltaTime)).ToString ();
		}
		if (maxLevelHp.shieldActive == false && experience.healthLevel == 4 && maxLevelHp.shieldReady == false) 
		{
			text.text = ("Shield Cooldown " + Mathf.Round (shieldCdCountDown -= Time.deltaTime)).ToString ();
		} 
		else
			return;
		if (shieldCountDown <= 0f) 
		{
			shieldCountDown = maxLevelHp.shieldTime;
		}
		if (shieldCdCountDown <= 0f) 
		{
			shieldCdCountDown = maxLevelHp.shieldCd;
		}
	}
}
