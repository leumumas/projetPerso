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
        gameObject.tag = "Player";
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Smaller")
        {
            Debug.Log ("Smaller, bitch!");
            myTransform.localScale += new Vector3(sizeSmaller, sizeSmaller, 0);
        }
        if (other.tag == "GrownUp")
        {
            Debug.Log("Grown Up, Bitch!");
            myTransform.localScale += new Vector3(sizeHighest, sizeHighest, 0);
        }
    }
}
