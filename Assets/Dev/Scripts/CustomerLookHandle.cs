using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLookHandle : MonoBehaviour
{
    public static CustomerLookHandle Instance;

    public Vector3 rotate1;
    public Vector3 rotate2;
    private Vector3 First;
    public Transform Box;

    private void Awake()
    {
        First = transform.rotation.eulerAngles;
        Instance = this;
    }

    private void Start()
    {
        var squance = DOTween.Sequence()
             .Append(transform.DORotate(rotate1, 1.2f).SetEase(Ease.Linear))
             .Append(transform.DORotate(First, 1.2f).SetEase(Ease.Linear))
             .Append(transform.DORotate(rotate2, 1.2f).SetEase(Ease.Linear))
             .SetLoops(-1,LoopType.Yoyo);
    }


    private void Update()
    {
        if (Customer.Instance)
        {
            transform.position = Customer.Instance.transform.position;
        }
    }

}
