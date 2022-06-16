using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRzerController : MonoBehaviour
{
    [SerializeField] int angle;
    bool _left = true;
    Rigidbody2D m_rb = default;
    [SerializeField] float _speed = 1f;
    [SerializeField] GameObject m_effectPrefab = default;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        RLCheck();
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // エフェクトとなるプレハブが設定されていたら、それを生成する
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }

            // 自分自身を破棄する
            Destroy(this.gameObject);
        }
    }
    void RLCheck()
    {
        if (transform.position.x < -5)
        {
            _left = true;
        }
        else
        {
            _left = false;
        }
    }
    private void Move()
    {
        if (_left)
        {
            m_rb.velocity = Vector2.right * _speed;
        }
        else
        {
            m_rb.velocity = Vector2.left * _speed;
        }
    }
    public void StopMove()
    {
        m_rb.velocity = Vector2.zero;
    }
}
