using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using VRTK;
using VRTK.UnityEventHelper;

namespace TistouVR
{
	public class GameManager : MonoBehaviour
	{

		private static int STARTMENU_SCENE_INDEX = 0;

		public float _FadeOutDelayForStations = 4;
		
		[Header("Start Helvarv")] //Helvarv
		public AudioClip _HelvarvStartAudioClip;
		private static int[] LEVEL_SCENES = new []{1,2};

		[Header("Audio")]
		public AudioSource _StoryAudioSource;
		public AudioSource _SFXAudioSource;

		[Header("Teleportation")]
		public Teleport _Teleport;
		public VRTK_ControllerEvents _TeleportingEvents;

		[Header("Tour")]
		public VRTK_TransformFollow _vrtkTransformFollow;
		
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
			
			_nextExperience = experienceID;
			
			switch (experienceID)
			{
				case Experience.IDs.StoryToWeld:
					StartStoryToWeld();
					break;
				default:
					LoadScenesNoAudio(_FadeOutDelayForStations, LEVEL_SCENES, experienceID);
					break;
			}
		}

		private void StartStoryToWeld()
		{
			LoadScenesWithAudio(_HelvarvStartAudioClip.length, LEVEL_SCENES, Experience.IDs.StoryToWeld, _HelvarvStartAudioClip);
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
					_Teleport.ToExperience(e, _TeleportingEvents);
					if (e is Tour)
					{
						_vrtkTransformFollow.gameObjectToFollow = e._TeleportPosition.gameObject;
						_vrtkTransformFollow.enabled = true;
					}
					e.StartExperience();
					break;
				}
			}
		}

		private void LoadScenesWithAudio(float fadeOutDelay, int[] sceneIndices, Experience.IDs experience, AudioClip exitAudioClip)
		{
			_StoryAudioSource.clip = exitAudioClip;
			_StoryAudioSource.Play();
			
			LoadScenesNoAudio(fadeOutDelay, sceneIndices, experience);
		}
		
		private void LoadScenesNoAudio(float fadeOutDelay, int[] sceneIndices, Experience.IDs experience)
		{
			FadeOut(_HelvarvStartAudioClip.length);
			StartCoroutine(LoadScenesWithDelay(fadeOutDelay, sceneIndices, experience));
		}
		
		private IEnumerator LoadScenesWithDelay(float delay, int[] sceneIndices, Experience.IDs experience)
		{
			_nextScenesToLoad.Clear();
			_nextScenesToLoad.AddRange(sceneIndices);

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
		}

		private IEnumerator FadeIn(float duration)
		{
			float timer = 0f;

			while (timer < duration)
			{
				timer += Time.deltaTime;
				yield return null;
			}
		}

		private void Start()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
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