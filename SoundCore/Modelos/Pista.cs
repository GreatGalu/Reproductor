using System;
using System.Drawing;
using System.IO;

namespace SoundCore.Modelos
{
    public record Pista(int Id, string Titulo, string Artista, int Bpm, int DuracionSegundos, string FilePath)
    {
        public Image? GetAlbumArt()
        {
            try
            {
                var file = TagLib.File.Create(FilePath);
                if (file.Tag.Pictures.Length > 0)
                {
                    var bin = file.Tag.Pictures[0].Data.Data;
                    using (MemoryStream ms = new MemoryStream(bin))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                // Ignoring exception, return null
            }
            return null;
        }
    }
}
