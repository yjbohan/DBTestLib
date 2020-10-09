using System;
using System.Collections.Generic;
using System.Text;

namespace DBTestLib
{
    class RequestsController
    {
        public bool RecalculateRequestTotal(int Id)
        {
            var request = _context.Requests.Find(Id);
            var reqTotal = (from li in _context.Lineitems.ToList()
                            join pr in _context.Products.ToList()
                            on li.ProductId equals pr.Id
                            where li.RequestId == Id
                            select new
                            {
                                LineTotal = li.Quantity * pr.Price
                            }).Sum(t => t.LineTotal);
            request.Total = reqTotal;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Reviews the request for the owner(user)
        /// Status is set to APPROVED if Total <= 50
        /// else status is set to REVIEW
        /// </summary>
        /// <param name="request">A request</param>
        /// <returns>True if successful; else false</returns>
        public bool ReviewRequest(Request request)
        {
            //if(request.Total <= 50) {
            //    request.Status = "APPROVED";
            //} else {
            //    request.Status = "REVIEW";
            //}
            request.Status = (request.Total <= 50) ? "APPROVED" : "REVIEW";
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Sets the status of the request to REJECTED
        /// </summary>
        /// <param name="request">A single request</param>
        /// <returns>True if successful; else false</returns>
        public bool SetToRejected(Request request)
        {
            request.Status = "REJECTED";
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Sets the status of the request to APPROVED
        /// </summary>
        /// <param name="request">A single request</param>
        /// <returns>True if successful; else false</returns>
        public bool SetToApproved(Request request)
        {
            request.Status = "APPROVED"; //this is stating, 'changing the Status to APPROVED.
            _context.SaveChanges();
            return true; //entering 'true' is letting the caller know that the the 'APPROVED' worked.  Without the true or Default, the caller will 
            //(cont...) will not know the status of the request they submitted.
            //this is the function that will be called to change it to 'APPROVED'
            //each line above is seperate as it will be separte actions that need to be called for the Code to be called to the right Method.
            //'SaveChanges' nneds to be applie if you  'Change, Insert or Delete' the data.
        }
    }
}

   
