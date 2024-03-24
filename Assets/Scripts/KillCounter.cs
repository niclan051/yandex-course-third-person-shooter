using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> counters;
    public uint Kills { get; set; }

    private void Update()
    {
        counters.ForEach(counter => counter.text = Kills.ToString());
    }
}