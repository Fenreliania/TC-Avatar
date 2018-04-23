using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotOptions : MonoBehaviour {

	public FaceBuilder faceBuilder;
	public GameObject buttonPrefab;
	public GameObject optionPanel;
	public Text title;

	public void DisplayOptions(FaceBuilder.FaceSlot slot)
	{
		title.text = slot.name;

		var children = new List<GameObject>();
		foreach (Transform child in optionPanel.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		foreach (Sprite sprite in faceBuilder.elementOptions[slot.name])
		{
			GameObject button = Instantiate(buttonPrefab);
			button.GetComponent<OptionButton>().Initialise(sprite, () => faceBuilder.currentFace.UpdateSprite(slot, sprite));
			button.transform.SetParent(optionPanel.transform, false);
		}
	}
}
