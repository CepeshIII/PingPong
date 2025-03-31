using System;
using TMPro;
using UnityEngine;

internal class ScoreShower: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLabel;

    private void OnEnable()
    {
        textLabel = GetComponent<TextMeshProUGUI>();
    }

    internal void Show(int score)
    {
        textLabel.text = score.ToString();
    }
}