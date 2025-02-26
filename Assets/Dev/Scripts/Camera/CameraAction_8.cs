using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CameraAction_8 : CameraAction
{
    public static CameraAction_8 Instance;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
       
        yield break;
    }
   

    public void LookEsl()
    {
        CinemachineComposer transposer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
        DOTween.To(() => transposer.m_TrackedObjectOffset, x => transposer.m_TrackedObjectOffset = x, new Vector3(-0.96f,1.72f,0), 1f)
          .SetEase(Ease.Linear);
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 9f, 1f)
                 .SetEase(Ease.Linear);
    }
    public void DeLookEsl()
    {
        CinemachineComposer transposer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
        DOTween.To(() => transposer.m_TrackedObjectOffset, x => transposer.m_TrackedObjectOffset = x, new Vector3(-0.33f, 1.72f, 0), 1.5f)
          .SetEase(Ease.Linear);
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 60f, 1.5f)
                 .SetEase(Ease.Linear);
    }



}
