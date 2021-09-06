using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objects != null)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
            }
        }
        Destroy(this.gameObject);
    }
}
