using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Slider hungerBar;
    public float fillSpeed = -0.005f;
    public float targetValue = 0;
    private void Awake()
    {
        hungerBar = gameObject.GetComponent<Slider>();
        hungerBar.value = 100;
        Debug.Log(hungerBar.value);
    }
    // Start is called before the first frame update
    void Start()
    {
        IncreaseHunger(0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("C");
        if (hungerBar.value > targetValue) hungerBar.value += fillSpeed * Time.deltaTime;
    }

    public void IncreaseHunger(float inc)
    {
        hungerBar.value += inc;
    }
}
