using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CameraAction_7 : CameraAction
{
    public CinemachineBrain cinemachineBrain;
    public static CameraAction_7 Instance;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera virtualCamera2;
    public CinemachineVirtualCamera virtualCamera3;
    public CinemachineVirtualCamera virtualCamera4;
    public CinemachineVirtualCamera virtualCamera5;
    public CinemachineVirtualCamera virtualCamera6;
    public CinemachineVirtualCamera virtualCamera7;
    public CinemachineVirtualCamera virtualCamera8;

    private void Awake()
    {
        Instance = this;
        cinemachineBrain=GameObject.FindAnyObjectByType<CinemachineBrain>();
    }

    public override IEnumerator CameraMove()
    {
        var cinemachineTrackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        DOTween.To(() => cinemachineTrackedDolly.m_PathPosition, x => cinemachineTrackedDolly.m_PathPosition = x, 1f, 3f)
           .SetEase(Ease.Linear); // Yumu�ak ge�i� i�in easing ekle
        yield break;
    }
   
    public void SwitchCamera2()
    {
        virtualCamera.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);
    }
    public void SwitchCamera3()
    {
        virtualCamera2.gameObject.SetActive(false);
        virtualCamera3.gameObject.SetActive(true);
    }
    public void Camere3StopFollow()
    {
        virtualCamera3.gameObject.SetActive(false);
    }
     public void SwitchCamera4()
    {
        virtualCamera3.gameObject.SetActive(false);
        virtualCamera4.gameObject.SetActive(true);
    }

    public IEnumerator Camera4Action()
    {
        CinemachineTransposer transposer = virtualCamera4.GetCinemachineComponent<CinemachineTransposer>();
        DOTween.To(() => transposer.m_FollowOffset, x => transposer.m_FollowOffset = x, new Vector3(0, -1.57f, -6.59f), 4f)
          .SetEase(Ease.Linear);
          yield return new WaitForSeconds(4f);
    }

     public void SwitchCamera5()
    {
        cinemachineBrain.m_DefaultBlend.m_Time=0.5f;
        virtualCamera4.gameObject.SetActive(false);
        virtualCamera5.gameObject.SetActive(true);
    }
    public void SwitchCamera6()
    {
        cinemachineBrain.m_DefaultBlend.m_Time=0.5f;
        virtualCamera5.gameObject.SetActive(false);
        virtualCamera6.gameObject.SetActive(true);
    }
    public void SwitchCamera7()
    {
        cinemachineBrain.m_DefaultBlend.m_Time=0;
        virtualCamera6.gameObject.SetActive(false);
        virtualCamera7.gameObject.SetActive(true);
    }
    public void SwitchCamera8()
    {
        cinemachineBrain.m_DefaultBlend.m_Time=0;
        virtualCamera7.gameObject.SetActive(false);
        virtualCamera8.gameObject.SetActive(true);
    }
   

}
