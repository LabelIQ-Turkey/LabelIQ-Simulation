using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAgent : MonoBehaviour
{
    public static event Action<CameraAction> OnCameraActionStarted;
    public static event Action<CameraAction> OnCameraActionEnded;

    public List<CameraActionMap> CameraActions;


    public IEnumerator Start()
    {
        foreach (var item in CameraActions)
        {
            yield return new WaitForSeconds(item.StartDelay);
            OnCameraActionStarted?.Invoke(item.CameraAction);
            yield return item.CameraAction.CameraMove();
            yield return new WaitForSeconds(item.EndDelay);
            OnCameraActionEnded?.Invoke(item.CameraAction);
        }
    }

    [System.Serializable]
    public struct CameraActionMap
    {
        public float StartDelay;
        public CameraAction CameraAction;
        public float EndDelay;
    }
}
