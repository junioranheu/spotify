using System.ComponentModel;

namespace Spotify.API.Enums
{
    public enum CaminhosUploadEnum
    {
        [Description("UploadProtegido/music/")]
        UploadProtegidoMusica = 1,

        [Description("Upload/playlists/")]
        UploadPlaylists = 2
    }
}
