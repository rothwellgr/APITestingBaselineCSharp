using APITestingBaselineCSharp.DTOs;
using APITestingBaselineCSharp.Interfaces;

namespace APITestingBaselineCSharp.Clients;

public class HTTPBin(IClient client)
{
    public Task<SlideshowDTO> Slideshow() =>
        client.Send<SlideshowDTO>(HTTPBinUrls.Slideshow);

    public Task<UuidDTO> Uuid() =>
        client.Send<UuidDTO>(HTTPBinUrls.Uuid);
}
