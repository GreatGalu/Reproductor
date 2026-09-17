using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Drawing;
using TagLib;

namespace Reproductor
{
    internal class Track
    {
        public Image GetAlbumArt(string filePath)
        {
            try
            {
                var file = TagLib.File.Create(filePath);

                if (file.Tag.Pictures.Length > 0)
                {
                    var bin = file.Tag.Pictures[0].Data.Data;
                    using (MemoryStream ms = new MemoryStream(bin))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null; 
        }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public TimeSpan Duration { get; set; }
        public string FilePath { get; set; }
        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}
