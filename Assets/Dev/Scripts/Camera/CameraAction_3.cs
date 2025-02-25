using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction_3 : CameraAction
{
    public static CameraAction_3 Instance;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
        
        yield break;
    }

    public IEnumerator FirstMove()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 0.85f, 4f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(4);
    }
    public IEnumerator SecondMove()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 0.48f, 2f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(2);
    }


}
