using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotOptionsPanel : MonoBehaviour {

	public FaceBuilder faceBuilder;
	public GameObject labelPrefab;
	public GameObject buttonPrefab;
	public GameObject sliderPrefab;
	public GameObject gridPrefab;
	public GameObject optionPanel;
	public Text title;

	public void DisplayOptions(FaceBuilder.FaceSlot slot, SlotsPanel.SlotOptions options)
	{
		title.text = slot.name;

		var children = new List<GameObject>();
		foreach (Transform child in optionPanel.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		AddLabel("Style");
		GameObject optionsGrid = AddGrid(new GameObject[0]);
		foreach (Sprite sprite in faceBuilder.elementOptions[slot.name])
		{
			// Set up controls for options
			AddButton(optionsGrid, sprite, () =>
			{
				faceBuilder.currentFace.UpdateSprite(slot, sprite);
				DisplayOptions(slot, options);
			}, 1f, Color.white);
		}

		RenderOptions(slot, options);

		LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)optionPanel.transform);
	}

	public void RenderOptions(FaceBuilder.FaceSlot slot, SlotsPanel.SlotOptions options)
	{
		if (options.adjustHorizontalPosition)
		{
			AddLabel("Horizontal Position");
			AddSlider(slot.defaultOffset.x, slot.minOffset.x, slot.maxOffset.x, x => faceBuilder.currentFace.UpdateHorizontalOffset(slot, x));
		}

		if (options.adjustVerticalPosition)
		{
			AddLabel("Vertical Position");
			AddSlider(slot.defaultOffset.y, slot.minOffset.y, slot.maxOffset.y, y => faceBuilder.currentFace.UpdateVerticalOffset(slot, y));
		}

		if (options.scales != null && options.scales.Length > 0)
		{
			AddLabel("Size");
			GameObject scaleGrid = AddGrid(new GameObject[0]);
			foreach (float scale in options.scales)
			{
				AddButton(
					scaleGrid,
					faceBuilder.currentFace.faceElements[slot.name].getCurrentSprite(),
					() => faceBuilder.currentFace.UpdateScale(slot, scale),
					scale,
					Color.white);
            }
		}

		if(options.tints != null && options.tints.Length > 0)
		{
			AddLabel("Tint");
			GameObject tintGrid = AddGrid(new GameObject[0]);
			foreach (Color tint in options.tints)
			{
				AddButton(
					tintGrid,
					faceBuilder.currentFace.faceElements[slot.name].getCurrentSprite(),
					() =>
					{
						faceBuilder.currentFace.UpdateTint(slot, tint);
						DisplayOptions(slot, options);
					},
					1f,
					tint);
			}
		}
	}

	public GameObject InstantiateOnOptionPanel(GameObject prefab)
	{
		GameObject obj = Instantiate(prefab);
		obj.transform.SetParent(optionPanel.transform, false);
		return obj;
	}
	
	public GameObject AddLabel(string text)
	{
		GameObject label = InstantiateOnOptionPanel(labelPrefab);
		label.GetComponent<Text>().text = text;
		return label;
    }

	public GameObject AddGrid(GameObject[] contents)
	{
		GameObject grid = InstantiateOnOptionPanel(gridPrefab);
		foreach(GameObject c in contents)
		{
			c.transform.SetParent(grid.transform, false);
		}
		return grid;
	}

	public GameObject AddButton(GameObject grid, Sprite image, UnityAction onClick, float scale, Color tint)
	{
		GameObject button = Instantiate(buttonPrefab);
		button.GetComponent<OptionButton>().Initialise(image, onClick, scale, tint);
		button.transform.SetParent(grid.transform, false);
		return button;
	}

	public GameObject AddSlider(float initial, float min, float max, UnityAction<float> onChange)
	{
		GameObject slider = InstantiateOnOptionPanel(sliderPrefab);
		Slider s = slider.GetComponentInChildren<Slider>();
		s.minValue = min;
		s.maxValue = max;
		s.value = initial;
		s.onValueChanged.AddListener(onChange);
		return slider;
	}
}
