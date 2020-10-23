using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlSize : MonoBehaviour
{

    Transform myTransform;
    public float sizeSmaller;
    public float sizeHighest;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Smaller")
        {
            Debug.Log ("Smaller, bitch!");
            myTransform.localScale += new Vector3( sizeSmaller, 0, sizeSmaller);
        }
    }
}
