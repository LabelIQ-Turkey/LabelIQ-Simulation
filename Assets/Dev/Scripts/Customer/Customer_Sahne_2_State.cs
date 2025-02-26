using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Sahne_2_State : CustomerState
{
    public Transform Point;
    public Transform Point2;
    public ESL TargetEsl;
    public GameObject Product;
    public GameObject ProductBody;

    public override IEnumerator StateProgression()
    {
        TargetEsl.ShowLed();
        yield return new WaitForSeconds(2f);
        Customer.CustomerAnimationLogic.StartLookIK(TargetEsl.transform);
        yield return new WaitForSeconds(1f);
        CameraAction_8.Instance.LookEsl();
        yield return new WaitForSeconds(2f);
        CameraAction_8.Instance.DeLookEsl();
        yield return new WaitForSeconds(2f);
        Customer.CustomerMovementLogic.DoMovement(Point.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerAnimationLogic.TriggerTakeProduct();
        yield return new WaitForSeconds(1f);
        Product.SetActive(false);
        ProductBody.SetActive(true);
        CameraAction_8.Instance.virtualCamera.LookAt = null;
        CameraAction_8.Instance.virtualCamera.Follow = null;
        Customer.CustomerAnimationLogic.EndLookIK();
        yield return new WaitForSeconds(.5f);
        Customer.CustomerMovementLogic.DoMovement(Point2.position);

        yield break;

    }
}
