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

		public override void StartExperience()
		{
			foreach (var GO in _VRSetups)
			{
				GO.SetActive(true);
			}

			_Animator.SetTrigger(START_TOUR_TRIGGER);
			StartCoroutine(EndTour());
		}

		private IEnumerator EndTour()
		{
			yield return new WaitForSeconds(_tourClip.length);
			FindObjectOfType<GameManager>().LoadExperience(_NextExperience);
		}
	}
}