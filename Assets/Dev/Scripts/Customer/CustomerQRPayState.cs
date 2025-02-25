using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class CustomerQRPayState : CustomerState
{
    public Transform FirstMovePoint;
    public Transform SecondMovePoint;
    public ESL BuyEsl;
    public Transform Phone;

    public List<GameObject> ProductsBasket;
    public List<GameObject> ProductsRoof;

    public override IEnumerator StateProgression()
    {
        Customer.CustomerMovementLogic.DoMovement(FirstMovePoint.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerAnimationLogic.StartLookIK(BuyEsl.transform);
        yield return new WaitForSeconds(1f);

        foreach (var item in ProductsRoof)
        {
            item.transform.DOMove(item.transform.position + Vector3.up * .4f, .5f).SetEase(Ease.Linear);
           
        }
        yield return new WaitForSeconds(.4f);
        for (int i = 0; i < ProductsRoof.Count; i++)
        {
            Transform item = ProductsRoof[i].transform;
            item.transform.DOMove(ProductsBasket[0].transform.position, .5f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(.15f);
        }
        foreach (var item in ProductsRoof)
        {
            item.gameObject.SetActive(false);

        }
        foreach (var item in ProductsBasket)
        {
            item.SetActive(true);
        }
        yield return new WaitForSeconds(.5f);
        Phone.gameObject.SetActive(true);
        Customer.CustomerAnimationLogic.StartLeftHandIk(BuyEsl.transform);
        yield return new WaitForSeconds(.7f);
        BuyEsl.ShowLed();
        yield return new WaitForSeconds(.5f);
        BuyEsl.HideLed();
        yield return new WaitForSeconds(3f);
        Customer.CustomerAnimationLogic.EndLeftHandIK();
        Customer.CustomerAnimationLogic.EndLookIK();
        yield return new WaitForSeconds(3f);
        Customer.CustomerMovementLogic.DoMovement(SecondMovePoint.position);
        yield return new WaitForSeconds(1f);
        CameraAction_7.Instance.virtualCamera.LookAt = Customer.transform;
        //Phone.gameObject.SetActive(false);


    }
}
