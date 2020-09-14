using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField]
    private float _moveDistance = 1f;
    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private bool bTranslation;

    private float unSync;
    // Start is called before the first frame update
    void Start()
    {
        unSync = Random.value + Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        HoverUpDown();
    }

    void HoverUpDown()
    {
        if (bTranslation)
        {
            this.transform.Translate(Vector3.up * Mathf.Sin(_moveSpeed * Time.time) * (_moveDistance * unSync) * Time.deltaTime);
        }
        else
        {
            Debug.Log("Translation switched"); 
            transform.position += new Vector3(0, Mathf.Sin(_moveSpeed * Time.time) * _moveDistance * Time.deltaTime, 0);
        }
    }
}
