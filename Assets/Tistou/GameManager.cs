using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TistouVR
{
	public class GameManager : MonoBehaviour
	{
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
		
		public void LoadScenes(int[] sceneIndexes)
		{
			if (loadingScenes) return;
			loadingScenes = true;
			SceneManager.LoadScene(sceneIndexes[0]);
			for (int i = 1; i < sceneIndexes.Length; i++)
			{
				SceneManager.LoadScene(sceneIndexes[i], LoadSceneMode.Additive);	
			}
		}
	}
}