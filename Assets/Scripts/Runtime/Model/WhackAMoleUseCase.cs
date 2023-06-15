namespace Unisannino.Mole.Runtime.Model
{
    public class WhackAMoleUseCase
    {
        private readonly MoleEntity[] _moleEntities;

        public WhackAMoleUseCase(int moleAmount)
        {
            _moleEntities = new MoleEntity[moleAmount];
            for (var i = 0; i < moleAmount; i++)
            {
                _moleEntities[i] = new MoleEntity(MasterData.Instance.MoleParameter.MoleScore);
            }
        }
        
        public bool CanWhack(int moleIndex)
        {
            return _moleEntities[moleIndex].CanWhack;
        }
        
        public void PresentMole(int moleIndex)
        {
            _moleEntities[moleIndex].ChangeCanWhack(true);
        }
        
        public void WhackMole(int moleIndex)
        {
            _moleEntities[moleIndex].ChangeCanWhack(false);
        }
        
        public int GetMoleScore(int moleIndex)
        {
            return _moleEntities[moleIndex].Score;
        }
    }
}