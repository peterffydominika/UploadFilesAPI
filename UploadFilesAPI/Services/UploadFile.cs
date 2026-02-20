using UploadFilesAPI.Models;
using UploadFilesAPI.Services.Interfaces;

namespace UploadFilesAPI.Services {
    public class UploadFile : IUploadFile {
        private readonly FilestoreContext _storecontext;

        public UploadFile(FilestoreContext storecontext) {
            _storecontext = storecontext;
        }

        public async Task<object> Download(int id) {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> Upload(IFormFile formFile) {
            try
            {
                if (formFile != null || formFile.Length != 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);

                        var file = new Fileupload {
                            FileData = memoryStream.ToArray(),
                            FileName = formFile.Name,
                            ContentType = formFile.ContentType
                        };
                        await _storecontext.AddAsync(file);
                        await _storecontext.SaveChangesAsync();

                        return new { message = "Sikeres tárolás." };
                    }
                }
                return new { message = "Sikertelen tárolás." };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }
    }
}
