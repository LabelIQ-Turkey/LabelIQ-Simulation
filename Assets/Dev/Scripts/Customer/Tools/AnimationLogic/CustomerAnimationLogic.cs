using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimationLogic : MonoBehaviour
{
    [HideInInspector]
    public Animator Animator;


    private Transform RightHandTarget;
    private bool RightHandIkOn;
            private bool RightHandIkRot;
    private float RightHandIkWeight;

     private Transform HeadIkTarget;
    private bool HeadIkTargetOn;
    private float HeadIkTargetWeight;

    private Transform LeftHandTarget;
    private bool LeftHandIkOn;
        private bool LeftHandIkRot;

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


    public void StartRightHandIk(Transform ikposition,bool rot=false)
    {
        RightHandTarget = ikposition;
        RightHandIkRot=rot;
        RightHandIkOn = true;
    }
    public void EndRightHandIK()
    {
        RightHandIkOn = false;
        RightHandIkWeight = 0;
    }

    public void StartLeftHandIk(Transform ikposition,bool rot=false)
    {
       LeftHandTarget = ikposition;
       LeftHandIkRot=rot;
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

    public void FixSecondLayer(){
         Animator.SetLayerWeight(1,1); 

    }
    public void BackSecondLayer(){
         Animator.SetLayerWeight(1,0.7f); 

    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (RightHandIkOn)
        {
            if (RightHandIkWeight < 1)
                RightHandIkWeight += Time.deltaTime*0.5f;
            Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, RightHandIkWeight);
            Animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);

             if(RightHandIkRot)
            {
                Animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1);
                Animator.SetIKRotation(AvatarIKGoal.RightHand,RightHandTarget.rotation);
            }
        }
        else
        {
            if (RightHandIkWeight >0)
                RightHandIkWeight -= Time.deltaTime * 0.5f;
            Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, RightHandIkWeight);
            Animator.SetIKRotationWeight(AvatarIKGoal.RightHand,RightHandIkWeight);
             if(RightHandTarget)
            Animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);

        }

        if (LeftHandIkOn)
        {
            if (LeftHandIkWeight < 1)
                LeftHandIkWeight += Time.deltaTime * 0.5f;
            Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
            Animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
            if(LeftHandIkRot)
            {
                Animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);
                Animator.SetIKRotation(AvatarIKGoal.LeftHand,LeftHandTarget.rotation);
            }
        }
        else
        {
            if (LeftHandIkWeight >0)
                LeftHandIkWeight -= Time.deltaTime * 0.5f;
            if(LeftHandTarget)
            Animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
            Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
                            Animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0);

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
