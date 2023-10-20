using SiteScanAPI.Model;

namespace SiteScanAPI.Services
{
    public interface IloginService
    {
        bool IsAuthenticated(LoginUserModel loginUserModel);
    }
    public class loginService : IloginService
    {
        private SiteScanDBContext _context;

        IUserService _userService;
        public loginService(SiteScanDBContext context, IUserService service)
        {
            _context = context;
            _userService = service;
        }
        public bool IsAuthenticated(LoginUserModel loginUserModel)
        {
            User user = _userService.GetUserDetailsById(loginUserModel.UserName);
            if(user == null) return false;
            if (user.Password.Equals(loginUserModel.Password)) return true;
            return false;  
        }
    }
}
