using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Sahne_3_State : CustomerState
{
    public ParticleSystem GatewayParticle;

    public override IEnumerator StateProgression()
    {
        CameraAction_9.Instance.FirstMove();
        yield return new WaitForSeconds(6f);
        CameraAction_9.Instance.LookGateway();
        yield return new WaitForSeconds(1.9f);
        GatewayParticle.Play();
        yield break;

    }
}
