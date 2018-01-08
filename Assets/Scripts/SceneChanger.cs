using UnityEngine.SceneManagement;

public class SceneChanger 
{
    public static void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }

    public static void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
}
