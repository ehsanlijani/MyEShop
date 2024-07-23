namespace MyEShop.Domain.Contracts.Common;

public interface IBaseSeeder<T> where T : class
{
    IEnumerable<T> GetSeedData();
}