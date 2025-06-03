namespace CafeOfFear
{
    public interface IMainPersonState
    {
        void EnterState(MainPerson mainPerson);
        void UpdateState();
    }
}
