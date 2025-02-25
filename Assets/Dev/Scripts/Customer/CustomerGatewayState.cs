using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CustomerGatewayState : CustomerState
{
    public ParticleSystem ModemLed;
    public ParticleSystem ModemWave;
    public GameObject EffectParticle;

    public override IEnumerator StateProgression()
    {
        ESL.ALLEsls.ForEach(async x => 
        {
            if (Random.Range(0, 10) > 5)
            {
                x.ShowLed();
            }
            await Task.Delay(Random.Range(1000, 2500));
        });
        ModemLed.Play();
        yield return CameraAction_3.Instance.FirstMove();
        yield return new WaitForSeconds(4f);
        yield return CameraAction_3.Instance.SecondMove();
        ModemWave.Play();
        //foreach (var item in ESL.ALLEsls)
        //{
        //    Transform lb = item.transform;
        //    if (Random.Range(0, 10) > 5)
        //    {
        //        GameObject created = Instantiate(EffectParticle);
        //        created.gameObject.SetActive(true);
        //        created.transform.position = ModemLed.transform.position;
        //        created.transform.DOMove(item.transform.position, Random.Range(.5f, 1.5f)).SetEase(Ease.Linear).OnComplete(() =>
        //        {
        //            Destroy(created.gameObject);
        //        });
        //        yield return new WaitForSeconds(Random.Range(.15f, .3f));
        //    }
        //}
       
        yield break;
    }
}
