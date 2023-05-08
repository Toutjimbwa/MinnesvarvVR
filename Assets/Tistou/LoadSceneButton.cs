using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VRTK;

namespace TistouVR
{
    public class LoadSceneButton : VRTK_InteractableObject
    {
        public int[] sceneIndexes;
        public AudioSource _AudioSource;
        public Animator animator;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            _AudioSource.Play();
            animator.SetBool("press", true);
            FindObjectOfType<GameManager>().LoadScenes(sceneIndexes);
        }
    }
}