using System;
using TMPro;
using UnityEngine;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        public void Awake()
        {
            _scoreText.text = "0";
        }

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}