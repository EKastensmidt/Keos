using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudLine : Powers
{
    private GameObject prefab;
    public MudLine() : base(Elements.earth, Elements.water, "Mud Line")
    {
        prefab = Resources.Load("MudLine") as GameObject;
        cooldownTime = 2f;
    }
    public override void Execute()
    {
        GameObject projectile = Instantiate(prefab); 
    }
}
