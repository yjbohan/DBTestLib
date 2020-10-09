using System;
using DBTestLib;

namespace DBTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var _context = new PRSContext();

            var ReqCtrl = new RequestsController(_context);

            //.context. is stating to search in table 'Requests' and search the DB columns (i.e - Lineitems, Vendors, Products, Status and so on...
            // (cont...) and telling it what you need (i.e) .Find
            var req1 = _context.Requests.Find(1);
            var ok = ReqCtrl.ReviewRequest.(req1);
            var req3 = _context.Requests.Find(3);
            ok = ReqCtrl.ReviewRequest(req3);


            var req2 = _context.Requests.Find(2);
            var isWorked = ReqCtrl.SetToApproved(req2);

            var UserCtrl = new UsersController(_context);
            //Tests the login function
            var user = UserCtrl.Login("xx, xx");
            var xxuser = UserCtrl.Login("xx", "xx");
            var sauser = UserCtrl.Login("sa", "sa");
        }
    }
}
