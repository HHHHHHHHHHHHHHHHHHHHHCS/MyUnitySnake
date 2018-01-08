using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode
{
    public bool IsBorder { get; private set; }
    public bool IsYellowSkin { get; private set; }

    public GameMode Init(bool isBorder, bool isYellowSkin)
    {
        IsBorder = isBorder;
        IsYellowSkin = isYellowSkin;
        return this;
    }

}
