using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAction_1 : CameraAction
{
    public CinemachineVirtualCamera VirtualCamera;

    public override IEnumerator CameraMove()
    {
        VirtualCamera.gameObject.SetActive(true);
        CinemachineTrackedDolly cinemachineTrackedDolly = VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();

        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 0.7f, 4f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(4f);
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 0f, 3.3f)
          .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(4f);
        VirtualCamera.gameObject.SetActive(false);

    }
}
