using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Exp>(out Exp exp))
        {
            exp.magnetTime = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Exp>(out Exp exp))
        {
            exp.magnetTime = false;
        }
    }
}
