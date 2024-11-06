using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideToScene : MonoBehaviour
{
    public string NextScene;

    void Start() { }

    void Update() { }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            SceneManager.LoadScene(this.NextScene);
        }
    }
}
