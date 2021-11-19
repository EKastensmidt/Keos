using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powers : MonoBehaviour
{
    protected Elements firstComponent;
    protected Elements secondComponent;
    private string name;
    protected float cooldownTime = 0;
    private bool isCooldown = false;
    public Elements FirstComponent { get => firstComponent; set => firstComponent = value; }
    public Elements SecondComponent { get => secondComponent; set => secondComponent = value; }
    public string Name { get => name; set => name = value; }
    public float CooldownTime { get => cooldownTime; set => cooldownTime = value; }
    public bool IsCooldown { get => isCooldown; set => isCooldown = value; }

    public Powers(Elements firstComponent, Elements secondComponent, string name)
    {
        this.firstComponent = firstComponent;
        this.secondComponent = secondComponent;
        this.name = name;
    }
    public virtual void Execute()
    {

    }
    public bool Equals(Elements one , Elements two)
    {
        return ((one == firstComponent && two == secondComponent) || (one == secondComponent && two == firstComponent));
    }

    public IEnumerator StartCD()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
