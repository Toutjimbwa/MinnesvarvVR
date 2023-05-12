using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VRTK;

namespace TistouVR
{
    public class LoadSceneButton : VRTK_InteractableObject
    {
        public Experience.IDs _RunExperience;
        public Animator animator;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            animator.SetBool("press", true);
            FindObjectOfType<GameManager>().LoadExperience(_RunExperience);
        }
    }
}