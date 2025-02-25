using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public static Customer Instance;

    public CustomerMovementLogic CustomerMovementLogic;
    public CustomerAnimationLogic CustomerAnimationLogic;
    public CustomerState CustomerState;
    public List<BodyItemMap> BodyItems;

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        CustomerAnimationLogic.RegisterMovementLogic(CustomerMovementLogic);

        yield return new WaitForSeconds(.25f);
        StartCoroutine(CustomerState.StateProgression());

    }

    [System.Serializable]
    public struct BodyItemMap
    {
        public string key;
        public GameObject GameObject;
    }
}
