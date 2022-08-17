using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : Cookware
{
    public override void Cook(InteractionItem CookItem)
    {

    }

    public override IEnumerator Cooking()
    {
        yield return null;
    }
}
