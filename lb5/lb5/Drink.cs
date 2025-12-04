namespace RestaurantSystem
{
    public class Drink : MenuItem
    {
        public int VolumeMl { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Drink(string name, decimal price, string category, int volume, bool isAlcoholic)
            : base(name, price, category)
        {
            VolumeMl = volume;
            IsAlcoholic = isAlcoholic;
        }

        public override string GetDescription()
        {
            string alc = IsAlcoholic ? "Алкоголь" : "б/а";
            return $"[Напій] {Name} ({VolumeMl}мл, {alc}) | {Category}";
        }
    }
}