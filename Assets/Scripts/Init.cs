using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
