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
				fb.elementOptions[slot.assetFolder][0],
				slot.depth,
				slot.flipX,
				slot.defaultOffset,
				slot.defaultScale,
				spriteMaterial);
		}
	}
}
