public class GameDataManager
{
    public static void UpdateData(GameMode gameMode, int length, int score)
    {
        GameData gameData = GetData();
        if (gameData == null)
        {
            gameData = GameData.Init();
        }
        gameData.GameMode = gameMode;

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
