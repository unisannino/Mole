using System.Collections.Generic;
using Unisannino.Mole.Runtime.Extensions;

namespace Unisannino.Mole.Runtime.Model
{
    public class MoleUseCase
    {
        private readonly MoleEntity[] _moleEntities;

        private IList<int> _moleSpawnIndexList;

        public MoleUseCase(int moleAmount)
        {
            _moleEntities = new MoleEntity[moleAmount];
            for (var i = 0; i < moleAmount; i++)
            {
                _moleEntities[i] = new MoleEntity();
            }
            _moleSpawnIndexList = new List<int>(_moleEntities.Length);
        }

        public bool CanWhack(int moleIndex)
        {
            return _moleEntities[moleIndex].CanWhack;
        }

        public void ChangeCanWhack(int moleIndex, bool canWhack)
        {
            _moleEntities[moleIndex].ChangeCanWhack(canWhack);
        }

        public int GetMoleScore(int moleIndex)
        {
            var baseScore = MasterData.Instance.MoleParameter.MoleScore;
            return _moleEntities[moleIndex].IsFever ? baseScore * 2 : baseScore;
        }

        public int SpawnMole()
        {
            if (_moleSpawnIndexList.Count == 0)
            {
                GenerateSpawnList();
            }
            var spawnIndex = _moleSpawnIndexList[0];
            _moleSpawnIndexList.RemoveAt(0);
            return spawnIndex;
        }
        
        private void GenerateSpawnList()
        {
            _moleSpawnIndexList.Clear();
            for (var i = 0; i < _moleEntities.Length; i++)
            {
                _moleSpawnIndexList.Add(i);
            }
            _moleSpawnIndexList.Shuffle();
        }
    }
}