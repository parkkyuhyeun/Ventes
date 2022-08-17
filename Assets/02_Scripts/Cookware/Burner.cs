using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burner : Cookware
{
    public override void Cook(InteractionItem CookItem)
    {

    }

    public override IEnumerator Cooking()
    {
        yield return null;
    }
}
