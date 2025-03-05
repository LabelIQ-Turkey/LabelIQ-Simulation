using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RootMotion;
using RootMotion.FinalIK;
using JetBrains.Annotations;

public class Customer_Sahne_1_State : CustomerState
{
    public Transform Point;
    public GameObject Phone;
    public GameObject PhoneLeft;
    public Transform QrCamera;
    public Transform Qr;

    public Transform Point2;
    public ESL FocusEslSecondStep;
    public Transform CarSecondStep;
    public Transform CarRightHandPoint;
    public Transform CarLeftHandPoint;
    public Transform Point3;
     public Transform Point4;
     public GameObject TakeProduct;
     public Transform TakeProductDropPoint;
     public Transform TakeProductOnCart;
    public Transform TakeProductOnHand;
    public AimIK aimIK;
    public Transform aimIkTargetOnChart;

     public Transform Point5;
     public Transform Point6;
     public Transform Point7;

     public GameObject Modem;
     public ParticleSystem ModemParticle;

     public List<GameObject> ProductBuyA;
     public List<GameObject> ProductBuyB;
     public GameObject BuyParticle;
     public ParticleSystem SadEmeogy;
     public ESL ProductLowerEsl;

     public List<ESL> ChangeEslList;

     public Transform Point9;
     public Transform Point10;

     public GameObject FinalBuyProduct;
    public GameObject FinalBuyProductHand;
       public GameObject FinalBuyProductCart;
     public ESL FinalBuyEsl;
    public Transform Point11;
    public Transform AimIKFinalPoint;
    public Transform Point12;

    public override IEnumerator StateProgression()
    {
        VideoManager.Instance.PlayVoice(0,2);
        
        Customer.CustomerMovementLogic.DoMovement(Point.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerAnimationLogic.StartQrScanning(true);
        Customer.CustomerAnimationLogic.StartLookIK(Qr.transform);
        Phone.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(CanvasManager.Instance.Scene_1_Action());
        yield return new WaitForSeconds(.5f);
        StartCoroutine(QrCameraMovement());
        Phone.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Customer.CustomerAnimationLogic.StartQrScanning(false);
        yield return new WaitForSeconds(5f);
        Customer.CustomerAnimationLogic.EndLookIK();
        Phone.SetActive(false);
        yield return new WaitForSeconds(2f);
        Customer.CustomerMovementLogic.DoMovement(Point2.position);
        VideoManager.Instance.PlayVoice(1,3);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        CameraAction_7.Instance.SwitchCamera2();
        Customer.CustomerAnimationLogic.StartLeftHandIk(CarLeftHandPoint,true);
        yield return new WaitForEndOfFrame();
        CameraAction_7.Instance.virtualCamera2.Follow=null;
         CameraAction_7.Instance.virtualCamera2.LookAt=null;
        Customer.transform.DORotate(new Vector3(0,50,0),.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3f);
        FocusEslSecondStep.ShowLed();
        yield return new WaitForSeconds(1f);
        Customer.CustomerAnimationLogic.StartLookIK(FocusEslSecondStep.transform);
        yield return new WaitForSeconds(1f);
        Customer.transform.DORotate(new Vector3(0,0,0),.3f).SetEase(Ease.Linear);
         yield return new WaitForSeconds(.3f);
          CameraAction_7.Instance.virtualCamera2.Follow=Customer.transform;
         CameraAction_7.Instance.virtualCamera2.LookAt=Customer.transform;
        CarSecondStep.SetParent(transform);
        Customer.CustomerAnimationLogic.StartRightHandIk(CarRightHandPoint,true);
        Customer.CustomerAnimationLogic.StartLeftHandIk(CarLeftHandPoint,true);
        Customer.CustomerMovementLogic.DoMovement(Point3.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerMovementLogic.DoMovement(Point4.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
                CameraAction_7.Instance.SwitchCamera3();
        GameObject fakeRightHandObject_1=GameObject.Instantiate(CarRightHandPoint.gameObject);
        fakeRightHandObject_1.transform.SetPositionAndRotation(CarRightHandPoint.position,
        Quaternion.Euler(new Vector3(12,10,-143f)));
        
        Customer.CustomerAnimationLogic.StartRightHandIk(fakeRightHandObject_1.transform,true);
        fakeRightHandObject_1.transform.DOMove(TakeProduct.transform.position,.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(.6f);
        TakeProduct.gameObject.SetActive(true);
        TakeProduct.transform.SetParent(TakeProductOnHand.parent);
        TakeProduct.transform.localPosition=TakeProductOnHand.localPosition;
        TakeProduct.transform.localEulerAngles=TakeProductOnHand.localEulerAngles;
        fakeRightHandObject_1.transform.DOMove(TakeProductDropPoint.position,1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        Customer.CustomerAnimationLogic.StartLookIK(fakeRightHandObject_1.transform);
        fakeRightHandObject_1.transform.DORotate(fakeRightHandObject_1.transform.eulerAngles+Vector3.up*90,.7f)
        .SetEase(Ease.Linear);
        yield return new WaitForSeconds(.7f);
        fakeRightHandObject_1.transform.DORotate(fakeRightHandObject_1.transform.eulerAngles-Vector3.up*90,.7f)
        .SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.5f);
        Customer.CustomerAnimationLogic.EndRightHandIK();
        Customer.CustomerAnimationLogic.StartQrScanning(true);
        Customer.CustomerAnimationLogic.EndLookIK();
        aimIK.solver.IKPositionWeight=0;
        aimIK.enabled=true;
        DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, 1, .7f);
        yield return new WaitForSeconds(1.5f);
        Destroy(TakeProduct.gameObject);
        Customer.CustomerAnimationLogic.StartQrScanning(false);
        TakeProductOnCart.gameObject.SetActive(true);
        DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, 0, .4f)
           .SetEase(Ease.Linear); 
        yield return new WaitForSeconds(.4f);
        aimIK.enabled=false;
        Customer.CustomerAnimationLogic.StartRightHandIk(fakeRightHandObject_1.transform,true);
        fakeRightHandObject_1.transform.DORotate(CarRightHandPoint.transform.eulerAngles,1f);
        fakeRightHandObject_1.transform.DOMove(CarRightHandPoint.position,1f);
        yield return new WaitForSeconds(1f);
        Customer.CustomerAnimationLogic.StartRightHandIk(CarRightHandPoint.transform,true);
        Customer.CustomerMovementLogic.DoMovement(Point5.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        CameraAction_7.Instance.Camere3StopFollow();
        Customer.CustomerMovementLogic.DoMovement(Point6.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        Customer.CustomerMovementLogic.DoMovement(Point7.position);
        VideoManager.Instance.PlayVoice(2,2.5f);
        yield return new WaitForSeconds(2f);
        CameraAction_7.Instance.SwitchCamera4();
        Modem.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        ModemParticle.Play();
        yield return CameraAction_7.Instance.Camera4Action();
        ModemParticle.Stop();
        
        yield return new WaitForSeconds(13.5f);
        VideoManager.Instance.PlayVoice(3,3);
        yield return new WaitForSeconds(1f);
        CameraAction_7.Instance.SwitchCamera5();
        yield return new WaitForSeconds(2f);

        ProductBuyA.Sort((x,y)=>y.transform.position.y.CompareTo(x.transform.position.y));
        ProductBuyB.Sort((x,y)=>y.transform.position.y.CompareTo(x.transform.position.y));

        for(int i=0;i<4;i++)
        {
            for(int y=0;y<2;y++)
            {
            ProductBuyA[0].SetActive(false);
            GameObject spawnbuy1=Instantiate(BuyParticle,ProductBuyA[0].transform.position,Quaternion.identity);
            spawnbuy1.GetComponent<ParticleSystem>().Play();
            ProductBuyA.RemoveAt(0);
            }
            

            yield return new WaitForSeconds(.2f);

            ProductBuyB[0].SetActive(false);
            GameObject spawnbuy2=Instantiate(BuyParticle,ProductBuyB[0].transform.position,Quaternion.identity);
            spawnbuy2.GetComponent<ParticleSystem>().Play();
            ProductBuyB.RemoveAt(0);

            yield return new WaitForSeconds(.75f);
            SadEmeogy.Play();

        }
        CameraAction_7.Instance.SwitchCamera6();
        yield return new WaitForSeconds(3f);
        var price = ESL.PriceMaps.Find(x => x.Name.Equals(ProductLowerEsl.TextProductName.text, System.StringComparison.OrdinalIgnoreCase));
        StartCoroutine(ProductLowerEsl.ChangePriceText((price.Text-12).ToString("0.00")));
        ProductLowerEsl.ShowLed();
        yield return new WaitForSeconds(8.5f);
        ProductLowerEsl.HideLed();
        VideoManager.Instance.PlayVoice(4,2.5f);
        CameraAction_7.Instance.SwitchCamera7();
        ModemParticle.Play();
        Customer.CustomerMovementLogic.DoMovement(Point9.position);
        yield return new WaitForSeconds(4f);
        ModemParticle.Stop();
        ChangeEslList.Sort((x,y)=>x.transform.position.x.CompareTo(y.transform.position.x));
        foreach(var item in ChangeEslList)
        {
            var pricex = ESL.PriceMaps.Find(x => x.Name.Equals(item.TextProductName.text, System.StringComparison.OrdinalIgnoreCase));
           StartCoroutine(item.ChangePriceText(pricex.Text.ToString("0.00")));
           yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(4.5f);

        VideoManager.Instance.PlayVoice(5,2.5f);
        CameraAction_7.Instance.SwitchCamera8();
        Customer.CustomerMovementLogic.DoMovement(Point10.position);
        yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        
        CarSecondStep.transform.SetParent(null);
        Customer.CustomerAnimationLogic.EndRightHandIK();
        Customer.CustomerAnimationLogic.EndLeftHandIK();
        Customer.CustomerAnimationLogic.StartLookIK(FinalBuyEsl.transform);
        aimIkTargetOnChart.transform.position=AimIKFinalPoint.position;
               yield return new WaitForSeconds(1f);
        Customer.CustomerMovementLogic.DoMovement(Point11.position);
         yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        

        Customer.CustomerAnimationLogic.StartQrScanning(true);

        aimIK.solver.IKPositionWeight=0;
        aimIK.enabled=true;
        DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, .87f, .7f);
        yield return new WaitForSeconds(1f);
        FinalBuyProduct.gameObject.SetActive(false);
        FinalBuyProductHand.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Customer.CustomerAnimationLogic.EndLookIK();
        Customer.CustomerAnimationLogic.StartQrScanning(false);
         DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, 0, .4f);
        yield return new WaitForSeconds(1f);
        
         Customer.CustomerMovementLogic.DoMovement(Point12.position);
         yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
        
         Customer.CustomerAnimationLogic.StartQrScanning(true);
        DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, 1f, .7f);
        yield return new WaitForSeconds(.7f);
        FinalBuyProductHand.SetActive(false);
        FinalBuyProductCart.SetActive(true);
        Customer.CustomerAnimationLogic.StartQrScanning(false);
        DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, 0f, .5f);
        yield return new WaitForSeconds(.5f);
        CameraAction_7.Instance.SwitchCamera9();

         Customer.CustomerMovementLogic.DoMovement(Point11.position);
         yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);
         transform.DORotate(new Vector3(0,-194,0),.25f);
         PhoneLeft.SetActive(true);
         DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, .7f, .7f);
        yield return new WaitForSeconds(.7f);
         Customer.CustomerAnimationLogic.StartNFCScanning(true);
         StartCoroutine(CanvasManager.Instance.Scene_2_Action());
         yield return new WaitForSeconds(3f);
           DOTween.To(() => aimIK.solver.IKPositionWeight, x =>aimIK.solver.IKPositionWeight = x, 0, .4f);
        yield return new WaitForSeconds(.4f);
         yield return new WaitForSeconds(2f);
          Customer.CustomerAnimationLogic.StartNFCScanning(false);
         PhoneLeft.SetActive(false);
        Customer.CustomerMovementLogic.DoMovement(Point12.position);
         yield return new WaitUntil(() => Customer.CustomerMovementLogic.CurrentState is CustomerMovementLogicIdleState);

    }

    public IEnumerator QrCameraMovement()
    {
        QrCamera.transform.DORotate(new Vector3(0,87,0.85f),.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(.3f);
        Vector3 pos=QrCamera.transform.position;
        Vector3 pos2=QrCamera.transform.position;
        pos2.y+=.25f;
        QrCamera.transform.DOMove(pos2,.4f)
        .OnComplete(()=>
        {
             QrCamera.transform.DOMove(pos,.4f);
        });
         yield return new WaitForSeconds(.8f);
    }
}
