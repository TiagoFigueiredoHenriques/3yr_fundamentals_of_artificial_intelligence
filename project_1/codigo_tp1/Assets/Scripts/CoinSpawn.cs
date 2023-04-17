using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawn : MonoBehaviour
{

    public float max_x;
    public float min_x;
    public float max_z;
    public float min_z;

    public int max_num_coins = 20;
    public int num_coins;
    private int initial_num;

    public GameObject Coin;

    void Start()
    {
        num_coins = max_num_coins;
        initial_num = max_num_coins;
        for (int i = 0; i < max_num_coins; i++)
        {
            float x = Random.Range(min_x, max_x);
            float z = Random.Range(min_z, max_z);

            Instantiate(Coin, new Vector3(x, 0.5f, z), Quaternion.identity);
        }
    }
}
