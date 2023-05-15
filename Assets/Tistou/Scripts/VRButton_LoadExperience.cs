using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VRTK;

namespace TistouVR
{
    public class VRButton_LoadExperience : VRTK_InteractableObject
    {
        public Experience.IDs _RunExperience;
        public Animator animator;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            PressButton();
        }

        private void PressButton()
        {
            animator.SetTrigger("press");
            FindObjectOfType<GameManager>().LoadExperience(_RunExperience);
        }
    }
}