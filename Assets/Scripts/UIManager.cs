using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public static UIManager instance;

	public Text captionsText;

	public GameObject handCursor;
	public GameObject backImage;

	public Image interactionImage;

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetCaptions(string text)
	{
		captionsText.text = text;
	}

	public void SetHandCursor(bool state)
	{
		handCursor.SetActive(state);
	}

	public void SetBackImage(bool state)
	{
		backImage.SetActive(state);

		if (!state)
		{
			interactionImage.enabled = false;
		}
	}

	public void SetImage(Sprite sprite)
	{
		interactionImage.sprite = sprite;
		interactionImage.enabled = true;
	}
}
