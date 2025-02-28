using Cinemachine;
using DG.Tweening;
using System.Collections;

public class CameraAction_11 : CameraAction
{
    public static CameraAction_11 Instance;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera virtualCameraFirst;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
       
        yield break;
    }
    public void MoveFirst()
    {
        virtualCameraFirst.gameObject.SetActive(false);
        virtualCamera.gameObject.SetActive(true);
    }
    public void Move()
    {
        virtualCamera.transform.DORotate(new UnityEngine.Vector3(20, 174, 0), 3f).SetEase(Ease.Linear);
    }

   


}
