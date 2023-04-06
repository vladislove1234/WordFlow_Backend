using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using VeeArc.Application.Common.Interfaces;

namespace VeeArc.Infrastructure.BlobStorages;

public class ImageStorageRepositry : IImageStorageRepositry
{
    private const string StorageContainerName = "images";

    private BlobContainerClient _blobContainerClient;

    public ImageStorageRepositry(BlobServiceClient blobServiceClient)
    {
        _blobContainerClient = blobServiceClient.GetBlobContainerClient(StorageContainerName);
    }

    public async Task<string> UploadImage(IFormFile image)
    {
        string imageName = CreateImageName();

        using Stream data = image.OpenReadStream();
        await _blobContainerClient.UploadBlobAsync(imageName, data);

        string imageUri = CreateImageUri(imageName);

        return imageUri;
    }

    internal static void Init(BlobServiceClient blobServiceClient)
    {
        BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(StorageContainerName);

        blobContainerClient.CreateIfNotExists(PublicAccessType.BlobContainer);
    }

    private string CreateImageName()
    {
        string imageName = Guid.NewGuid().ToString() + ".png";

        return imageName;
    }

    private string CreateImageUri(string imageName)
    {
        string imageUri = _blobContainerClient.Uri.AbsoluteUri + '/' + imageName;

        return imageUri;
    }
}
