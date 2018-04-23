using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionButton : MonoBehaviour {

	public Image icon;
	public Button button;

	public void Initialise(Sprite image, UnityAction onClick)
	{
		icon.sprite = image;
		button.onClick.AddListener(onClick);
	}
}
