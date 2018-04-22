using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBuilder : MonoBehaviour {
	public string[] elements;
	public Dictionary<string, Sprite[]> elementOptions;

	void Start()
	{
		foreach(string e in elements)
		{
			elementOptions.Add(e, Array.ConvertAll(Resources.LoadAll(e + "/", typeof(Sprite)), x => (Sprite)x));
		}
	}

	public Sprite getRandomElementSprite(string elementName)
	{
		return elementOptions[elementName][UnityEngine.Random.Range(0, elementOptions[elementName].Length - 1)];
	}
}
