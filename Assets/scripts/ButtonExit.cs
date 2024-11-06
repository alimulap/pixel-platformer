// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExit : MonoBehaviour
{
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        this.button = this.GetComponent<Button>();
        this.button.onClick.AddListener(
            delegate()
            {
                Application.Quit();
            }
        );
    }

    // Update is called once per frame
    void Update() { }
}
