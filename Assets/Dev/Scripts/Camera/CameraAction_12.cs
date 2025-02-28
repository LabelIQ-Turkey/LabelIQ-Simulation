using Cinemachine;
using DG.Tweening;
using System.Collections;

public class CameraAction_12 : CameraAction
{
    public static CameraAction_12 Instance;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera virtualCamera2;
    public CinemachineVirtualCamera virtualCamera3;

    private void Awake()
    {
        Instance = this;
    }

    public override IEnumerator CameraMove()
    {
       
        yield break;
    }

    public void SwitchCamera()
    {
        virtualCamera.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);
    }
    public void SwitchCameraBack()
    {
        virtualCamera.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false);
    }

    public void FinalCamera()
    {
        virtualCamera.gameObject.SetActive(false);
        virtualCamera3.gameObject.SetActive(true);

    }



}
