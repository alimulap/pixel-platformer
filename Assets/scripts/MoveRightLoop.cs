// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class MoveRightLoop : MonoBehaviour
{
    public float length;
    float traveled = 0;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_length = Vector3.right * Time.deltaTime;
        this.traveled += move_length.x;

        this.transform.position += move_length;

        if (traveled >= length)
        {
            this.transform.position += Vector3.left * this.traveled;
            this.traveled = 0;
        }
    }
}
