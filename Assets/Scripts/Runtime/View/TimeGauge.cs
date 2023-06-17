using Unisannino.Mole.Runtime.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Unisannino.Mole.Runtime.View
{
    public class TimeGauge : MonoBehaviour
    {
        [SerializeField] Image gaugeFillImage; 
        
        public void UpdateGauge(float currentTime)
        {
            var timeLimit = MasterData.Instance.MoleParameter.TimeLimit;
            gaugeFillImage.fillAmount = currentTime / timeLimit;
        }
    }
}