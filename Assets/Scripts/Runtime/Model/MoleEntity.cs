namespace Unisannino.Mole.Runtime.Model
{
    public class MoleEntity
    {
        public bool CanWhack { get; private set; }
        public bool IsFever { get; private set; }
        
        public MoleEntity()
        {
            CanWhack = false;
        }
        
        public void ChangeCanWhack(bool canWhack)
        {
            CanWhack = canWhack;
        }
        
        public void ChangeIsFever(bool isFever)
        {
            IsFever = isFever;
        }
    }
}