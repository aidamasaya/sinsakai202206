using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] float m_interval = 1f;
    float _time = 0;
    int _count = 0;
    /// <summary>��莞�Ԃ����ɐ������� GameObject �̌��ƂȂ�v���n�u</summary>
    [SerializeField] GameObject m_prefab = default;

    /// <summary>true �̏ꍇ�A�J�n���ɂ܂���������</summary>
    [SerializeField] bool m_generateOnStart = true;
    /// <summary>�^�C�}�[�v���p�ϐ�</summary>
    // Start is called before the first frame update
    float m_timer;
    void Start()
    {
        if (m_generateOnStart)
        {
            m_timer = m_interval;

        }
    }

    // Update is called once per frame
    void Update()
    {

        // Time.deltaTime �́u�O�t���[������̌o�ߎ��ԁv���擾����
        // �����ώZ���āu�o�ߎ��ԁv�����߂�̂� Unity �ł̓T�^�I�ȃv���O���~���O�̃p�^�[���ł���
        m_timer += Time.deltaTime;

        // �u�o�ߎ��ԁv���u��������Ԋu�v�𒴂�����
        if (m_timer > m_interval)
        {
            m_timer = 0;    // �^�C�}�[�����Z�b�g���Ă���
            Instantiate(m_prefab, this.transform.position, Quaternion.identity);
        }
    }
}