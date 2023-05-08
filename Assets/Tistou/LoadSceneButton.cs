using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace TistouVR
{
    public class LoadSceneButton : VRTK_InteractableObject
    {
        public int[] sceneIndexes;
        public AudioSource audio;
        public Animator animator;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            audio.Play();
            animator.SetBool("press", true);
            FindObjectOfType<GameManager>().LoadScenes(sceneIndexes);
        }
    }
}