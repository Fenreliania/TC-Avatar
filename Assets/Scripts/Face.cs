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
				1f,
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
				1f,
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

	public void UpdateOffset(FaceBuilder.FaceSlot slot, Vector2 newOffset)
	{
		faceElements[slot.name].setOffset(newOffset);
		if (slot.mirrorX)
		{
			faceElements[slot.name + "-mirror"].setOffset(newOffset);
		}
	}

	public void UpdateHorizontalOffset(FaceBuilder.FaceSlot slot, float newX)
	{
		faceElements[slot.name].setHorizontalOffset(newX);
		if (slot.mirrorX)
		{
			faceElements[slot.name + "-mirror"].setHorizontalOffset(newX);
		}
	}

	public void UpdateVerticalOffset(FaceBuilder.FaceSlot slot, float newY)
	{
		faceElements[slot.name].setVerticalOffset(newY);
		if (slot.mirrorX)
		{
			faceElements[slot.name + "-mirror"].setVerticalOffset(newY);
		}
	}

	public void UpdateScale(FaceBuilder.FaceSlot slot, float scale)
	{
		faceElements[slot.name].setScale(scale);
		if (slot.mirrorX)
		{
			faceElements[slot.name + "-mirror"].setScale(scale);
		}
	}

	public void UpdateTint(FaceBuilder.FaceSlot slot, Color tint)
	{
		faceElements[slot.name].setTint(tint);
		if (slot.mirrorX)
		{
			faceElements[slot.name + "-mirror"].setTint(tint);
		}
	}
}
