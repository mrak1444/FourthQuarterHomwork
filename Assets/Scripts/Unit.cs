using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int _health = 0;

    void Start()
    {
        ReceiveHealing();
    }

    public void ReceiveHealing()
    {
        StartCoroutine(Healing100());
    }

    private IEnumerator HealingThree()
    {
        Debug.Log("Run thre second:");
        float i = 0;
        while (i < 3f)
        {
            _health += 5;
            yield return new WaitForSeconds(0.5f);
            Debug.Log($"Second = {i+0.5f}, Health = {_health}");
            i += 0.5f;
        }
        
    }

    private IEnumerator Healing100()
    {
        yield return StartCoroutine(HealingThree());
        Debug.Log("reset health");
        _health = 0;
        yield return new WaitForSeconds(1f);
        Debug.Log("Run 100 percent:");
        while (_health < 100)
        {
            _health += 5;
            yield return new WaitForSeconds(0.5f);
            Debug.Log($"Health = {_health}");
        }
    }
}
