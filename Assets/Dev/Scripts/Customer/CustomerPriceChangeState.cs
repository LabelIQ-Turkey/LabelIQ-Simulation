using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerPriceChangeState : CustomerState
{
    public ESL Test;
    public List<GameObject> FruitPack;
    public List<GameObject> FruitPack2;
    public GameObject EffectBuy;
    public ParticleSystem[] EffectWarning;
    public MeshRenderer failproductRenderer;
     

    public override IEnumerator StateProgression()
    {


        yield return CameraAction_4.Instance.CameraMove_1();
        yield return new WaitForSeconds(1f);
        yield return CameraAction_4.Instance.CameraMove_2();
        yield return new WaitForSeconds(1f);

        FruitPack.Sort((y, x) => x.transform.position.y.CompareTo(y.transform.position.y));
        FruitPack2.Sort((y, x) => x.transform.position.y.CompareTo(y.transform.position.y));
        for (int i = 0; i < 10; i++)
        {
            var itemx = FruitPack[i];
            var itemy = FruitPack2[i];
            itemx.transform.DOMove(itemx.transform.position + Vector3.up * .3f, .3f).SetEase(Ease.Linear);
            itemx.transform.DOScale(Vector3.one * 1.6f, .25f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(.2f);
            itemy.transform.DOMove(itemy.transform.position + Vector3.up * .3f, .3f).SetEase(Ease.Linear);
            itemy.transform.DOScale(Vector3.one * 1.6f, .25f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(.3f);
            itemx.transform.DOScale(Vector3.zero, .1f).SetEase(Ease.Linear);
            itemy.transform.DOScale(Vector3.zero, .1f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(.4f);
            if (i>=2&&i%2==0)
            {
                EffectWarning[Random.Range(0, EffectWarning.Length)].Play();
                Color currentColortemp = failproductRenderer.material.GetColor("_BaseColor");
                Color currentColor = failproductRenderer.material.GetColor("_BaseColor");
                DOTween.To(() => currentColor,
                        x => {
                            Color newColor = Color.red;
                            failproductRenderer.material.SetColor("_BaseColor", newColor);
                        }, Color.red,
                        .5f).OnComplete(() => 
                        {
                            failproductRenderer.material.SetColor("_BaseColor", currentColortemp);
                        })
                    .SetEase(Ease.InOutSine);
            }
            
        }
        yield return CameraAction_4.Instance.CameraMove_3();
        var price = ESL.PriceMaps.Find(x => x.Name.Equals(Test.TextProductName.text, System.StringComparison.OrdinalIgnoreCase));
        yield return Test.ChangePriceText((price.Text - 4f).ToString());
        Test.ShowLed();
        yield return new WaitForSeconds(2f);
        yield return CameraAction_4.Instance.CameraMove_4();
        yield break;
    }
}
