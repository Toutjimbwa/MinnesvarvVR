using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using VRTK.UnityEventHelper;

namespace TistouVR
{
	public class GameManager : MonoBehaviour
	{

		private static int STARTMENU_SCENE_INDEX = 0;
		
		[Header("Start Helvarv")] //Helvarv
		public AudioClip _HelvarvStartAudioClip;
		private static int[] LEVEL_SCENES = new []{1,2,3};

		[Header("Audio")]
		public AudioSource _StoryAudioSource;
		public AudioSource _SFXAudioSource;
		
		private bool loadingScenes = false;
		private static GameManager instance;
		private List<int> _nextScenesToLoad = new List<int>();
		private Experience.IDs _nextExperience;

		private void Awake()
		{
			if (instance != null && instance != this)
			{
				Destroy(this.gameObject);
			}
			else
			{
				instance = this;
				DontDestroyOnLoad(this.gameObject);
			}
		}

		public void LoadExperience(Experience.IDs experienceID)
		{
			if (loadingScenes) return;
			loadingScenes = true;
			
			Debug.Log("load exp.");
			
			switch (experienceID)
			{
				case Experience.IDs.StartMenu:
					break;
				case Experience.IDs.StoryToWeld:
					StartStoryToWeld();
					break;
				case Experience.IDs.StoryToRivet:
					break;
				case Experience.IDs.StoryToShipProcess:
					break;
				case Experience.IDs.StoryToChampagne:
					break;
				case Experience.IDs.Weld:
					StartWeld();
					break;
				case Experience.IDs.Rivet:
					break;
				case Experience.IDs.ShipProcess:
					break;
				case Experience.IDs.Champagne:
					break;
			}
		}

		private void StartWeld()
		{
			LoadExperience(4, LEVEL_SCENES, Experience.IDs.Weld);
		}

		private void StartStoryToWeld()
		{
			LoadExperience(_HelvarvStartAudioClip.length, LEVEL_SCENES, Experience.IDs.StoryToWeld, _HelvarvStartAudioClip);
		}

		private void StartExperience(Experience.IDs experienceID)
		{
			foreach (var e in FindObjectsOfType<Experience>())
			{
				e.StopExperience();
			}
			
			foreach (var e in FindObjectsOfType<Experience>())
			{
				if (e._ID == experienceID)
				{
					e.StartExperience();
				}
			}
		}

		private void LoadExperience(float fadeOutDelay, int[] sceneIndices, Experience.IDs experience, AudioClip exitAudioClip)
		{
			_StoryAudioSource.clip = exitAudioClip;
			_StoryAudioSource.Play();
			
			LoadExperience(fadeOutDelay, sceneIndices, experience);
		}
		
		private void LoadExperience(float fadeOutDelay, int[] sceneIndices, Experience.IDs experience)
		{
			FadeOut(_HelvarvStartAudioClip.length);
			StartCoroutine(LoadScenesWithDelay(fadeOutDelay, sceneIndices, experience));
		}
		
		private IEnumerator LoadScenesWithDelay(float delay, int[] sceneIndices, Experience.IDs experience)
		{
			_nextScenesToLoad.Clear();
			_nextScenesToLoad.AddRange(sceneIndices);
			_nextExperience = experience;
			
			yield return new WaitForSeconds(delay);
			
			SceneManager.LoadScene(_nextScenesToLoad[0]);
			for (int i = 1; i < _nextScenesToLoad.Count; i++)
			{
				SceneManager.LoadScene(_nextScenesToLoad[i], LoadSceneMode.Additive);
			}
		}

		private IEnumerator FadeOut(float duration)
		{
			float timer = 0f;

			while (timer < duration)
			{
				timer += Time.deltaTime;
				yield return null;
			}
			
			Debug.Log("Scene faded out");
		}

		private IEnumerator FadeIn(float duration)
		{
			float timer = 0f;

			while (timer < duration)
			{
				timer += Time.deltaTime;
				yield return null;
			}
			
			Debug.Log("Scene faded in");
		}

		private void Start()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			Debug.Log("On scene loaded");
			foreach (int index in _nextScenesToLoad)
			{
				if (SceneManager.GetSceneByBuildIndex(index).isLoaded == false)
				{
					return;
				}
			}

			loadingScenes = false;
			StartExperience(_nextExperience);
		}
	}
}