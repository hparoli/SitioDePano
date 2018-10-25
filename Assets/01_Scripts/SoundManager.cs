using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager instance;  



	public ClipList            clipList;
    public AudioSource[]       playerSource;


	void Awake () 
	{
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);
		}

}
	void Update () 
	{
		
	}
	public void Play (string channel, AudioClip clip)
	{
		AudioSource tempSourcer = null;
		int index = 0;
		if (channel == "Player") 
		{
			for (index = 0; index < playerSource.Length; index++)
			{
				if (!playerSource[index].isPlaying)
				{
					break;
				}
			}
			if (index == playerSource.Length)
			{
				index = 0;
			}
			tempSourcer = playerSource[index]; 
		}

		tempSourcer.Stop ();

		float pitch = 1 + (Random.Range(0, 11) * 0.01f) * 0.95f;


		tempSourcer.pitch = pitch;
		tempSourcer.clip = clip; 
		tempSourcer.Play ();
	}

	public void Stop (string channel, AudioClip clip)
	{	
		AudioSource tempSourcer = null;
		int index = 0;
		if (channel == "Player")
		{
			for (index = 0; index < playerSource.Length; index++)
			{
				if (playerSource[index].isPlaying)
				{
					break;
				}
			}
			if (index == playerSource.Length)
			{
				index = 0;
			}
			tempSourcer = playerSource[index]; 
			tempSourcer.clip = playerSource[index].clip;
		}

		if (clip == tempSourcer.clip)
		{
			tempSourcer.Stop ();
		}
		
	}
}

[System.Serializable]
public class ClipList
{
	
	public AudioClip   DollClick;
    public AudioClip   MissClick;
	public AudioClip   speekBolos;
	public AudioClip   speekHorta;

}
