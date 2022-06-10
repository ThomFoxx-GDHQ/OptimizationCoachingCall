using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _coins = 0;
    [SerializeField] private Text _coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_coins != GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coin)
        {
            _coins = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coin;
            _coinText.text = "Coins: " + _coins;
        }            
    }
}
