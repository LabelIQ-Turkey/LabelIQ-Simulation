using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction_2 : CameraAction
{
    public static CameraAction_2 Instance;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
        yield break;
    }

   
    public IEnumerator ZoomIE()
    {
        virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset =
            new Vector3(.5f, 1f, 0f);
       DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 20, 1.5f)
               .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(3f);
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 60, 1.5f)
              .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
    }
    public void Break()
    {
        virtualCamera.LookAt = null;
        virtualCamera.Follow = null;
    }
}
