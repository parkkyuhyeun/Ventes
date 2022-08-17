using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cookware : MonoBehaviour
{
    public bool onItem= false;
    public float cookTime;
    public List<GameObject> cookedItem = new List<GameObject>();
    public abstract void Cook();
}
