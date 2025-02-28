using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Customer_Sahne_6_State : CustomerState
{
    public Transform Point1;
    public Transform Point2;
    public Transform Point3;

    public Transform pointRightHand;
    public Transform pointLeftHand;

    public ESL ProductEsl;
    public GameObject Product;
    public GameObject Car;
    public GameObject CarProduct;


    public Transform phone;

    public override IEnumerator StateProgression()
    {
        Customer.CustomerAnimationLogic.StartLeftHandIk(pointLeftHand);
        Customer.CustomerAnimationLogic.StartRightHandIk(pointRightHand);

        Customer.CustomerMovementLogic.DoMovement(Point1.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerMovementLogic.DoMovement(Point2.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);

        Customer.CustomerAnimationLogic.EndRightHandIK();
        yield return new WaitForSeconds(1);


        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 pos = Product.transform.position;
        pos.y = transform.position.y;

        Car.transform.parent = null;
        transform.rotation = Quaternion.LookRotation(pos - transform.position);
        Customer.CustomerAnimationLogic.TriggerTakeProduct();

        yield return new WaitForSeconds(1f);
        Product.transform.SetParent(phone.parent);
        Product.transform.localPosition = Vector3.zero;
        yield return new WaitForSeconds(1);

        Vector3 movepoint = CarProduct.transform.position;
        movepoint.y = Product.transform.position.y;
        Product.transform.DOMove(movepoint, .5f).SetEase(Ease.Linear)
            .OnComplete(()=> 
            {
                Product.transform.DOMove(CarProduct.transform.position, .2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    CarProduct.SetActive(true);
                    Product.SetActive(false);
                    transform.rotation = Quaternion.Euler(rot);
                });
            });
        CameraAction_12.Instance.SwitchCamera();
        yield return new WaitForSeconds(2f);
        transform.rotation = Quaternion.LookRotation(pos - transform.position);
        phone.gameObject.SetActive(true);
        Customer.CustomerAnimationLogic.StartQrScanning(true);
        Customer.CustomerAnimationLogic.StartRightHandIk(ProductEsl.transform);

        yield return new WaitForSeconds(5f);
        CameraAction_12.Instance.SwitchCameraBack();
        phone.gameObject.SetActive(false);
        Customer.CustomerAnimationLogic.StartQrScanning(false);
        Customer.CustomerAnimationLogic.EndRightHandIK();
        transform.rotation = Quaternion.Euler(rot);
        Car.transform.SetParent(transform);
        Customer.CustomerAnimationLogic.StartRightHandIk(pointRightHand.transform);

        yield return new WaitForSeconds(2f);
        CameraAction_12.Instance.FinalCamera();
        Customer.CustomerMovementLogic.DoMovement(Point3.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);

        yield break;

    }

    
}
