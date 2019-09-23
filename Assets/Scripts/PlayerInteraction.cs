using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
	public float rayDistance = 2f;
	public float rotateSpeed = 200;

	public Transform objectViewer;

	public UnityEvent OnView;
	public UnityEvent OnFinishView;

	private Camera myCam;

	private bool isViewing;
	private bool canFinish;

	private Interactables currentInteractable;
	private Vector3 originPosition;
	private Quaternion originRotation;

	private AudioPlayer audioPlayer;

	private void Awake()
	{
		audioPlayer = GetComponent<AudioPlayer>();
	}

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

		if (isViewing)
		{
			if(currentInteractable.item.grabbable && Input.GetMouseButton(0))
			{
				RotateObject();
			}

			if(canFinish && Input.GetMouseButtonDown(1))
			{
				FinishView();
			}

			return;
		}

		RaycastHit hit;
		Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

		if(Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, rayDistance))
		{
			Interactables interactable = hit.collider.GetComponent<Interactables>();
			if(interactable != null)
			{
				UIManager.instance.SetHandCursor(true);
				if (Input.GetMouseButtonDown(0))
				{
					if (interactable.isMoving)
					{
						return;
					}

					OnView.Invoke();

					currentInteractable = interactable;

					isViewing = true;

					Interact(currentInteractable.item);

					if (currentInteractable.item.grabbable)
					{
						originPosition = currentInteractable.transform.position;
						originRotation = currentInteractable.transform.rotation;
						StartCoroutine(MovingObject(currentInteractable, objectViewer.position));
					}
				}
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

	void Interact(Item item)
	{
		audioPlayer.PlayAudio(item.audioClip);
		UIManager.instance.SetCaptions(item.text);
		Invoke("CanFinish", item.audioClip.length + 0.5f);
	}

	void CanFinish()
	{
		canFinish = true;
		UIManager.instance.SetBackImage(true);
		UIManager.instance.SetCaptions("");
	}

	void FinishView()
	{
		canFinish = false;
		isViewing = false;
		UIManager.instance.SetBackImage(false);
		if (currentInteractable.item.grabbable)
		{
			currentInteractable.transform.rotation = originRotation;
			StartCoroutine(MovingObject(currentInteractable, originPosition));
		}

		OnFinishView.Invoke();
	}

	IEnumerator MovingObject(Interactables obj, Vector3 position)
	{
		obj.isMoving = true;
		float timer = 0;
		while (timer < 1)
		{
			obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * 5);
			timer += Time.deltaTime;
			yield return null;
		}

		obj.transform.position = position;
		obj.isMoving = false;
	}

	void RotateObject()
	{
		float x = Input.GetAxis("Mouse X");
		float y = Input.GetAxis("Mouse Y");
		currentInteractable.transform.Rotate(myCam.transform.right, -Mathf.Deg2Rad * y * rotateSpeed, Space.World);
		currentInteractable.transform.Rotate(myCam.transform.up, -Mathf.Deg2Rad * x * rotateSpeed, Space.World);
	}
}
