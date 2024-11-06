using UnityEngine;

public class Menu : MonoBehaviour
{
    CanvasGroup cg;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        this.cg = this.GetComponent<CanvasGroup>();

        this.active = false;
        this.cg.alpha = 0;
        this.cg.interactable = false;
        this.cg.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.Toggle();
        }
    }

    public void Toggle()
    {
        if (this.active)
        {
            this.cg.alpha = 0;
            this.cg.interactable = false;
            this.cg.blocksRaycasts = false;
        }
        else
        {
            this.cg.alpha = 1;
            this.cg.interactable = true;
            this.cg.blocksRaycasts = true;
        }
        this.active = !this.active;
    }
}
