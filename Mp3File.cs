using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3Taggr
{
    class Mp3File
    {
        public string Title { get; set; }

        public uint Track { get; set; }
        
        public string Artist { get; set; }

        public string Album { get; set; }


        public Mp3File(String fileName)
        {
            var file = TagLib.File.Create(fileName);

            Title = file.Tag.Title;

            Track = file.Tag.Track;

            string[] artists = file.Tag.AlbumArtists;

            if (artists != null && artists.Length > 0)
            {
                Artist = artists[0];
            }
            else
            {
                Artist = "";
            }
        }
    }
}
