using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerPriceChangeState2 : CustomerState
{
    public ESL Test;

     

    public override IEnumerator StateProgression()
    {
        yield return CameraAction_5.Instance.CameraMove_1();
        yield return new WaitForSeconds(1f);
        var price = ESL.PriceMaps.Find(x => x.Name.Equals(Test.TextProductName.text, System.StringComparison.OrdinalIgnoreCase));
        yield return Test.ChangePriceText((price.Text - 3.44f).ToString());
    }
}
