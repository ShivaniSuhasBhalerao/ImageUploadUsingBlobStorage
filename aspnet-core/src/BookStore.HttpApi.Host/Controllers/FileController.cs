using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

using System.IO;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using System.ComponentModel.DataAnnotations;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        #region Property  
        private readonly IFileService _fileService;
        #endregion

        #region Constructor  
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        #endregion

        #region Upload  
        [HttpPost(nameof(Upload))]
        public IActionResult Upload([Required] List<IFormFile> formFiles,  string subDirectory)
        {
            try
            {
                _fileService.UploadFile(formFiles, subDirectory);

                return Ok(new { formFiles.Count, Size = _fileService.SizeConverter(formFiles.Sum(f => f.Length)) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Download File  
        [HttpGet(nameof(Download))]
        public IActionResult Download([Required] string subDirectory)
        {

            try
            {
                var (fileType, archiveData, archiveName) = _fileService.DownloadFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}


