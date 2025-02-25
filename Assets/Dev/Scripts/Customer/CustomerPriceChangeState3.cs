using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerPriceChangeState3 : CustomerState
{
    public List<ESL> Tests;
    public ParticleSystem ModemParticle;
     

    public override IEnumerator StateProgression()
    {
       // yield return CameraAction_6.Instance.CameraMove_1();
        yield return new WaitForSeconds(1f);
        ModemParticle.Play();
        yield return new WaitForSeconds(1f);
        ModemParticle.Stop();
        foreach (var test in Tests)
        {
            var price = ESL.PriceMaps.Find(x => x.Name.Equals(test.TextProductName.text, System.StringComparison.OrdinalIgnoreCase));
            StartCoroutine(test.ChangePriceText(price.Text.ToString()));
            yield return new WaitForSeconds(.1f);

        }
        
    }
}
