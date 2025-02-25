using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerShoppingState : CustomerState
{
    public ESL LedEsl;
    public Transform FirstMovePoint;
    public Transform SecondMovePoint;
    public Transform ThirdMovePoint;
    public List<GameObject> Mango_Buys;

    public override IEnumerator StateProgression()
    {
        Customer.CustomerMovementLogic.DoMovement(FirstMovePoint.position);
        Customer.CustomerAnimationLogic.StartLookIK(CustomerLookHandle.Instance.Box);
        yield return new WaitForSeconds(1f);
        LedEsl.ShowLed();
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerAnimationLogic.EndLookIK();
        Customer.CustomerMovementLogic.DoMovement(SecondMovePoint.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerAnimationLogic.StartLookIK(LedEsl.transform);
        yield return CameraAction_2.Instance.ZoomIE();
        foreach (var item in Mango_Buys)
        {
            item.SetActive(true);
            item.transform.DOPunchScale(Vector3.one*.8f, .25f);
            yield return new WaitForSeconds(.4f);
        }
        CameraAction_2.Instance.Break();
        yield return new WaitForSeconds(1f);
        Customer.CustomerAnimationLogic.EndLookIK();
        Customer.CustomerMovementLogic.DoMovement(ThirdMovePoint.position);
      

        yield break;
    }
}
