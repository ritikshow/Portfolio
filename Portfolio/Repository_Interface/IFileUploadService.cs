namespace Portfolio.Repository_Interface
{
    public interface IFileUploadService
    {
        Task<string> SaveImageAsync(IFormFile file);
        Task<string> SaveResumeAsync(IFormFile file);
    }
}
