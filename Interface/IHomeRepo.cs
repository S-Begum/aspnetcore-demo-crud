using Demo1CoreCRUD.Models;

namespace Demo1CoreCRUD.Interface
{
    public interface IHomeRepo
    {
        Task<List<ToDoList>> GetAll();
        Task<ToDoList?> GetById(int id);
        Task<bool> Update(ToDoList entity);
        Task<bool> Add(ToDoList entity);
        Task<bool> Delete(ToDoList entity);
    }
}
