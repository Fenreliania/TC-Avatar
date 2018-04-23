using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBuilder : MonoBehaviour {
	[Serializable]
	public struct FaceSlot
	{
		public string name;
		public int depth;
		public bool mirrorX;
		public Vector2 defaultOffset, minOffset, maxOffset;
		public float defaultScale, minScale, maxScale;
	}

	public Material spriteMaterial;
	public FaceSlot[] elements;
	public Dictionary<string, Sprite[]> elementOptions;
	public Face currentFace;
	public Slots slots;

	void Start()
	{
		elementOptions = new Dictionary<string, Sprite[]>();
		foreach(FaceSlot e in elements)
		{
			if (!elementOptions.ContainsKey(e.name))
			{
				elementOptions[e.name] = Resources.LoadAll<Sprite>(e.name);
			}
		}

		createFace();

		slots.DisplaySlots();
	}

	public Sprite getRandomElementSprite(string elementName)
	{
		return elementOptions[elementName][UnityEngine.Random.Range(0, elementOptions[elementName].Length - 1)];
	}

	public GameObject createFace()
	{
		GameObject faceObject = new GameObject("Face");
		faceObject.transform.SetParent(transform);
		faceObject.transform.localPosition = Vector2.zero;
		currentFace = faceObject.AddComponent<Face>();
		currentFace.BuildFace(this, spriteMaterial);

		return faceObject;
	}
}
