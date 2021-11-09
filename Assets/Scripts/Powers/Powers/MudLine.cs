﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudLine : Powers
{
    private GameObject prefab;
    public MudLine() : base(Elements.earth, Elements.water, "SteamCloud")
    {
        prefab = Resources.Load("MudLine") as GameObject;
    }
    public override void Execute()
    {
        GameObject projectile = Instantiate(prefab); 
    }
}
