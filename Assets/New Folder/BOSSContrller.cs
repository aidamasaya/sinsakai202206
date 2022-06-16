using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSContrller : MonoBehaviour
{
    bool _right = true;
    // Start is called before the first frame update
    Rigidbody2D m_rb = default;
    [SerializeField] float _speed = 1f;
    [SerializeField] GameObject m_effectPrefab = default;
    [SerializeField] public GameObject m_bulletprefab;
    [SerializeField] public int enemyHP;
    // Start is called before the first frame update
    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        RLCheck();
        Move();
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            GameObject effect = Instantiate(m_bulletprefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);

            enemyHP -= 1;

            Destroy(collision.gameObject);

            if (enemyHP == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }
    void RLCheck()
    {
        if (transform.position.x < 0)
        {
            _right = true;
        }
        else
        {
            _right = false;
        }
    }
    private void Move()
    {
        if (_right)
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

