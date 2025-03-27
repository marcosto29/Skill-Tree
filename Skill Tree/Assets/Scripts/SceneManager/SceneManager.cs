using UnityEngine.SceneManagement;

public static class SceneManager
{
    public static void ChangeScene(string newScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(newScene);
    }
}
