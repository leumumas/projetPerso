using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class CharacterControlSize : MonoBehaviour
{
    [Serializable]
    private struct sizeInfo
    {
        public float scaleFactor;
        public float mass;
    }
    enum size
    {
        small,
        normal,
        large,
    }
    [SerializeField]
    private sizeInfo sizeSmall;
    [SerializeField]
    private sizeInfo sizeNormal;
    [SerializeField]
    private sizeInfo sizeLarge;

    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private Rigidbody myRigidbody;

    private size currentSize = size.normal;


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
        switch (other.tag)
        {
            case "Smaller":
                currentSize = currentSize == size.large ? size.normal : size.small;
                break;
            case "GrownUp":
                currentSize = currentSize == size.small ? size.normal : size.large;
                break;
        }
        UpdateSize();
    }

    public void ResetSize(InputAction.CallbackContext context)
    {
        currentSize = size.normal;
        UpdateSize();
    }

    private void UpdateSize()
    {
        switch (currentSize) 
        {
            case size.small:
                myTransform.localScale = Vector3.one * sizeSmall.scaleFactor;
                myRigidbody.mass = sizeSmall.mass;
                break;
            case size.normal:
                myTransform.localScale = Vector3.one * sizeNormal.scaleFactor;
                myRigidbody.mass = sizeNormal.mass;
                break;
            case size.large:
                myTransform.localScale = Vector3.one * sizeLarge.scaleFactor;
                myRigidbody.mass = sizeLarge.mass;
                break;
        }
    }
}
