using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode
{
    public bool IsScienceSkin { get; private set; }
    public bool IsBorder { get; private set; }


    public static GameMode Init(bool isScienceSkin, bool isBorder)
    {
        GameMode gm = new GameMode();
        gm.IsScienceSkin = isScienceSkin;
        gm.IsBorder = isBorder;
        return gm;
    }

}
