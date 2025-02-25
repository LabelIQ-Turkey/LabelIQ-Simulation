using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction_6 : CameraAction
{
    public static CameraAction_6 Instance;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 1f, 3f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield break;
    }

    public IEnumerator CameraMove_1()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, .45f, 1f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(3f);
    }
   

}
