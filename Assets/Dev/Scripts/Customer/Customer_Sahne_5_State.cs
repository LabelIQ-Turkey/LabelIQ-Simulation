using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Sahne_5_State : CustomerState
{
    public ParticleSystem modemparticle;

    public override IEnumerator StateProgression()
    {
        modemparticle.Play();
        yield return new WaitForSeconds(1f);
        CameraAction_11.Instance.MoveFirst();
        yield return new WaitForSeconds(1f);
        modemparticle.Stop();
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeESL());
        yield return new WaitForSeconds(1f);
        CameraAction_11.Instance.Move();
        yield break;

    }

    private IEnumerator ChangeESL()
    {
        ESL.ALLEsls.Sort((y, x) => x.transform.position.x.CompareTo(y.transform.position.x));
        foreach (var ESL in ESL.ALLEsls)
        {
            var price = ESL.PriceMaps.Find(x => x.Name.Equals(ESL.TextProductName.text, System.StringComparison.OrdinalIgnoreCase));
            StartCoroutine(ESL.ChangePriceText((price.Text).ToString()));
            yield return new WaitForSeconds(.3f);
        }
    }
}
