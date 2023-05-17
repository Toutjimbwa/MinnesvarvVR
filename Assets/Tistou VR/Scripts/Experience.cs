using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
		[Header("Experience settings")]
		public IDs _ID;
		public Transform _TeleportPosition;
		public Experience.IDs _NextExperience;
		public bool _HideGameObjectOnStopExperience = false;
		
		[FormerlySerializedAs("DEBUG")] [Header("Debug")]
		public bool _ForceStartExperienceOnStart = true;

		private void Start()
		{
			if(_ForceStartExperienceOnStart) StartExperience();
		}
		
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
			if(_HideGameObjectOnStopExperience) HideGameObjects();
		}

		public void ShowGameObjects()
		{
			gameObject.SetActive(true);
		}

		public void HideGameObjects()
		{
			Debug.Log(name + " hide game objects");
			gameObject.SetActive(false);
		}
	}
}