using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elements { none, fire, water, wind, earth }

public class PowerManager : MonoBehaviour
{
    private Elements firstElement;
    private Elements secondElement;
    public Elements FirstElement { get => firstElement; }
    public Elements SecondElement { get => secondElement; }

    private List<Powers> powers = new List<Powers>();

    private GameObject elePosOne;
    private GameObject elePosTwo;

    private List<GameObject> elementBalls = new List<GameObject>();
    private GameObject ele;
    private GameObject eleAux = null;
    [SerializeField] private List<Sprite> earthMinionSprites;

    private void Start()
    {
        elePosOne = GameObject.Find("ElementOne");
        elePosTwo = GameObject.Find("ElementTwo");
        elementBalls.Add(Resources.Load("ElementBalls/ElementBallFire") as GameObject);
        elementBalls.Add(Resources.Load("ElementBalls/ElementBallWind") as GameObject);
        elementBalls.Add(Resources.Load("ElementBalls/ElementBallWater") as GameObject);
        elementBalls.Add(Resources.Load("ElementBalls/ElementBallEarth") as GameObject);

        GameObject Emmiter = GameObject.Find("Emmiter");
        
        powers.Add(new FlameThrower(Emmiter.transform));
        powers.Add(new FireBall(Emmiter.transform));
        powers.Add(new WindDash());
        powers.Add(new SnowBall(Emmiter.transform));
        powers.Add(new SteamCloud());
        powers.Add(new Bubble());
        powers.Add(new RockBall(Emmiter.transform));
        powers.Add(new EarthMinion(earthMinionSprites));
        powers.Add(new MudThrower(Emmiter.transform));
        powers.Add(new VolcanicJump());
    }

    public void GetElement(Elements element)
    {
        if (element != Elements.none)
        {
            if (firstElement != Elements.none)
            {
                secondElement = firstElement;
            }
            firstElement = element;
            UpdateElemetBalls(element);
            SoundManagerScript.PlaySound("ElementSelect");
        }
    }

    public void CombineElements()
    {
        if (powers == null)
        {
            return;
        }

        foreach (var power in powers)
        {
            if (power.Equals(firstElement,secondElement))
            {
                power.Execute();
                break;
            }
        }
    }
    public void UpdateElemetBalls(Elements element)
    {
        if (elementBalls != null)
        {
            if (eleAux != null)
            {
                Destroy(eleAux.gameObject);
            }

            switch (element)
            {
                case Elements.fire:
                    if (ele != null)
                    {
                        ele.transform.position = elePosTwo.transform.position;
                        eleAux = ele;
                    }
                    ele = Instantiate(elementBalls[0], elePosOne.transform);
                    break;
                case Elements.wind:
                    if (ele != null)
                    {
                        ele.transform.position = elePosTwo.transform.position;
                        eleAux = ele;
                    }
                    ele = Instantiate(elementBalls[1], elePosOne.transform);
                    break;
                case Elements.water:
                    if (ele != null)
                    {
                        ele.transform.position = elePosTwo.transform.position;
                        eleAux = ele;
                    }
                    ele = Instantiate(elementBalls[2], elePosOne.transform);
                    break;
                case Elements.earth:
                    if (ele != null)
                    {
                        ele.transform.position = elePosTwo.transform.position;
                        eleAux = ele;
                    }
                    ele = Instantiate(elementBalls[3], elePosOne.transform);
                    break;
            }
        }
    }

    //private void AddEarthMinionSprites()
    //{
    //    earthMinionSprites.Add(Resources.Load("EarthMinionSprites/EarthMinion") as Sprite);
    //    earthMinionSprites.Add(Resources.Load("EarthMinionSprites/EarthMinionCool") as Sprite);
    //    earthMinionSprites.Add(Resources.Load("EarthMinionSprites/EarthMinionHappy") as Sprite);
    //    earthMinionSprites.Add(Resources.Load("EarthMinionSprites/EarthMinionSad") as Sprite);
    //    earthMinionSprites.Add(Resources.Load("EarthMinionSprites/EarthMinionSadistic") as Sprite);
    //}
}
