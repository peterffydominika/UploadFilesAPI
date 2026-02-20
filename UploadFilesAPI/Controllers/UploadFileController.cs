using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFilesAPI.Services.Interfaces;

namespace UploadFilesAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase {
        private readonly IUploadFile _uploadFile;

        public UploadFileController(IUploadFile uploadFile) {
            _uploadFile = uploadFile;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile formFile) {
            var up = await _uploadFile.Upload(formFile);
            if (up != null)
            {
                return Ok(up);
            }
            return BadRequest(new { message = "Sikertelen tárolás." });
        }
    }
}
