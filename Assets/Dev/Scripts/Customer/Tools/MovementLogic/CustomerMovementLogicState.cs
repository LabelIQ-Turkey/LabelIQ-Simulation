using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerMovementLogicState
{
    protected CustomerMovementLogic CustomerMovementLogic; 
    public CustomerMovementLogicState(CustomerMovementLogic customerMovementLogic)
    {
        CustomerMovementLogic = customerMovementLogic;
    }

    public virtual void OnStateEnter()
    {

    }
    public virtual void OnStateExit()
    {

    }

    public virtual void StateUpdate()
    {
        
    }
}
