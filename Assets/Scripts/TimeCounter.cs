using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> counters;
    public DateTime CurrentTime { get; set; }

    private void Update()
    {
        CurrentTime = CurrentTime.AddSeconds(Time.deltaTime);
        counters.ForEach(counter => counter.text = CurrentTime.ToString("HH:mm:ss"));
    }
}