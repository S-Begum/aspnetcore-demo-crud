using Demo1CoreCRUD.Data;
using Demo1CoreCRUD.Interface;
using Demo1CoreCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1CoreCRUD.Repository
{
    public class HomeRepo : IHomeRepo
    {
        private readonly AppDbContext _context;

        public HomeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoList>> GetAll()
        {
            return await _context.ToDoLists.ToListAsync();
        }

        public async Task<ToDoList?> GetById(int id)
        {
            return await _context.ToDoLists.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<bool> Add(ToDoList entity)
        {
            _context.Add(entity);
            return Save();
        }

        public Task<bool> Update(ToDoList entity)
        {
            _context.Update(entity);
            return Save();
        }

        public Task<bool> Delete(ToDoList entity)
        {
            _context.Remove(entity);
            return Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
