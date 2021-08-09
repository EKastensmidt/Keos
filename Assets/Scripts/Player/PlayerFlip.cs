using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    private PlayerController _pc;
    void Start()
    {
        _pc = parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = parent.transform.localScale;

        if (_pc.Delta.x >_pc.Movement)
        {
            characterScale.x = 1;
            _pc.IsFacingRight = true;
        }
        if (_pc.Delta.x < _pc.Movement)
        {
            characterScale.x = -1;
            _pc.IsFacingRight = false;
        }
        _pc.transform.localScale = characterScale;
    }
}
