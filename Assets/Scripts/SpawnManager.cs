using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _coinCount = 50;
    [SerializeField] private int _enemyCount = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _coinCount; i++)
        {
            Instantiate(_coinPrefab, new Vector3(Random.Range(-45f,45f),1, Random.Range(-45f, 45f)), Quaternion.identity);
        }
        for (int i = 0; i < _enemyCount; i++)
        {
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-45f, 45f), 1, Random.Range(-45f, 45f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
