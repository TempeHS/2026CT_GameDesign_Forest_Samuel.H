using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
  public void OnMenuClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
