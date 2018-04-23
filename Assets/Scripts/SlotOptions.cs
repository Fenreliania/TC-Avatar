using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotOptions : MonoBehaviour {

	public FaceBuilder fb;
	public GameObject optionButtonPrefab;
	public GameObject optionPanel;

	public void DisplayOptions(FaceBuilder.FaceSlot slot)
	{
		foreach(Sprite sprite in fb.elementOptions[slot.assetFolder])
		{
			GameObject button = Instantiate(optionButtonPrefab);
			button.GetComponent<OptionButton>().Initialise(sprite, () => fb.currentFace.faceElements[slot.name].setSprite(sprite));
		}
	}
}
