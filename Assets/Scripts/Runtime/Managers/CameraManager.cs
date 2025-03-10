using System;
using Runtime.Signals;
using UnityEngine;
using Unity.Cinemachine;
using Unity.Mathematics;

namespace Runtime.Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Seriazlied Variables
        
        [SerializeField] private CinemachineCamera virtualCamera;
        
        #endregion

        #region Private Variables
        
        private float3 _firstPosition;
        
        #endregion
        
        #endregion
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnReset()
        {
            transform.position = _firstPosition;
        }

        private void OnSetCameraTarget()
        {
            //var player = FindObjectOfType<PlayerManger>().transform;
            //virtualCamera.Follow = player;
            //virtualCamera.LookAt = player;
        }
        
        private void UnsubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _firstPosition = transform.position;
        }
    }
}