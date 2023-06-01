using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScoreSaveData
{
    public int PlayerWonAmount;
    public int PlayerLooseAmount;

    public PlayerScoreSaveData()
    {
        PlayerWonAmount = 0;
        PlayerLooseAmount = 0;
    }
}
