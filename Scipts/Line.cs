using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        float moveStep = moveSpeed * xDirection * Time.deltaTime;
        if ((transform.position.x <= -6 && xDirection < 0) || transform.position.x >= 6 && xDirection > 0)
            return;
        transform.position = transform.position + new Vector3(moveStep,0,0);
    }
    public void Replay()
    {
        transform.position = new Vector3(-0.22f, -2.44f, 0);
    }
}
