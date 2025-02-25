using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutomerQRScanState : CustomerState
{
    public Transform MovePosition;
    public Transform QRPoint;
    public CustomerMovementLogic CustomerMovementLogic => Customer.CustomerMovementLogic;
    public CustomerAnimationLogic CustomerAnimationLogic => Customer.CustomerAnimationLogic;

    public bool CameraActionDone;

    private void Start()
    {
        CameraAgent.OnCameraActionEnded += CameraAgent_OnCameraActionEnded;
    }

 

    public override IEnumerator StateProgression()
    {
        yield return new WaitUntil(() => CameraActionDone);
        Customer.CustomerMovementLogic.DoMovement(MovePosition.position);
        yield return new WaitForSeconds(.5f);
        yield return new WaitUntil(() => CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        CustomerAnimationLogic.StartRightHandIk(QRPoint);

    }

    private void CameraAgent_OnCameraActionEnded(CameraAction obj)
    {
        if (obj.Key == "firstcamera")
        {
            CameraActionDone = true;
        }
    }
}
