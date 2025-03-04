using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractionDoor : InteractionBase
{
    public Vector3 RotatePosOne;
    public Vector3 RotatePosSecond;
    public Transform DoorOne;
    public Transform DoorSecond;
   
   
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.GetComponent<Customer>())
        {
            OpenDoor();

          
          
        }
    }
    private void OpenDoor()
    {
        Quaternion targetRotationOne = Quaternion.Euler(RotatePosOne);
        Quaternion targetRotationSecond = Quaternion.Euler(RotatePosSecond);

       
        DoorOne.DOLocalRotate(targetRotationOne.eulerAngles, 0.75f);
        DoorSecond.DOLocalRotate(targetRotationSecond.eulerAngles, 0.75f).OnComplete(()=>
        {
            //CameraAction_7.Instance.FocusQR();


        });
    }
}
