using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{
	public Item item;

	public UnityEvent OnInteract;

	[HideInInspector]
	public bool isMoving;

   
}
