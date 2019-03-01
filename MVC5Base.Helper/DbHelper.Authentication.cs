using MVC5Base.Entities;
using MVC5Base.ViewModels;
using System.Linq;

namespace MVC5Base.Helper
{
    public partial class DbHelper
    {
        public bool IsUsernameExists(string username)
        {
            return new Repository<User>(_context).Find(x => x.Username == username).FirstOrDefault() != null;
        }

        public UserViewModel GetUser(string username, string password)
        {
            return new Repository<User>(_context).Find(x => x.Username == username && x.Password == password).FirstOrDefault().ToVM();
        }
    }
}
