namespace UploadFilesAPI.Services.Interfaces {
    public interface IUploadFile {
        Task<object> Upload(IFormFile formFile);
    }
}
