namespace ItemsEquipped
{
    public interface IItemsEquipped
    {
        int WeaponId { get; set; }
        int ArmorId { get; set; }
        int ShoesId { get; set; }
        int RingId { get; set; }
        int NecklaceId { get; set; }
        int HelmetId { get; set; }
    }
}