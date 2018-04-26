using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFunctions : MonoBehaviour
{
    static public GameObject GetObjectByClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero);
            return hit.collider ? hit.transform.gameObject : null;
        }
        return null;
    }
}
