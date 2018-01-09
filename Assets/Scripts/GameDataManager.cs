public class GameDataManager
{
    public static void UpdateData(int length, int score)
    {
        GameData gameData = GetData();
        if (gameData == null)
        {
            gameData = new GameData();
        }
        gameData.LastLength = length;
        gameData.LastScore = score;
        if (score > gameData.BestScore)
        {
            gameData.BestLength = length;
            gameData.BestScore = score;
        }
        JsonManager.Instance.UpdateData(gameData);
    }

    public static GameData GetData()
    {
        return JsonManager.Instance.GetGameData<GameData>();
    }
}
