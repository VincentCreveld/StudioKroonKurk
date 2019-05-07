using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource backgroundTrack;
	public AudioSource dialogTrack;

	public bool isDialogPlaying { get; private set; } = false;

	public AudioClip bgTrack;
	public List<AudioClip> dialogEntries;

	public static AudioManager instance;

	public List<int> existingAudioClips = new List<int>();
	public Dictionary<int, AudioClip> audioDictionary = new Dictionary<int, AudioClip>();

	private void Awake()
	{
		backgroundTrack = gameObject.AddComponent<AudioSource>();
		dialogTrack = gameObject.AddComponent<AudioSource>();
        backgroundTrack.playOnAwake = false;
        backgroundTrack.Stop();
        dialogTrack.playOnAwake = false;
        dialogTrack.Stop();

        if (instance == null)
			instance = this;
		else
			Debug.LogError("More than one audiomanager in scene.");

		foreach(AudioClip ac in dialogEntries)
		{
			string n = ac.name;
			int key = -9999999;
			key = int.Parse(n);

			if(key == -9999999)
			{
				Debug.LogError("Audio file incorrectly named. Skipping " + n);
				continue;
			}

			if(audioDictionary.ContainsKey(key))
			{
				Debug.LogError("Audio file incorrectly named. Skipping " + n);
				continue;
			}

			existingAudioClips.Add(key);
			audioDictionary.Add(key, ac);
		}
	}

	public void PlayDialogClip(int id)
	{
		if(!audioDictionary.ContainsKey(id))
			return;
		isDialogPlaying = true;

		dialogTrack.Stop();
		dialogTrack.clip = audioDictionary[id];
		Invoke("ResetDialogPlaying", GetDelayById(id));
		dialogTrack.Play();
	}

	private void ResetDialogPlaying()
	{
		isDialogPlaying = false;
	}

	public void StopAudioClip()
	{
		dialogTrack.Stop();
		CancelInvoke("ResetDialogPlaying");
		isDialogPlaying = false;
	}

	public float GetDelayById(int id)
	{
		if(!audioDictionary.ContainsKey(id))
			return 0;
		return audioDictionary[id].length;
	}
}
