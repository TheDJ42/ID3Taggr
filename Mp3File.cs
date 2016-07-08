using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ID3Taggr
{
    class Mp3File
    {
        public string Title { get; set; }

        public uint Track { get; set; }

        public uint Year { get; set; }

        public string saveFileName { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public string Genre { get; set; }

        public uint Disc { get; set; }

  

        public Mp3File(String fileName)
        {
            var file = TagLib.File.Create(fileName);

            saveFileName = fileName;

            Title = file.Tag.Title;

            Track = file.Tag.Track;

            Year = file.Tag.Year;

            Disc = file.Tag.Disc;

            string[] genre = file.Tag.Genres;

            if (genre != null && genre.Length > 0)
            {
                Genre = genre[0];
            }
            else
            {
                Genre = "";
            }

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
