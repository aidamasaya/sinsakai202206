using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] GameObject m_effectPrefab = default;
    /// <summary>���˂��鑬�x</summary>
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
            // �G�t�F�N�g�ƂȂ�v���n�u���ݒ肳��Ă�����A����𐶐�����
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }
        }
        // �����ɂԂ������玩�����g��j������
        //Destroy(this.gameObject);
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
