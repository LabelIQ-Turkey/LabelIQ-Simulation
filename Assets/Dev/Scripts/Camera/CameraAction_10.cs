using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CameraAction_10 : CameraAction
{
    public static CameraAction_10 Instance;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
        yield break;
    }

    public void Move()
    {
        CinemachineTrackedDolly transposer = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => transposer.m_PathPosition, x => transposer.m_PathPosition = x, 1, 3f)
       .SetEase(Ease.Linear);
    }

    public void Move2()
    {
        CinemachineTrackedDolly transposer = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => transposer.m_PathOffset, x => transposer.m_PathOffset = x,new Vector3(-1.18f,-.31f,0), 3f)
       .SetEase(Ease.Linear);
    }

    public void Move3()
    {
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, 30, 2f)
       .SetEase(Ease.Linear);
        CinemachineTrackedDolly transposer = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => transposer.m_PathOffset, x => transposer.m_PathOffset = x, new Vector3(-1.18f, 0, 0), 2f)
       .SetEase(Ease.Linear);
    }





}
