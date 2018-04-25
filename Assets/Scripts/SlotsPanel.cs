using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsPanel : MonoBehaviour {
	[System.Serializable]
	public struct SlotOptions
	{
		public string name;
		public bool adjustHorizontalPosition, adjustVerticalPosition;
		public float[] scales;
		public Color[] tints;
	}

	public FaceBuilder faceBuilder;
	public GameObject buttonPrefab;
	public GameObject slotPanel;
	public SlotOptionsPanel slotOptionsPanel;
	public Button randomiseButton;

	public SlotOptions[] slotOptions;
	Dictionary<string, SlotOptions> _slotOptionsCache;

	public void Start()
	{
		_slotOptionsCache = new Dictionary<string, SlotOptions>();
		foreach(SlotOptions options in slotOptions)
		{
			_slotOptionsCache[options.name] = options;
		}
		randomiseButton.onClick.AddListener(() => faceBuilder.currentFace.RandomiseFace());
	}

	public void DisplaySlots()
	{
		foreach (FaceBuilder.FaceSlot slot in faceBuilder.elements)
		{
			GameObject button = Instantiate(buttonPrefab);
			button.GetComponent<OptionButton>().Initialise(faceBuilder.elementOptions[slot.name][0], () => ShowOptions(slot), 1f, Color.white);
			button.transform.SetParent(slotPanel.transform, false);
		}
	}

	public void ShowOptions(FaceBuilder.FaceSlot slot)
	{
		SlotOptions options = _slotOptionsCache.ContainsKey(slot.name) ? _slotOptionsCache[slot.name] : new SlotOptions();
        slotOptionsPanel.DisplayOptions(slot, options);
		gameObject.SetActive(false);
    }
}
