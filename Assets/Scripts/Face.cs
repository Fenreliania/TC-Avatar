using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour {
	public FaceBuilder fb;
	public Dictionary<string, FaceElement> faceElements = new Dictionary<string, FaceElement>();
	public Material spriteMaterial;

	public void BuildFace(FaceBuilder _fb, Material _spriteMaterial)
	{
		fb = _fb;
		spriteMaterial = _spriteMaterial;
		faceElements = new Dictionary<string, FaceElement>();
		foreach(FaceBuilder.FaceSlot slot in fb.elements)
		{
			faceElements[slot.name] = new FaceElement(
				transform,
				slot.name,
				fb.elementOptions[slot.name][0],
				slot.depth,
				false,
				slot.defaultOffset,
				slot.defaultScale,
				spriteMaterial);
			if (slot.mirrorX)
			{
				string mirrorName = slot.name + "-mirror";
                faceElements[mirrorName] = new FaceElement(
				transform,
				mirrorName,
				fb.elementOptions[slot.name][0],
				slot.depth,
				true,
				slot.defaultOffset,
				slot.defaultScale,
				spriteMaterial);
			}
		}
	}

	public void UpdateSprite(FaceBuilder.FaceSlot slot, Sprite sprite)
	{
		faceElements[slot.name].setSprite(sprite);
		if (slot.mirrorX)
		{
			faceElements[slot.name + "-mirror"].setSprite(sprite);
		}
	}
}
