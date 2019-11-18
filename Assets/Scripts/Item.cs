﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
	public bool requiredItem;

	public bool grabbable;

	public AudioClip audioClip;
	public string text;
	public Sprite image;

	[Header("Inventory")]
	public bool inventoryItem;
	public string collectMessage;
}
