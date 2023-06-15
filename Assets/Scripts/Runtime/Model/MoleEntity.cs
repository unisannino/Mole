namespace Unisannino.Mole.Runtime.Model
{
    public class MoleEntity
    {
        public int Score { get; private set; }
        public bool CanWhack { get; private set; }
        
        public MoleEntity(int score)
        {
            Score = score;
            CanWhack = false;
        }
        
        public void ChangeCanWhack(bool canWhack)
        {
            CanWhack = canWhack;
        }
        
        public void ChangeScore(int score)
        {
            Score = score;
        }
    }
}