using PetSure.Helpers.SiteHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Constants;
using System.Web;

namespace PetSure.Controllers
{
    [RoutePrefix("api/Index")]
    public class IndexController : ApiController
    {
        SiteHelpers _siteHelper = new SiteHelpers();

        [HttpGet]
        [Route("PetList")]
        public IHttpActionResult PetList()
        {
            try
            {
                var _petList = _siteHelper.PetList();
                return Ok(new { Data = _petList });
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

        }

        [HttpPost]
        [Route("PostFileWithData")]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string _filePath = WebSettings.FILE_REPO();
            var _physicalPath = HttpContext.Current.Server.MapPath(_filePath);
            Directory.CreateDirectory(_physicalPath);
            var _provider = new FilenameMultipartFormDataStreamProvider(_physicalPath);
            var _result = await Request.Content.ReadAsMultipartAsync(_provider);



            return Request.CreateResponse(HttpStatusCode.OK, "success!");
        }
    }
}
