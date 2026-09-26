using UnityEngine;
using UnityEngine.SceneManagement;

public class scri2 : MonoBehaviour
{
    public string nomescena;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomescena);
        }
    }
}
