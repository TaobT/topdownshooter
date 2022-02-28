using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleHitbox : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyItself", 0.1f);
    }


    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}
