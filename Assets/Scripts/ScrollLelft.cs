using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLelft : MonoBehaviour
{
    public float speedMoveLeft = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speedMoveLeft);
    }
}
