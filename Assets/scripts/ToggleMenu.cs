using UnityEngine;
using UnityEngine.UI;

public class ToggleMenu : MonoBehaviour
{
    public Menu menu;
    Button button;

    void Start()
    {
        this.button = this.GetComponent<Button>();

        this.button.onClick.AddListener(
            delegate()
            {
                this.menu.Toggle();
            }
        );
    }

    void Update() { }
}
