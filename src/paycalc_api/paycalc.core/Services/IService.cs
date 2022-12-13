using System;
namespace paycalc.core.Services;

public interface IService<T> where T : class
{
    public Task<bool> create(T obj); 
    public Task<T> get(int id); 
    public Task<IEnumerable<T>> getAll();
    public Task<bool> update(T obj); 
    public Task<bool> delete(int id);
}