﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog
{
    public Sprite characterSprite;

    [TextArea(1,10)]
    public string[] sentences;
}
