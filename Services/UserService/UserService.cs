//using FirstApiApp.DataContext;
//using Nest;

//namespace FirstApiApp.Services.UserService
//{
//    public class UserService : IUserService
//    {
//        private readonly ProgrammingClubDataContext _context;
//        public UserService(ProgrammingClubDataContext context)
//        {
//            _context = context;
//        }

//        //public AuthenticateResponse Authenticate(AuthenticateRequest model)
//        //{
//        //    var user = _context.Announcements.SingleOrDefault(x => x.IdAnnouncement == model.Username && x.Title == model.Password);

//        //    if(user == null) { return null; }
//        //    var token = generateJwtToken(user);
//        //    return new AuthenticateResponse(user, token);
//        //}

//        //public AuthenticateResponse Authenticate(AuthenticateRequest model)
//        //{
//        //    throw new NotImplementedException();
//        //}
//    }
//}
