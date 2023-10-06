using budda.DAL;
using budda.Models;

namespace budda.BLL
{
    public class CategoriesBLL
    {
        public List<Category> GetCategory()
        {
            var car = new CategoriesDAO();
            return car.GetCategory();
        }
        
        public void Post(Category category)
        {
            var dal = new CategoriesDAO();
            dal.Post(category);
        }

        public void Put(Category category)
        {
            var dal = new CategoriesDAO();
            dal.Put(category);
        }

        public void Delete(int id)
        {
            var dal = new CategoriesDAO();
            dal.Delete(id);
        }
    }
}