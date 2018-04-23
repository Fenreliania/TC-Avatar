using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotOptions : MonoBehaviour {

	public FaceBuilder fb;
	public GameObject optionButtonPrefab;
	public GameObject optionPanel;

	public void DisplayOptions(FaceBuilder.FaceSlot slot)
	{
		foreach(Sprite sprite in fb.elementOptions[slot.name])
		{
			GameObject button = Instantiate(optionButtonPrefab);
			button.GetComponent<OptionButton>().Initialise(sprite, () => fb.currentFace.UpdateSprite(slot, sprite));
			button.transform.SetParent(optionPanel.transform);
		}
	}
}
