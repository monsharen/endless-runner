using UnityEngine.SceneManagement;

namespace Util
{

    public class Scenes
    {

        public static void ChangeScene(SceneId sceneId)
        {
            SceneManager.LoadScene(sceneId.ToString(), LoadSceneMode.Single);
        }
    }
    
    public enum SceneId
    {
        Leaderboard,
        Level
    }
    
}