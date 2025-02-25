using Cinemachine;
using DG.Tweening;
using System.Collections;

public class CameraAction_7 : CameraAction
{
    public static CameraAction_7 Instance;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 1f, 3f)
           .SetEase(Ease.Linear); // Yumu�ak ge�i� i�in easing ekle
        yield break;
    }

    
   

}
