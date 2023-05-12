using System.Collections;
using System.Collections.Generic;
using TistouVR;
using UnityEngine;
using Valve.VR;

namespace TistouVR
{
	public class Tour : Experience
	{
		static string START_TOUR_TRIGGER = "start";

		public Animator _Animator;
		public AnimationClip _tourClip;
		public AudioSource _StoryAudio;

		public override void StartExperience()
		{
			_Animator.SetTrigger(START_TOUR_TRIGGER);
			_StoryAudio.Play();
			StartCoroutine(EndTour());
		}

		private IEnumerator EndTour()
		{
			yield return new WaitForSeconds(_tourClip.length);
			FindObjectOfType<GameManager>().LoadExperience(_NextExperience);
		}
	}
}