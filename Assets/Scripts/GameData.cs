using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public GameMode GameMode { get; set; }
    public int LastLength { get; set; }
    public int LastScore { get; set; }
    public int BestLength { get; set; }
    public int BestScore { get; set; }

    public static GameData Init()
    {
        GameData gd = new GameData();
        gd.GameMode = GameMode.Init(true, true);
        return gd;
    }
}
