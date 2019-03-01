using MVC5Base.Entities;
using MVC5Base.ViewModels;

namespace MVC5Base.Helper
{
    public static class Conversion
    {

        public static RoleViewModel ToVM(this Role obj)
        {
            if (obj == null) return null;
            return new RoleViewModel
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static UserViewModel ToVM(this User obj)
        {
            if (obj == null) return null;
            return new UserViewModel
            {
                Id = obj.Id,
                Username = obj.Username,
                Password = "",
                RoleId = obj.RoleId,
                Role = obj.Role.ToVM()
            };
        }

        public static StudentViewModel ToVM(this Student obj)
        {
            if (obj == null) return null;
            return new StudentViewModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Age = obj.Age,
                Email = obj.Email,
                UserId = obj.UserId,
                User = obj.User.ToVM()
            };
        }
    }
}
