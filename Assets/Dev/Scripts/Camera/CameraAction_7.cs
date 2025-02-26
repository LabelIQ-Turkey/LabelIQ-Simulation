using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CameraAction_7 : CameraAction
{
    public static CameraAction_7 Instance;
    public CinemachineVirtualCamera virtualCamera;
    public Vector3 focusQROffset;

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
    public void FocusQR()
    {
        CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        DOTween.To(() => transposer.m_FollowOffset, x => transposer.m_FollowOffset = x, focusQROffset, 1.5f)
          .SetEase(Ease.Linear);
    }

    
   

}
