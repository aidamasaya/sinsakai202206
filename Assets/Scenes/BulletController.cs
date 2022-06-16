using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] GameObject m_effectPrefab = default;
    /// <summary>発射する速度</summary>
    [SerializeField] float m_initialSpeed = 5f;
    private object collision;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
    }
    void Update()
    {
        if (this.transform.position.y < -5f)
        {
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "enemy")
        {
            // エフェクトとなるプレハブが設定されていたら、それを生成する
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }
        }
        // 何かにぶつかったら自分自身を破棄する
        //Destroy(this.gameObject);
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
