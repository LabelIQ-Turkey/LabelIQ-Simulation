using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Sahne_4_State : CustomerState
{
    public ParticleSystem SadEmogy;
    public GameObject SmokeParticle;
    public MeshRenderer ProductXMeshRenderer;
    public List<GameObject> ProductA;
    public List<GameObject> ProductB;

    public ESL ESL;

    public override IEnumerator StateProgression()
    {
        CameraAction_10.Instance.Move();
        yield return new WaitForSeconds(4f);

        bool thresold = false;
        for (int i = 0; i < 8; i++)
        {
            
            thresold = !thresold;
            int indexa = Random.Range(0, ProductA.Count);
            int indexb = Random.Range(0, ProductB.Count);
            ProductA[indexa].SetActive(false);
            ProductB[indexb].SetActive(false);
            var particlex = Instantiate(SmokeParticle, ProductA[indexa].transform.position, SmokeParticle.transform.rotation)
                .GetComponent<ParticleSystem>();
            particlex.Play();
            var particley=Instantiate(SmokeParticle, ProductB[indexb].transform.position, SmokeParticle.transform.rotation)
                .GetComponent<ParticleSystem>();
            particley.Play();

            ProductA.RemoveAt(indexa);
            ProductB.RemoveAt(indexb);

            if (i>2&&i%2==0)
            {
                ProductXMeshRenderer.transform.DOPunchScale(Vector3.one * .95f, .15f);
                SadEmogy.Play();
            }
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(.5f);
        CameraAction_10.Instance.Move2();
        yield return new WaitForSeconds(4f);
        CameraAction_10.Instance.Move3();
        yield return new WaitForSeconds(2.5f);
        var price = ESL.PriceMaps.Find(x => x.Name.Equals(ESL.TextProductName.text, System.StringComparison.OrdinalIgnoreCase));
        StartCoroutine(ESL.ChangePriceText((price.Text-4).ToString()));

        yield break;

    }
}
