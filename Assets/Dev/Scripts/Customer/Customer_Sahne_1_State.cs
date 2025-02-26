using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Sahne_1_State : CustomerState
{
    public Transform Point;

    public override IEnumerator StateProgression()
    {
        Customer.CustomerMovementLogic.DoMovement(Point.position);

        yield break;

    }
}
