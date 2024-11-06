// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class FollowTargetExact : MonoBehaviour
{
    public Rigidbody2D target;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        var target_pos = this.target.position;
        var this_pos = this.transform.position;
        this.transform.position = new Vector3(target_pos.x, target_pos.y, this_pos.z);
    }
}
