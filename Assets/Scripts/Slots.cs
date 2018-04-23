using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour {

	public FaceBuilder faceBuilder;
	public GameObject buttonPrefab;
	public GameObject slotPanel;
	public SlotOptions slotOptions;

	public void DisplaySlots()
	{
		foreach (FaceBuilder.FaceSlot slot in faceBuilder.elements)
		{
			GameObject button = Instantiate(buttonPrefab);
			button.GetComponent<OptionButton>().Initialise(faceBuilder.elementOptions[slot.name][0], () => ShowOptions(slot));
			button.transform.SetParent(slotPanel.transform, false);
		}
	}

	public void ShowOptions(FaceBuilder.FaceSlot slot)
	{
		slotOptions.DisplayOptions(slot);
		gameObject.SetActive(false);
    }
}
