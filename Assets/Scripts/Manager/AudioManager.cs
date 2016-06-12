using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	#region enum

	/// <summary>
	/// WARNING!
	/// Add here the clips in the same 
	/// order as the AudioClips added 
	/// through inspector in Clips property
	/// </summary>
	public enum Clips { 
		PhoneCall
	}

	#endregion

	#region singleton

	public static AudioManager Instance;

	#endregion

	#region fields

	[SerializeField]
	AudioClip[] clips;

	[SerializeField]
	int numberOfAudioSources = 2;

	List<AudioSource> freeSources;
	List<AudioSource> busySources;

	#endregion

	#region monobehaviour methods

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	void Start()
	{
		freeSources = new List<AudioSource>();
		busySources = new List<AudioSource>();
		for (int i = 0; i < numberOfAudioSources; i++)
		{
			freeSources.Add(gameObject.AddComponent<AudioSource>());
		}
	}

	#endregion

	#region public methods

	public AudioSource Play(Clips clip,
							float volume = 1, float pitch = 1,
							bool hasToLoop = false)
	{
		return Play(clips[(int)clip], volume, pitch, hasToLoop);
	}

	public AudioSource Play(AudioClip clip,
	                        float volume = 1, float pitch = 1, 
	                        bool hasToLoop = false)
	{
		var source = GetFreeAudioSource();
		busySources.Add(source);
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.loop = hasToLoop;
		source.Play();
		return source;
	}

	#endregion

	#region aux method

	AudioSource GetFreeAudioSource()
	{
		if (freeSources.Count > 0)
			return freeSources.PopAt(0);
		var source = busySources.PopAt(0);
		source.Stop();
		return source;
	}

	#endregion
}