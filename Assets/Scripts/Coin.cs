using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coint_value;
    private void Start()
    {
        coint_value = Random.Range(1, 20);
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(Resources.Load("coin_txt") as GameObject, transform.position, Quaternion.identity).GetComponent<BilBoardText>().SetText("+" + coint_value);
        GameManager.instance.AddCoin(coint_value);
        Destroy(gameObject);
    }
}
