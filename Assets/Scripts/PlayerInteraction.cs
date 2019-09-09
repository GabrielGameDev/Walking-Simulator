using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	public float rayDistance = 2f;

	private Camera myCam;

    // Start is called before the first frame update
    void Start()
    {
		myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		CheckInteractables();
    }

	void CheckInteractables()
	{
		RaycastHit hit;
		Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

		if(Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, rayDistance))
		{
			Interactables interactable = hit.collider.GetComponent<Interactables>();
			if(interactable != null)
			{
				UIManager.instance.SetHandCursor(true);
			}
			else
			{
				UIManager.instance.SetHandCursor(false);
			}
		}
		else
		{
			UIManager.instance.SetHandCursor(false);
		}

	}
}
