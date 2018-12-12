using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpAbility : Ability {

    public List<GameObject> powerUps = new List<GameObject>();

    public override void OnCollect()
    {
        powerUps[0].SetActive(true);

        for (int i = 1; i < powerUps.Count; i++)
        {
            powerUps[i].SetActive(false);
        }

        base.OnCollect();
        GetComponent<CharacterControl>().maxJumps = 2;
    }

    public override void OnFinish()
    {
        powerUps[0].SetActive(false);
        base.OnFinish();
        GetComponent<CharacterControl>().maxJumps = 1;
    }
}
