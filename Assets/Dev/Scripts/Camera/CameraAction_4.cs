using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction_4 : CameraAction
{
    public static CameraAction_4 Instance;
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
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, .07f, 3f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(3f);
    }
    public IEnumerator CameraMove_2()
    {
      
          var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        cinemachineTrackedDolly.m_PathPosition = .5f;
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 1, 1.5f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator CameraMove_3()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathOffset, x => cinemachineTrackedDolly.m_PathOffset = x, new Vector3(-.5f,-.2f,0), 1.5f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 35, 1.5f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator CameraMove_4()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathOffset, x => cinemachineTrackedDolly.m_PathOffset = x, Vector3.zero, 1.5f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 60, 1.5f)
           .SetEase(Ease.Linear); // Yumuþak geçiþ için easing ekle
        yield return new WaitForSeconds(2f);
    }

}
