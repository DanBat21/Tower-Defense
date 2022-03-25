using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTower : MonoBehaviour
{
    public Cell Selfcell;
   

    public void Confirm()
    {
        Selfcell.DestroyTower();
        Cancel();
    }

    public void Cancel()
    {
        Destroy(gameObject);
    }
}
