using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamCloud : Powers
{
    private GameObject prefab;
    private float cd = 0.2f;

    public SteamCloud() : base(Elements.fire, Elements.water,"Steam Cloud")
    {
        cooldownTime = cd;
        prefab = Resources.Load("SteamCloud") as GameObject;
    }

    public override void Execute()
    {
        GameObject projectile = Instantiate(prefab , Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
