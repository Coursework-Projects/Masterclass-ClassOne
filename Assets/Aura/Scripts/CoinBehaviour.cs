using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    [SerializeField] float m_RotateAngle = 1.5f;

    [Header("FX Variables")]
    [SerializeField] AudioClip m_CoinFX;
    AudioSource m_AudioSource;

    Collider m_CoinCollider;
    MeshRenderer m_MeshRenderer;

    private void Start()
    {
        m_CoinCollider = GetComponent<Collider>();
        m_MeshRenderer = GetComponent<MeshRenderer>();
        //m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate coin by certain angle amount each frame
        transform.Rotate(Vector3.forward, m_RotateAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        AudioSource.PlayClipAtPoint(m_CoinFX, transform.position);
        m_CoinCollider.enabled = false;
        m_MeshRenderer.enabled = false;
        
    }
}
