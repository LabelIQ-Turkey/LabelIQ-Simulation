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
                     Name="Tuz",
                     Text=5.99f,
                },
                 new PriceMap
                {
                     Name="Kek",
                     Text=10.25f,
                }, new PriceMap
                {
                     Name="Cips",
                     Text=30.00f,
                }, new PriceMap
                {
                     Name="Makarna",
                     Text=17.99f,
                }, new PriceMap
                {
                     Name="Tohum",
                     Text=25.99f,
                },
                 new PriceMap
                {
                     Name="Zeytinyagi",
                     Text=110.99f,
                }, new PriceMap
                {
                     Name="Yag",
                     Text=79.99f,
                }, new PriceMap
                {
                     Name="Barbunya",
                     Text=16.99f,
                }, new PriceMap
                {
                     Name="Pirinç",
                     Text=36.45f,
                }, new PriceMap
                {
                     Name="Bezelye",
                     Text=24.99f,
                }, new PriceMap
                {
                     Name="Balik",
                     Text=30.99f,
                }, new PriceMap
                {
                     Name="P. Püresi",
                     Text=15.10f,
                }, new PriceMap
                {
                     Name="Kahve",
                     Text=45.00f,
                },new PriceMap
                {
                     Name="Un",
                     Text=65.99f,
                }, new PriceMap
                {
                     Name="Biber",
                     Text=19.99f,
                }, new PriceMap
                {
                     Name="Ketçap",
                     Text=14.65f,
                }, new PriceMap
                {
                     Name="P. Sekeri",
                     Text=39.99f,
                }, new PriceMap
                {
                     Name="E. Seker",
                     Text=26.99f,
                }, new PriceMap
                {
                     Name="Gevrek",
                     Text=9.99f,
                },new PriceMap
                {
                     Name="Kurabiye",
                     Text=21.00f,
                },new PriceMap
                {
                     Name="F. Ezmesi",
                     Text=70.99f,
                },new PriceMap
                {
                     Name="Bal",
                     Text=95.50f,
                },new PriceMap
                {
                     Name="Çikolata",
                     Text=17.59f,
                },new PriceMap
                {
                     Name="Yumurta",
                     Text=85.99f,
                },
                new PriceMap
                {
                     Name="Meyve Suyu",
                     Text=15.25f,
                },
                new PriceMap
                {
                     Name="Su",
                     Text=12.50f,
                },new PriceMap
                {
                     Name="Ekmek",
                     Text=12.50f,
                },new PriceMap
                {
                     Name="K. Mamasi",
                     Text=195.00f,
                },new PriceMap
                {
                     Name="Kedi Mama",
                     Text=69.99f,
                },new PriceMap
                {
                     Name="Çamaşır Suyu",
                     Text=49.99f,
                },new PriceMap
                {
                     Name="Biber",
                     Text=15.99f,
                },new PriceMap
                {
                     Name="Viski",
                     Text=800.00f,
                },new PriceMap
                {
                     Name="Vodka",
                     Text=560.50f,
                },new PriceMap
                {
                     Name="Rom",
                     Text=760.00f,
                },new PriceMap
                {
                     Name="Bira",
                     Text=95.00f,
                },new PriceMap
                {
                     Name="Gazoz",
                     Text=14.99f,
                },new PriceMap
                {
                     Name="Kola",
                     Text=27.99f,
                },
                new PriceMap
                {
                     Name="Soda",
                     Text=55.50f,
                },new PriceMap
                {
                     Name="Meyve Suyu",
                     Text=85.99f,
                },new PriceMap
                {
                     Name="Mango",
                     Text=115.00f,
                },new PriceMap
                {
                     Name="Ananas",
                     Text=76.25f,
                },new PriceMap
                {
                     Name="Karpuz",
                     Text=45.00f,
                },new PriceMap
                {
                     Name="Pattaya",
                     Text=77.50f,
                },
                new PriceMap
                {
                     Name="Kivi",
                     Text=26.99f,
                },new PriceMap
                {
                     Name="Elma",
                     Text=35.99f,
                },new PriceMap
                {
                     Name="Armut",
                     Text=30.00f,
                },new PriceMap
                {
                     Name="Muz",
                     Text=125.59f,
                },new PriceMap
                {
                     Name="Limon",
                     Text=50.00f,
                },
                new PriceMap
                {
                     Name="Patates",
                     Text=40.00f,
                },new PriceMap
                {
                     Name="Sarımsak",
                     Text=145.50f,
                },new PriceMap
                {
                     Name="Kabak",
                     Text=26.99f,
                },new PriceMap
                {
                     Name="Portakal",
                     Text=52.00f,
                },
                new PriceMap
                {
                     Name="Seker",
                     Text=52.00f,
                },new PriceMap
                {
                     Name="Sabun",
                     Text=32.50f,
                },
                new PriceMap
                {
                     Name="Zeytinyağı",
                     Text=140.50f,
                },
               

            };
        }

        TextProductPrice.text = PriceMaps.Find(x => string.Equals(x.Name, TextProductName.text, System.StringComparison.OrdinalIgnoreCase))
            .Text.ToString("0.00");

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
            // DoTween ile alpha de�erini de�i�tir
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
