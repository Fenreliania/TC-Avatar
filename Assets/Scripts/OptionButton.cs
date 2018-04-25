using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionButton : MonoBehaviour {

	public Image icon;
	public Button button;

	public void Initialise(Sprite image, UnityAction onClick, float scale, Color tint)
	{
		icon.sprite = image;
		icon.transform.localScale = Vector2.one * scale;
		icon.color = tint;
		button.onClick.AddListener(onClick);
	}
}
