using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CameraAction_9 : CameraAction
{
    public static CameraAction_9 Instance;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
       
        yield break;
    }

    public void FirstMove()
    {
        CinemachineTrackedDolly transposer = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();

        DOTween.To(() => transposer.m_PathPosition, x => transposer.m_PathPosition = x, .7f, 3f)
         .SetEase(Ease.Linear).OnComplete(() =>
         {
             DOTween.To(() => transposer.m_PathPosition, x => transposer.m_PathPosition = x, .9F, 1f).SetEase(Ease.Linear);
             DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 60, 3f)
         .SetEase(Ease.Linear);
         });
    }

    public void LookGateway()
    {
        virtualCamera.transform.DORotate(new Vector3(18, 140, 0), 2f).SetEase(Ease.Linear);
    }
   

   


}
