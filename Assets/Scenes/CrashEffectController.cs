using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEffectController : MonoBehaviour
{
    [SerializeField] float m_lifetime = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, m_lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
