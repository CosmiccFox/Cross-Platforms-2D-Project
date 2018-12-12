using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAbility : Ability
{

    public List<GameObject> powerUps = new List<GameObject>();

    public override void OnCollect()
    {
        powerUps[0].SetActive(true);

        for (int i = 1; i < powerUps.Count; i++)
        {
            powerUps[i].SetActive(false);
        }

        base.OnCollect();        
        GetComponent<CharacterControl>().playerSpeed = 10;
    }

    public override void OnFinish()
    {
        powerUps[0].SetActive(false);
        base.OnFinish();
        GetComponent<CharacterControl>().playerSpeed = 5.5f;
    }
}
