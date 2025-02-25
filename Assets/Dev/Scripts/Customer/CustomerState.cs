using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerState:MonoBehaviour
{
    public Customer Customer { get; private set; }

    private void Awake()
    {
       TryGetComponent(out Customer customer);
        Customer = customer;
    }

    public abstract IEnumerator StateProgression();
}
