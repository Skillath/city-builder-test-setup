namespace CityBuilder.Data
{
    public interface IConvertible<TData>
    {
        TData ToData();
    }
}
