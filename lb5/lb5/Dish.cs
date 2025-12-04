namespace RestaurantSystem
{
    public class Dish : MenuItem
    {
        public int WeightGrams { get; private set; }

        public Dish(string name, decimal price, string category, int weight)
            : base(name, price, category)
        {
            WeightGrams = weight;
        }

        public override string GetDescription()
        {
            return $"[Страва] {Name} ({WeightGrams}г) | {Category}";
        }
    }
}