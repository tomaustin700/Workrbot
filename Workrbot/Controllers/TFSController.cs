using System.Web.Http;
using Workrbot.Classes;
using Workrbot.Enums;
using static Workrbot.Engines.RuleProcessingEngine;

namespace Workrbot.Controllers
{
    public class TFSController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/TFS/WorkItemCreated")]
        public IHttpActionResult WorkItemCreated([FromBody] TfsReturn data)
        {
            ProcessWorkItemAction(data, EventTrigger.WorkItemCreated);
            return Ok();


        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/TFS/WorkItemDeleted")]
        public IHttpActionResult WorkItemDeleted([FromBody] TfsReturn data)
        {
            ProcessWorkItemAction(data, EventTrigger.WorkItemDeleted);
            return Ok();


        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/TFS/WorkItemRestored")]
        public IHttpActionResult WorkItemRestored([FromBody] TfsReturn data)
        {
            ProcessWorkItemAction(data, EventTrigger.WorkItemRestored);
            return Ok();


        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/TFS/WorkItemUpdated")]
        public IHttpActionResult WorkItemUpdated([FromBody] TfsReturn data)
        {
            ProcessWorkItemAction(data, EventTrigger.WorkItemUpdated);
            return Ok();


        }
        
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/TFS/CommentPosted")]
        public IHttpActionResult CommentPosted([FromBody] TfsReturnComment data)
        {

            ProcessCommentPosted(data);
            return Ok();

        }

    }
}