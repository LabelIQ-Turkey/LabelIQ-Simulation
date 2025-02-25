using System;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovementLogic : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;


    public event Action OnMovementStarted;
    public event Action OnMovementCompleted;


    public CustomerMovementLogicState CurrentState;
    public CustomerMovementLogicIdleState CustomerMovementLogicIdleState;
    public CustomerMovementLogicMoveState customerMovementLogicMoveState;

    private void Awake()
    {
        CustomerMovementLogicIdleState = new CustomerMovementLogicIdleState(this);
        customerMovementLogicMoveState = new CustomerMovementLogicMoveState(this);
        CurrentState = CustomerMovementLogicIdleState;
    }

    private void Update()
    {
        CurrentState?.StateUpdate();
    }

    public void DoMovement(Vector3 position)
    {
        customerMovementLogicMoveState.Destination = position;
        SwitchState(customerMovementLogicMoveState);
        OnMovementStarted?.Invoke();
    }

    public void MovementCompleted()
    {
        SwitchState(CustomerMovementLogicIdleState);
        OnMovementCompleted?.Invoke();
    }

    public void SwitchState(CustomerMovementLogicState customerMovementLogicstate)
    {
        CurrentState?.OnStateExit();
        CurrentState = customerMovementLogicstate;
        CurrentState?.OnStateEnter();
    }



}
