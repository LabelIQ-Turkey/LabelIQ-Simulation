using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerMovementLogicMoveState : CustomerMovementLogicState
{
    public Vector3 Destination;

    public CustomerMovementLogicMoveState(CustomerMovementLogic customerMovementLogic)
        : base(customerMovementLogic)
    {

    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        CustomerMovementLogic.NavMeshAgent.isStopped = false;
        CustomerMovementLogic.NavMeshAgent.SetDestination(Destination);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (CustomerMovementLogic.NavMeshAgent.remainingDistance <= CustomerMovementLogic.NavMeshAgent.stoppingDistance)
        {
            CustomerMovementLogic.NavMeshAgent.SetDestination(CustomerMovementLogic.transform.position);
            CustomerMovementLogic.NavMeshAgent.isStopped = true;
            CustomerMovementLogic.MovementCompleted();
        }
    }

}
