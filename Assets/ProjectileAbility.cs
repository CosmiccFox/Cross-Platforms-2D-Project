using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability
{

    public GameObject projectile;
    public Transform spawnPt;
    public List<GameObject> powerUps = new List<GameObject>();


    public override void OnCollect()
    {
        base.OnCollect();
        powerUps[0].SetActive(true);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //powerUps[0].SetActive(true);

        for (int i = 1; i < powerUps.Count; i++)
        {
            powerUps[i].SetActive(false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnProjectile = Instantiate(projectile, spawnPt.transform.position, Quaternion.identity);
            spawnProjectile.transform.rotation = transform.rotation;
            spawnProjectile.GetComponent<Projectile>().GiveInitVelocity();
        }
    }

    public override void OnFinish()
    {
        powerUps[0].SetActive(false);
        base.OnFinish();
    }


}
