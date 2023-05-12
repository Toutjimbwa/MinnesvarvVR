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
		public Experience.IDs _NextExperience;
		public GameObject[] _VRSetups;

		
		public virtual void StartExperience()
		{
			foreach (var GO in _VRSetups)
			{
				GO.SetActive(true);
			}
		}

		public void StopExperience()
		{
			foreach (var GO in _VRSetups)
			{
				GO.SetActive(false);
			}
		}
	}
}