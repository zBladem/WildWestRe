using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneByAnimation : MonoBehaviour
{
    [SerializeField]private string sceneName;

    public void Change()
    {
        SceneManager.LoadScene(sceneName);
    }

}
