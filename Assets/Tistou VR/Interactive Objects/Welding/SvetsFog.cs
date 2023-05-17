using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TistouVR
{
    public class SvetsFog : MonoBehaviour
    {
        public GameObject _SvetsVFXPrefab;
        public GameObject _WeldedSuccessModel;
        public GameObject _WeldedFailModel;
        public MeshRenderer _DebugMesh;
        
        private bool _Welded = false;
        private SvetsStation _svetsStation;
        private static int _WeldsLeft;
        
        private void Awake()
        {
            _svetsStation = FindObjectOfType<SvetsStation>();
            _WeldsLeft++;
            _DebugMesh.enabled = false;
        }

        public void TryWeld()
        {
            if(_Welded) return;
            _Welded = true;

            //VFX
            GameObject VFX = Instantiate(_SvetsVFXPrefab, transform.position, transform.rotation);
            Destroy(VFX, 1);

            int random = Random.Range(0, 3);
            if(random == 0) WeldFail();
            else WeldSucceed();
            
            _WeldsLeft--;
            if (_WeldsLeft == 0)
            {
                _svetsStation.AllWelded();
            }
        }

        public void WeldFail()
        {
            //Melt
            _WeldedFailModel.SetActive(true);
            
            //Game state change
            _svetsStation.BadWeld();
        }
        public void WeldSucceed()
        {
            //Melt
            _WeldedSuccessModel.SetActive(true);
            
            //Game state change
            _svetsStation.GoodWeld();
        }
    }
}