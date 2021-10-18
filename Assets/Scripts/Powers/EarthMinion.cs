using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EarthMinion : Powers
{
    private GameObject prefab;
    private List<Sprite> _minionSprites;
    private GameObject minion = null;

    public EarthMinion(List<Sprite> minionSprites) : base(Elements.earth, Elements.earth)
    {
        prefab = Resources.Load("EarthMinion") as GameObject;
        _minionSprites = minionSprites;
    }

    public override void Execute()
    {
        if (minion != null)
        {
            Destroy(minion);
        }

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, -Vector3.up);

        if (hit == false)
            return;

        if (hit.collider.gameObject.tag == "Ground" && hit.collider != null)
        {
            minion = Instantiate(prefab,(Vector3) hit.point + (Vector3.up / 2), Quaternion.identity);
            minion.transform.position = new Vector3(minion.transform.position.x, minion.transform.position.y, 0);
            SpriteRenderer spriteRenderer = minion.GetComponent<SpriteRenderer>();
            int randSprite = Random.Range(0, _minionSprites.Count);
            spriteRenderer.sprite = _minionSprites[randSprite];
        }
    }
}
