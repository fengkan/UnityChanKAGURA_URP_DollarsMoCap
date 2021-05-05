using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanBlink : MonoBehaviour {

    float m_interVal = 5.0f;

    float m_closingTime = 0.12f;

    float m_openSeconds = 0.06f;

    float m_closeSeconds = 0.06f;

    protected Coroutine m_coroutine;

    UnityChanExpression uce;


    float m_nextRequest;
    bool m_request;

    float value = 0.0f;

    public bool isBlinking;

    void Awake()
    {
        uce = GetComponent<UnityChanExpression>();
    }

    public bool Request
    {
        get { return m_request; }
        set
        {
            if (Time.time < m_nextRequest)
            {
                return;
            }
            m_request = value;
            m_nextRequest = Time.time + 1.0f;
        }
    }

    void LateUpdate()
    {
        uce.SetExpression("MiYan", value);
    }

    protected IEnumerator BlinkRoutine()
    {
        while (true)
        {
            var waitTime = Time.time + Random.value * m_interVal;
            while (waitTime > Time.time)
            {
                if (Request)
                {
                    m_request = false;
                    break;
                }
                yield return null;
            }

            // close
            isBlinking = true;
            var closeSpeed = 1.0f / m_closeSeconds;
            while (true)
            {
                value += Time.deltaTime * closeSpeed;
                if (value >= 1.0f)
                {
                    break;
                }
                yield return null;
            }
            value = 1;

            // wait...
            yield return new WaitForSeconds(m_closingTime);

            // open
            value = 1.0f;
            var openSpeed = 1.0f / m_openSeconds;
            while (true)
            {
                value -= Time.deltaTime * openSpeed;
                if (value < 0)
                {
                    break;
                }


                yield return null;
            }

            value = 0;
            isBlinking = false;
        }
    }


    private void OnEnable()
    {
        m_coroutine = StartCoroutine(BlinkRoutine());
    }

    private void OnDisable()
    {
        if (m_coroutine != null)
        {
            StopCoroutine(m_coroutine);
            m_coroutine = null;
        }
    }

}
