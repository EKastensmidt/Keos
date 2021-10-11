using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMinion : Powers
{
    private GameObject prefab;
    private List<Sprite> _minionSprites;
    private GameObject minion;

    public EarthMinion(List<Sprite> minionSprites) : base(Elements.earth, Elements.earth)
    {
        prefab = Resources.Load("EarthMinion") as GameObject;
        _minionSprites = minionSprites;
        
    }

    public override void Execute()
    {
        if (minion == null)
        {
            minion = Instantiate(prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
        else
        {
            Destroy(minion);
            minion = Instantiate(prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
        minion.transform.position = new Vector3(minion.transform.position.x, minion.transform.position.y, 0);

        SpriteRenderer spriteRenderer = minion.GetComponent<SpriteRenderer>();
        int randSprite = Random.Range(0, _minionSprites.Count);
        spriteRenderer.sprite = _minionSprites[randSprite];
    }
}
