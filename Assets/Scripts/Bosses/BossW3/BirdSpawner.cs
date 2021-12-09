using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject birdPrefab , target;
    [SerializeField] private float spawnCd;

    private float auxSpawnCd;

    private void Start()
    {
        auxSpawnCd = spawnCd;
        spawnCd = 0.3f;
    }
    private void Update()
    {
        spawnCd -= Time.deltaTime;
        if (spawnCd < 0)
        {
            Instantiate(birdPrefab, new Vector3(transform.position.x, target.transform.position.y + 0.5f, target.transform.position.z), Quaternion.identity);
            spawnCd = auxSpawnCd;
        }
    }
}
