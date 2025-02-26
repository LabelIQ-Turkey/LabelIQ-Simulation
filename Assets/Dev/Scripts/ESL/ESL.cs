using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ESL : MonoBehaviour
{
    public static Texture WhiteTexture;
    public static List<ESL> ALLEsls;
    public static List<PriceMap> PriceMaps;

    public MeshRenderer ScreenBack;
    public MeshRenderer Screen;
    public GameObject LedMain;
    public ParticleSystem LedParticle;
    public MeshRenderer LedMeshRenderer;
    public TextMeshPro TextProductName;
    public TextMeshPro TextProductPrice;

    private void Awake()
    {
        ALLEsls ??= new List<ESL>();
        ALLEsls.Add(this);

        if (PriceMaps == null)
        {
            PriceMaps = new List<PriceMap>
            {
                new PriceMap
                {
                     Name="Penne",
                     Text=20.99f,
                },
                 new PriceMap
                {
                     Name="Patates Püresi",
                     Text=17.99f,
                },
                  new PriceMap
                {
                     Name="Konserve",
                     Text=39.99f,
                },
                 new PriceMap
                {
                     Name="Pirinç",
                     Text=26.50f,
                },
                  new PriceMap
                {
                     Name="Makarna",
                     Text=43.99f,
                },
                   new PriceMap
                {
                     Name="Spagetti",
                     Text=35.50f,
                },
                    new PriceMap
                {
                     Name="Yumurta",
                     Text=10.99f,
                },
                     new PriceMap
                {
                     Name="Un",
                     Text=27.99f,
                },
                      new PriceMap
                {
                     Name="Soslar",
                     Text=15.99f,
                },
                       new PriceMap
                {
                     Name="Pirinç",
                     Text=26.10f,
                },
                        new PriceMap
                {
                     Name="Panzati",
                     Text=60.99f,
                },
                         new PriceMap
                {
                     Name="Puray",
                     Text=74.99f,
                },
                          new PriceMap
                {
                     Name="Mango",
                     Text=57.99f,
                },
                           new PriceMap
                {
                     Name="Basmatý",
                     Text=37.99f,
                },
                            new PriceMap
                {
                     Name="Elbows",
                     Text=26.50f,
                },
                             new PriceMap
                {
                     Name="Marshmallow",
                     Text=55.50f,
                },

            };
        }

        TextProductPrice.text = PriceMaps.Find(x => string.Equals(x.Name, TextProductName.text, System.StringComparison.OrdinalIgnoreCase))
            .Text.ToString();

        WhiteTexture = CreateWhiteTexture(10, 10);
    }

    public void ShowLed()
    {
        LedParticle.Play();
    }
    public void HideLed()
    {
        LedParticle.Stop();
    }

    public IEnumerator ChangePriceText(string text)
    {
        TextProductName.gameObject.SetActive(false);
        TextProductPrice.gameObject.SetActive(false);

        Material material = Screen.material;

        // Mevcut rengi al
        Color currentColor = material.GetColor("_BaseColor");
        var texture = material.mainTexture;
        material.mainTexture = WhiteTexture;
        bool thresold = true;
        for (int i = 0; i < 20; i++)
        {
            // DoTween ile alpha deðerini deðiþtir
            DOTween.To(() => currentColor.a,
                       x => {
                           Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, x);
                           material.SetColor("_BaseColor", newColor);
                       },
                       thresold?0:1,
                       .2f)
                   .SetEase(Ease.InOutSine);
            thresold = !thresold;
            yield return new WaitForSeconds(.1f);
            if (thresold)
                yield return new WaitForSeconds(.05f);
        }
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        material.SetColor("_BaseColor", newColor);

        Color tempback = Screen.material.GetColor("_BaseColor");
        Color newColorwhite = new Color(currentColor.r, currentColor.g, currentColor.b, 1);
        ScreenBack.material.SetColor("_BaseColor", newColorwhite);

        material.mainTexture = texture;
        currentColor = material.GetColor("_BaseColor");
        DOTween.To(() => currentColor.a,
                      x => {
                          Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, x);
                          material.SetColor("_BaseColor", newColor);
                      },
                      1,
                      1.5f)
                  .SetEase(Ease.InOutSine);

        ScreenBack.material.SetColor("_BaseColor", tempback);
        TextProductPrice.text = text;
        TextProductName.gameObject.SetActive(true);
        TextProductPrice.gameObject.SetActive(true);

    }
    Texture2D CreateWhiteTexture(int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);

        Color whiteColor = Color.white;
        Color[] pixels = new Color[width * height];

        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = whiteColor;

        texture.SetPixels(pixels);
        texture.Apply();

        return texture;
    }


    public struct PriceMap
    {
        public string Name;
        public float Text;
    }
}
