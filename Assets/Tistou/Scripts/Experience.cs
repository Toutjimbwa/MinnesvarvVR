using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouVR
{
	public class Experience : MonoBehaviour
	{
		public enum IDs
		{
			StartMenu,
			StoryToWeld,
			StoryToRivet,
			StoryToShipProcess,
			StoryToChampagne,
			Weld,
			Rivet,
			ShipProcess,
			Champagne
		}
		public IDs _ID;
		public Transform _TeleportPosition;
		public Experience.IDs _NextExperience;

		public virtual void StartExperience()
		{
			Debug.Log("Start experience " + name);
		}

		public void StopExperience()
		{
			Debug.Log("Stop experience " + name);
		}
	}
}