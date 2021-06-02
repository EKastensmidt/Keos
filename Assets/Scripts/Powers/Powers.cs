using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powers : MonoBehaviour
{
    protected Elements firstComponent;
    protected Elements secondComponent;

    public Elements FirstComponent { get => firstComponent; set => firstComponent = value; }
    public Elements SecondComponent { get => secondComponent; set => secondComponent = value; }
    public Powers(Elements firstComponent, Elements secondComponent)
    {
        this.firstComponent = firstComponent;
        this.secondComponent = secondComponent;
    }
    public virtual void Execute()
    {

    }
    public bool Equals(Elements one , Elements two)
    {
        return ((one == firstComponent && two == secondComponent) || (one == secondComponent && two == firstComponent));
    }
}
