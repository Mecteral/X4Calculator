namespace ProductionComponents.Resources
{
    public interface IRawResource
    {
        public string Id
            => GetType().Name;
    }
}