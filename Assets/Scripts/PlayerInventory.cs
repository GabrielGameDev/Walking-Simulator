using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WinCondition
{
	public List<Item> requiredItens;
	public List<Item> interactedItens;
	public CutsceneController winCutscene;
	public bool alreadyPlayed;
}

public class PlayerInventory : MonoBehaviour
{

	public WinCondition[] winCondition;

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

	public void AddRequiredItens(Item item)
	{
		for (int i = 0; i < winCondition.Length; i++)
		{
			if (winCondition[i].requiredItens.Contains(item))
			{
				if (!winCondition[i].interactedItens.Contains(item))
				{
					winCondition[i].interactedItens.Add(item);
				}
			}
		}

		for (int i = 0; i < winCondition.Length; i++)
		{
			if(winCondition[i].requiredItens.Count == winCondition[i].interactedItens.Count)
			{
				if (!winCondition[i].alreadyPlayed)
				{
					winCondition[i].alreadyPlayed = true;
					StartCoroutine(PlayCutscene(winCondition[i].winCutscene));
					break;
				}
			}
		}
	}

	IEnumerator PlayCutscene(CutsceneController cutscene)
	{
		yield return new WaitForSeconds(1.5f);
		cutscene.Play();
	}
}
