namespace CafeOfFear
{
    public interface IVisitorState
    {
        void EnterState(Visitor visitor);
        void UpdateState();
    }
}
