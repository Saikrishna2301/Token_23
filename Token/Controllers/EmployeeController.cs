using Dal.Rep;
using Model.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Token.Controllers
{
    public class EmployeeController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        [Route("employee")]
        public HttpResponseMessage RegisterAssets(Emloyee employee)

        {
            HttpResponseMessage response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var projectDetails = new EmpRep().RegisterAssetDetails(employee);
                    logger.Log(NLog.LogLevel.Info, "method executed successfully.");
                    return this.Request.CreateResponse(projectDetails);
                }
                var error = new
                {
                    message = "The request is invalid.",
                    error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)
                };
                logger.Error(error.message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, error);

            }
            catch (EntityExistsException ex)
            {
                var error = new Error { ErrorCode = "5401", ErrorDescription = ex.Message, Message = "JobCardTasks Not Exists ", Status = "Failed" };
                logger.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.OK, error);
            }
            catch (Exception e)
            {
                var error = new Error { ErrorCode = "5402", ErrorDescription = e.Message, Status = "Failed" };
                logger.Error(e.Message);
                return Request.CreateResponse(HttpStatusCode.OK, error);
            }
        }
    }
}


