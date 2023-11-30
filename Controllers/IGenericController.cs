using Microsoft.AspNetCore.Mvc;

namespace DatabaseProject.Controllers
{
    public interface IGenericController<T> where T : class
    {
        public IActionResult Add();
        public IActionResult Add(T entity);
        public IActionResult Remove(int id);
        public IActionResult Update(int id);
        public IActionResult Update(T entity);
    }
}
