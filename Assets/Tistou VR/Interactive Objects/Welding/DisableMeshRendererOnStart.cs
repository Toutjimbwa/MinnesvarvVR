using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouVR
{
	public class DisableMeshRendererOnStart : MonoBehaviour
	{
		public MeshRenderer _MeshRenderer;
		
		void Start ()
		{
			_MeshRenderer.enabled = false;
		}
	}
}