using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour

{
    [SerializeField]private string sceneName;

    private void Start()
    {
        
    
        GetComponent<Button>().onClick.AddListener(() =>

       SceneManager.LoadScene(sceneName));
    }
}


