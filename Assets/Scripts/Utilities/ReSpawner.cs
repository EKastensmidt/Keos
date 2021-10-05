using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    private List<Vector3> objectsTransforms = new List<Vector3>();
    void Start()
    {
        if (objects != null)
        {
            foreach (GameObject obj in objects)
            {
                objectsTransforms.Add(obj.transform.position);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectsTransforms == null)
            return;

        if (collision.gameObject.name == "Maguito")
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].transform.position = objectsTransforms[i];
            }
        }
    }
}
