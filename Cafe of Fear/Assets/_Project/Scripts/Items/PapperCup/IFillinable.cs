namespace CafeOfFear
{
    public interface IFillinable
    {
        PapperCup.PapperCupState CupState { get; set; }
        void StartFilling();
    }
}
