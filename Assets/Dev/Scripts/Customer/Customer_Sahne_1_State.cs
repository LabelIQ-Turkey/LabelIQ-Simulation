using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Sahne_1_State : CustomerState
{
    public Transform Point;
    public GameObject Phone;

    public override IEnumerator StateProgression()
    {
        Customer.CustomerMovementLogic.DoMovement(Point.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerAnimationLogic.StartQrScanning(true);
        Phone.SetActive(true);
        yield return new WaitForSeconds(8f);
        Customer.CustomerAnimationLogic.StartQrScanning(false);

        yield break;

    }
}
