using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EarthMinion : Powers
{
    private GameObject prefab;
    private List<Sprite> _minionSprites;
    private GameObject minion = null;
    private float spawnRate = 1.5f;

    public EarthMinion(List<Sprite> minionSprites) : base(Elements.earth, Elements.earth,"Earth Minion")
    {
        cooldownTime = spawnRate;
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
        Collider2D hit = Physics2D.OverlapCircle(pos, 0.05f);
        if (hit == null || hit.name != "Tilemap")
        {
            SoundManagerScript.PlaySound("EarthMinion");
            minion = Instantiate(prefab, pos, Quaternion.identity);
            minion.transform.position = new Vector3(minion.transform.position.x, minion.transform.position.y, 0);

            GameManager.isEarthMinionActive = true;
            Instantiate(Resources.Load("Particles/EarthMinionSpawn") as GameObject, minion.transform.position, Quaternion.identity);

            SpriteRenderer spriteRenderer = minion.GetComponent<SpriteRenderer>();
            int randSprite = Random.Range(0, _minionSprites.Count);
            spriteRenderer.sprite = _minionSprites[randSprite];
        }
    }
}
