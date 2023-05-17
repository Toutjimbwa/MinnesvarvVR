using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TistouVR
{
	public class SvetsStation : Experience
	{
		[Header("Svets settings")]
		[Header("Audio")]
		public AudioSource _AudioSource;
		public AudioClip _Enter;
		public AudioClip _PickUpWelder;
		public AudioClip[] _GoodWeld;
		public AudioClip _BadWeld;

		public override void StartExperience()
		{
			base.StartExperience();
			Enter();
		}
		public void StationCompleted()
		{
			_AudioSource.Stop();
			FindObjectOfType<GameManager>().LoadExperience(_NextExperience);
		}
		public void Enter()
		{
			PlayClip(_Enter);
		}
		public void PickUpWelder()
		{
			PlayClip(_PickUpWelder);
		}
		public void GoodWeld()
		{
			PlayClip(_GoodWeld[Random.Range(0,_GoodWeld.Length)]);
		}
		public void BadWeld()
		{
			PlayClip(_BadWeld);
		}
		public void AllWelded()
		{
			StationCompleted();
		}

		private void PlayClip(AudioClip clip)
		{
			_AudioSource.clip = clip;
			_AudioSource.Play();
		}
	}
}