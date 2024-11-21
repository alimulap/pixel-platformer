using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    public Player player;
    public RectTransform rt;

    float maxWidth;

    void Start()
    {
        this.maxWidth = rt.sizeDelta.x;
        Debug.Log(this.maxWidth);
        this.player.OnHealthChanged += this.ChangePoint;
    }

    void Update() { }

    void ChangePoint(int health)
    {
        Debug.Log(health);
        var currHeight = this.rt.sizeDelta.y;
        var newWidth = ((float)health / 100f) * this.maxWidth;
        Debug.Log(newWidth);
        this.rt.sizeDelta = new Vector2(newWidth, currHeight);
    }
}
