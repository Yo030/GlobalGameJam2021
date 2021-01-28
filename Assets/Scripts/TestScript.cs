using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int MyNum;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My Num is: " + MyNum);
        Debug.Log("My Inverted Num is: " + ~MyNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
