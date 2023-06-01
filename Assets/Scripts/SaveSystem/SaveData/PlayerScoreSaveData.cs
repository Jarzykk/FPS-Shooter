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
