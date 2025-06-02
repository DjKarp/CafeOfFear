namespace CafeOfFear
{
    public class MetallItems : OutlineItems
    {
        protected override void ItemFall()
        {
            AudioService.PlayItemSound(AudioService.ItemSound.ForkDropped, gameObject);
        }
    }
}
