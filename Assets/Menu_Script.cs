using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
  public void OnMenuClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
