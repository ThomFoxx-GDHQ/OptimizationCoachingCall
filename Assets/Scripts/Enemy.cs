using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private bool _scared = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coin >=5)
        {
            GetComponent<Renderer>().material.color = Color.white;
            transform.LookAt(GameObject.Find("Player").transform.position);
            transform.Rotate(Vector3.up, 180);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            _scared = true;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
            transform.LookAt(GameObject.Find("Player").transform.position);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            _scared = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag =="Player")
        {
            if(_scared == true)
            {
                Destroy(gameObject);
            }
            else
            {
                other.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
