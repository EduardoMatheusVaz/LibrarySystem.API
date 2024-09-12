namespace LibrarySystem.Infrastructure.CloudServices.Interfaces;

public interface IFileStorageBooks
{

    void UploadFile(byte[] bytes, string name);

}
