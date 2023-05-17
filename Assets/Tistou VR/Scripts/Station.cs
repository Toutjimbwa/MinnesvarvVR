using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TistouVR
{
	public class Station : Experience
	{
		[Header("Audio clips")]
		public AudioClip _AudioIntro;

		public AudioSource _AudioSource;
		
		public override void StartExperience()
		{
			Debug.Log("Experience started: " + name);
			base.StartExperience();
			_AudioSource.clip = _AudioIntro;
			_AudioSource.Play();
		}

		public void StationCompleted()
		{
			FindObjectOfType<GameManager>().LoadExperience(_NextExperience);
		}
	}
}