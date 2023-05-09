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
        public AudioClip _StoryAudio;
        public AudioClip _SFXClick;
        public Animator animator;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            animator.SetBool("press", true);
            FindObjectOfType<GameManager>().LoadScenes(sceneIndexes, _SFXClick, _StoryAudio);
        }
    }
}