using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour
{
    [SerializeField] GameObject m_effectPrefab = default;
    // [SerializeField] float m_movePower = 5f;
    [SerializeField] Transform m_muzzle = default;
    [SerializeField] GameObject m_bulletPrefab = default;
    //[SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    float m_h;
    float m_scaleX;
    public int minas = 1;
    int count;
    bool m_isGround;
    Vector3 m_initialPosition;
    [SerializeField] Transform m_crosshair;
    AudioSource m_audio = default;
    float m_timer;
    [SerializeField] float m_interval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        //m_rb = GetComponent<Rigidbody2D>();
        //m_sprite = GetComponent<SpriteRenderer>();
        //m_initialPosition = this.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        Vector2 dir = m_crosshair.position - transform.position;
        transform.up = dir;
        // m_h = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Fire1"))
        {
            if (m_timer > m_interval)
            {
                Debug.Log("作動");
                m_timer = 0;
                m_audio.Play();
                Instantiate(m_bulletPrefab, m_muzzle.position, this.transform.rotation);

            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
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
}


