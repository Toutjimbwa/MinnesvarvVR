using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

namespace TistouVR
{
	public class VRButton_DebugStationSteps : VRTK_InteractableObject
	{
		public Animator animator;
		public UnityEvent myEvent;

		public override void StartUsing(VRTK_InteractUse usingObject)
		{
			PressButton();
		}

		private void PressButton()
		{
			animator.SetTrigger("press");
			myEvent.Invoke();
		}
	}
}