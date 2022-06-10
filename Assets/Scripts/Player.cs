using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _jumpHeight = 5f;
    private bool _isGrounded = false;
    public int coin = 0;
    private bool _isHulk = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * _speed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * _speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            transform.Translate(Vector3.up * _jumpHeight);
        }

        if (coin >= 5 && _isHulk == false)
        {
            StartCoroutine(CoolDownRoutine());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ground")
        {
            _isGrounded = true;
        }
        else if (other.transform.tag == "Enemy")
        {
            _speed = 0;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    private IEnumerator CoolDownRoutine()
    {

        yield return null;
        _isHulk = true;
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        yield return new WaitForSeconds(5f);
        transform.localScale = Vector3.one;        
        yield return new WaitForSeconds(.25f);
        _isHulk = false;
        coin -= 5;
    }    
}
