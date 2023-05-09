using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TistouVR
{
	public class GameManager : MonoBehaviour
	{
		public int[] _StartMenuSceneIndices;
		public AudioSource _StoryAudioSource;
		public AudioSource _SFXAudioSource;
		
		private bool loadingScenes = false;
		private static GameManager instance;

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

		public void LoadStartMenu()
		{
			LoadScenes(_StartMenuSceneIndices);
		}
		
		public void LoadScenes(int[] sceneIndexes)
		{
			if (loadingScenes) return;
			loadingScenes = true;

			float halfTime = 3;

			StartCoroutine(FadeAndLoadScene(sceneIndexes, halfTime, halfTime));
		}
		
		public void LoadScenes(int[] sceneIndexes, AudioClip sfx, AudioClip storyAudio)
		{
			if (loadingScenes) return;
			loadingScenes = true;

			_SFXAudioSource.clip = sfx;
			_SFXAudioSource.Play();
			_StoryAudioSource.clip = storyAudio;
			_StoryAudioSource.Play();

			float halfTime = _StoryAudioSource.clip.length / 2;

			StartCoroutine(FadeAndLoadScene(sceneIndexes, halfTime, halfTime));
		}

		private IEnumerator FadeAndLoadScene(int[] scenes, float fadeOutDuration, float fadeInDuration)
		{
			float timer = 0f;

			while (timer < fadeOutDuration)
			{
				timer += Time.deltaTime;
				yield return null;
			}

			SceneManager.LoadScene(scenes[0]);
			for (int i = 1; i < scenes.Length; i++)
			{
				SceneManager.LoadScene(scenes[i], LoadSceneMode.Additive);	
			}
			loadingScenes = false;

			StartCoroutine(FadeIn(fadeInDuration));
		}

		private IEnumerator FadeIn(float fadeInDuration)
		{
			float timer = 0f;

			while (timer < fadeInDuration)
			{
				timer += Time.deltaTime;
				yield return null;
			}
			
			Debug.Log("Scene faded in");
		}
	}
}