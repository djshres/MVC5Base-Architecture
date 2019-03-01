using System.Security.Principal;

namespace MVC5Base.Web.Models
{
    internal interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        int RoleId { get; set; }
        string Name { get; set; }
    }
    public class CustomPrincipal : ICustomPrincipal
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }

        public IIdentity Identity { get; private set; }

        public CustomPrincipal(string name)
        {
            Identity = new GenericIdentity(name);
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
    }


}