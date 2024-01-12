using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour
{
    
    public void Start()
    {
       
    }
    public void Play()
    {
       
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

