using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceElement {
	public GameObject element;

	SpriteRenderer sr;
	bool flipX;

	public FaceElement(Transform parent, string elementName, Sprite sprite, int depth, bool _flipX, Vector2 position, float scale, Material material)
	{
		element = new GameObject(elementName);
		element.transform.SetParent(parent);
		sr = element.AddComponent<SpriteRenderer>();
		sr.material = material;
		sr.sortingOrder = depth;
		flipX = _flipX;
		sr.flipX = flipX;
		setSprite(sprite);
		setOffset(position);
	}

	public void setSprite(Sprite sprite)
	{
		sr.sprite = sprite;
	}

	public void setTint(Color colour)
	{
		sr.material.SetColor("_Tint", colour);
	}

	public void setOffset(Vector2 offset)
	{
		element.transform.position = flipX? new Vector2(-offset.x, offset.y) : offset;
	}

	public void setHorizontalOffset(float x)
	{
		element.transform.position = new Vector2((flipX? -x : x), element.transform.position.y);
	}

	public void setVerticalOffset(float y)
	{
		element.transform.position = new Vector2(element.transform.position.x, y);
	}

	public void setScale(float scale)
	{
		element.transform.localScale = Vector2.one * scale;
	}

	public void removeSprite()
	{
		sr.sprite = null;
	}
}
