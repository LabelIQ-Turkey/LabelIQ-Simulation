using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayScreen : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    public Transform TickIcon;

    public void FistStep()
    {
        Panel1.gameObject.SetActive(false);
        Panel2.gameObject.SetActive(true);
    }

    public void SecondStep()
    {
        Panel2.gameObject.SetActive(false);
        Panel3.gameObject.SetActive(true);
        TickIcon.DOPunchScale(Vector3.one * 1.2f, .5f);
    }

    

}
