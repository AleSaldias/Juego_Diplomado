using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
        private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
  public void LoadNextScene()
  {
    int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    //cargar la siguiente escena
    UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
  }
  public void LoadfirstScene()
  {
    //cargar primera escena
    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
  }
  public void LoadScene(int sceneIndex)
  {
    //cargar escena desde un indice
    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
  }
  //funcion cerrar el juego 
  public void QuitGame()
  {
    //salir del juego
    Application.Quit();
  }
}
