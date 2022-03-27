using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOldListPrefab : MonoBehaviour
{
    void OnDisable() 
    {
        Destroy(this.gameObject);
    }
}
