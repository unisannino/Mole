using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Unisannino.Mole.Runtime.Model
{
    [CreateAssetMenu(fileName = "MoleMasterData", menuName = "Mole/MasterData", order = 0)]
    public class MasterData : ScriptableObject
    {
        [SerializeField] private MoleParameter moleParameter;
        
        private static MasterData _instance;
        
        public MoleParameter MoleParameter => moleParameter;
        
        public static MasterData Instance
        {
            // エディタ上プレイだとOnEnableが呼ばれていないようなので手動で探して参照する
            get => _instance ??= Load();
            private set => _instance = value;
        }

        private void OnEnable()
        {
            if (Instance is not null) return;
            Instance = this;
        }

        private static MasterData Load()
        {
            MasterData master;
#if UNITY_EDITOR
            // エディタの時だけ動く
            master = PlayerSettings.GetPreloadedAssets().OfType<MasterData>().FirstOrDefault();
#endif
            return master;
        }
    }
}