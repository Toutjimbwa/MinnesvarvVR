using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace TistouVR
{
	public class Teleport : VRTK_DestinationMarker
	{

		public void Test()
		{
			VRTK_ControllerEvents controller = FindObjectOfType<VRTK_ControllerEvents>(); //right or left controller
			ToTransform(transform, controller);
		}

		public void ToExperience(Experience e, VRTK_ControllerEvents controller)
		{
			ToTransform(e._TeleportPosition, controller);
		}

		private void ToTransform(Transform destination, VRTK_ControllerEvents controller)
		{
			float distance = Vector3.Distance(transform.position, destination.position);
			
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(controller.gameObject);
			OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, destination, new RaycastHit(), destination.position, controllerReference));
		}
	}
}