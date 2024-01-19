using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    [SerializeField] float bottomY;

    [SerializeField] Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {

        this.transform.position = startingPos;
        
    }

    // Update is called once per frame
    void Update()
    {


        if(this.transform.position.y > bottomY)
        {

            this.transform.Translate(Vector3.down * Time.deltaTime);


        }

        
        
    }
}
