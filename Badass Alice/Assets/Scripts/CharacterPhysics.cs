using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPhysics : MonoBehaviour
{
    public void Move(Vector2 moveAmount)
    {
        transform.Translate(moveAmount);
    }
}
