using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraAction : MonoBehaviour
{
    public string Key;
    public abstract IEnumerator CameraMove();
}
