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
			ShowGameObjects();
			foreach (var e in FindObjectsOfType<Experience>())
			{
				if (e._ID == _NextExperience)
				{
					e.ShowGameObjects();
					break;
				}
			}
		}

		public void StopExperience()
		{
			GetComponent<AudioSource>().Stop();
			HideGameObjects();
		}

		public void ShowGameObjects()
		{
			gameObject.SetActive(true);
		}

		public void HideGameObjects()
		{
			gameObject.SetActive(false);
		}
	}
}