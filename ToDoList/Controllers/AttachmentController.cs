using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AttachmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("upload/{id}")]
        //[RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public void Upload(int id)
        {
            //List<int> IDs = new List<int>();
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "filesUploaded");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Any(f => f.Length == 0))
                {
                   // return IDs;
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    //you can add this path to a list and then return all dbPaths to the client if require
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        //stream.
                        file.CopyTo(stream);
                    }
                    //   return Ok(new { dbPath });
                    var attach = new Attachments();
                    attach.FileName = dbPath;
                    attach.TaskId = id;
                    _context.attachments.Add(attach);
                    _context.SaveChanges();
                    //IDs.Add(attach.Id);
                }
                //return IDs;
            }
            catch (Exception ex)
            {
                //return IDs;
            }
        }
    }
}
