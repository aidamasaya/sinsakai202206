using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�J�n");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");  // h �� Horizontal�i�����j�� h
        float v = Input.GetAxisRaw("Vertical");    // v �� Vertical�i�����j�� v

        if (h != 0 || v != 0)
        {
            Debug.Log("x: " + h.ToString() + ", y: " + v.ToString());
        }

        // �W�����v�{�^�������o����

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }

        // T �L�[�����o����

        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("T��������Ă���");
        }

        // �}�E�X�{�^�������o����

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("���N���b�N�������ꂽ");
        }
        if (Input.GetButtonDown("space"))
        {
            Debug.Log("space");
        }
    }
}
