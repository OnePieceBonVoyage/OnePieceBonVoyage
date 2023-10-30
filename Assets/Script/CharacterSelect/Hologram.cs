using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour
{
    public void Start() { }
    public void Update() { }

    private bool IsFacingRight = true;
    public void FaceRight()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= IsFacingRight ? 1 : -1;

        transform.localScale = newScale;
        IsFacingRight = true;
    }
    public void FaceLeft()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= IsFacingRight ? -1 : 1;

        transform.localScale = newScale;
        IsFacingRight = false;
    }
}
