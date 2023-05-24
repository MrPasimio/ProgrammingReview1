using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Pickup
{
    public int pointsValue = 10;

    public override void Activate()
    {
        ScoreManager.Instance.AddScore(pointsValue);
    }
}
