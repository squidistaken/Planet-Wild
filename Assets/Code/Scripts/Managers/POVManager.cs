using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum crosshairType
{
	normal,
	interact
}

public class POVManager : MonoBehaviour
{
	Image crosshair;
	
	[SerializeField]
	Sprite crosshairNormal;
	[SerializeField]
	Sprite crosshairInteract;
	
	private void OnEnable()
	{
		crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
	}

	public void EditCrosshair(crosshairType type)
	{
		switch (type)
		{
			case crosshairType.normal:
				crosshair.sprite = crosshairNormal;
				break;
			case crosshairType.interact:
				crosshair.sprite = crosshairInteract;
				break;
			default:
				crosshair.sprite = crosshairNormal;
				break;
		}
	}
}

