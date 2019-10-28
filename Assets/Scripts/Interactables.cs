using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PreviousItem
{
	public Item requiredItem;
	public Item interactionItem;
	public UnityEvent OnInteract;
}

public class Interactables : MonoBehaviour
{
	public Item item;

	public PreviousItem[] previousItem;

	public UnityEvent OnInteract;
	public UnityEvent CollectItem;

	[HideInInspector]
	public bool isMoving;

   
}
