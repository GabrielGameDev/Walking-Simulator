using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

	public List<Item> itens;

    public void AddItem(Item item)
	{
		if (itens.Contains(item))
		{
			return;
		}

		UIManager.instance.SetItens(item, itens.Count);
		itens.Add(item);
	}
}
