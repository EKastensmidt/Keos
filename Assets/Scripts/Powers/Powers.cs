using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powers : MonoBehaviour
{
    protected Elements firstComponent;
    protected Elements secondComponent;
    private string name;

    public Elements FirstComponent { get => firstComponent; set => firstComponent = value; }
    public Elements SecondComponent { get => secondComponent; set => secondComponent = value; }
    public string Name { get => name; set => name = value; }

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
}
