using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimationLogic : MonoBehaviour
{
    [HideInInspector]
    public Animator Animator;


    private Transform RightHandTarget;
    private bool RightHandIkOn;
    private float RightHandIkWeight;

     private Transform HeadIkTarget;
    private bool HeadIkTargetOn;
    private float HeadIkTargetWeight;

    private Transform LeftHandTarget;
    private bool LeftHandIkOn;
    private float LeftHandIkWeight;

    void Awake()
    {
        TryGetComponent(out Animator);
    }

    public void RegisterMovementLogic(CustomerMovementLogic customerMovementLogic)
    {
        customerMovementLogic.OnMovementStarted += CustomerMovementLogic_OnMovementStarted;
        customerMovementLogic.OnMovementCompleted += CustomerMovementLogic_OnMovementCompleted;
    }

    private void CustomerMovementLogic_OnMovementCompleted()
    {
        Animator.SetBool("Moving", false);
    }

    private void CustomerMovementLogic_OnMovementStarted()
    {
        Animator.SetBool("Moving", true);

    }

    public void StartQrScanning(bool status)
    {
        Animator.SetBool("qrscanning", status);

    }
    public void StartNFCScanning(bool status)
    {
        Animator.SetBool("nfcscaning", status);

    }

    public void TriggerTakeProduct()
    {
        Animator.SetTrigger("takeproduct");

    }


    public void StartRightHandIk(Transform ikposition)
    {
        RightHandTarget = ikposition;
        RightHandIkOn = true;
    }
    public void EndRightHandIK()
    {
        RightHandIkOn = false;
        RightHandIkWeight = 0;
    }

    public void StartLeftHandIk(Transform ikposition)
    {
       LeftHandTarget = ikposition;
        LeftHandIkOn = true;
    }
    public void EndLeftHandIK()
    {
        LeftHandIkOn = false;
    }


    public void StartLookIK(Transform ikposition)
    {
        HeadIkTarget = ikposition;
        HeadIkTargetOn = true;
    }
    public void EndLookIK()
    {
        HeadIkTargetOn = false;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (RightHandIkOn)
        {
            if (RightHandIkWeight < 1)
                RightHandIkWeight += Time.deltaTime*0.5f;
            Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, RightHandIkWeight);
            Animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
        }
        else
        {
            Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
        }

        if (LeftHandIkOn)
        {
            if (LeftHandIkWeight < 1)
                LeftHandIkWeight += Time.deltaTime * 0.5f;
            Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
            Animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
        }
        else
        {
            if (LeftHandIkWeight >0)
                LeftHandIkWeight -= Time.deltaTime * 0.5f;
            if(LeftHandTarget)
            Animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
            Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
        }


        if (HeadIkTargetOn)
        {
            if (HeadIkTargetWeight < 1)
                HeadIkTargetWeight += Time.deltaTime*2;
            Animator.SetLookAtWeight(HeadIkTargetWeight);
            Animator.SetLookAtPosition(HeadIkTarget.position);
        }
        else
        {
            if (HeadIkTargetWeight > 0)
                HeadIkTargetWeight -= Time.deltaTime * 0.5f;
            if(HeadIkTarget)
            Animator.SetLookAtPosition(HeadIkTarget.position);
            Animator.SetLookAtWeight(HeadIkTargetWeight);
        }
       

    }
}
