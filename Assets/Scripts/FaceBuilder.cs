using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBuilder : MonoBehaviour {
	[Serializable]
	public struct FaceSlot
	{
		public string name;
		public string assetFolder;
		public int depth;
		public bool flipX;
		public Vector2 defaultOffset, minOffset, maxOffset;
		public float defaultScale, minScale, maxScale;
	}

	public FaceSlot[] elements;
	public Dictionary<string, Sprite[]> elementOptions;

	void Start()
	{
		elementOptions = new Dictionary<string, Sprite[]>();
		foreach(FaceSlot e in elements)
		{
			if (!elementOptions.ContainsKey(e.assetFolder))
			{
				elementOptions[e.assetFolder] = Resources.LoadAll<Sprite>(e.assetFolder);
			}
		}
	}

	public Sprite getRandomElementSprite(string elementName)
	{
		return elementOptions[elementName][UnityEngine.Random.Range(0, elementOptions[elementName].Length - 1)];
	}
}
