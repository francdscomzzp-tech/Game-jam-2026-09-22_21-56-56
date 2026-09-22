using UnityEngine;

using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnPlayPressed(){
        SceneManager.LoadScene("DemoScene");
    }
}
