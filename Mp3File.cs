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


        public Mp3File(String fileName)
        {
            var file = TagLib.File.Create(fileName);

            Title = file.Tag.Title;

            Track = file.Tag.Track;
        }
    }
}
