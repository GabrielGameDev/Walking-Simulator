using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


[System.Serializable]
public class Texts
{
	public string text;
	public float startTime;
}

public class CutsceneController : MonoBehaviour
{

	public bool playOnAwake;
	public Texts[] texts;

	private PlayableDirector cutscene;

	private void Awake()
	{
		cutscene = GetComponent<PlayableDirector>();
	}

	// Start is called before the first frame update
	void Start()
    {
		if (playOnAwake)
		{
			Invoke("Play", 1f);
		}
    }

 
	public void Play()
	{
		cutscene.Play();
		Invoke("Finish", (float)cutscene.duration);
		for (int i = 0; i < texts.Length; i++)
		{
			StartCoroutine(Subtitle(texts[i]));
		}
	}

	IEnumerator Subtitle(Texts text)
	{
		yield return new WaitForSeconds(text.startTime);
		UIManager.instance.SetCaptions(text.text);
	}

	void Finish()
	{
		UIManager.instance.SetCaptions("");
	}

}
