using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterController : MonoBehaviour
{
    [SerializeField] GameObject m_effectPrefab = default;
    bool _left = true;
    Rigidbody2D m_rb = default;
    [SerializeField] float _speed = 1f;
    [SerializeField] GameObject _bulletPrefab = default;//���˂��鉊�̃v���n�u
    [SerializeField] GameObject _barrel = default; // ���ˌ�
    [SerializeField] float _shootInterval = 4f; // ���ˊԊu
    [SerializeField] int angle;
    Transform _barrelTransform = default; //�o�����̈ʒu
    bool _right = true;
    float _time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        LRcheck();
        if (_right == true)
        {
            _barrel.transform.eulerAngles = new Vector3(0, 0, -angle);
        }
        else
        {
            _barrel.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
    void Shoot()//�e����������
    {
        _barrelTransform = _barrel.transform;
        _time += Time.deltaTime;
        if (_time >= _shootInterval)
        {
            _time = 0;
            Instantiate(_bulletPrefab, _barrelTransform.position, _barrel.transform.rotation);
        }
    }
    void LRcheck()
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "Player")
        {
            // �G�t�F�N�g�ƂȂ�v���n�u���ݒ肳��Ă�����A����𐶐�����
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }

            // �������g��j������
            Destroy(this.gameObject);
        }
    }
}