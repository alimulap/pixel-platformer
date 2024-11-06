// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonToScene : MonoBehaviour
{
    Button button;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        this.button = this.GetComponent<Button>();
        this.button.onClick.AddListener(
            delegate()
            {
                SceneManager.LoadScene(this.scene);
            }
        );
    }

    // Update is called once per frame
    void Update() { }
}
