using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.App_Start.Messaging
{
    public class Attachment
    {
        public Attachment(String fileName, object content)
        {
            FileName = fileName ;
            Content = content;
            Type = AttachmentType.Text;
        }

        public string FileName { get; set; }
        public object Content { get; set; }
        public AttachmentType Type { get; set; }

        public enum AttachmentType{
            Text,
            Json
        }

        public async Task<MemoryStream> ContentToStreamAsync()
        {
            string text;
            switch (Type)
            {
                case AttachmentType.Json:
                    text = Newtonsoft.Json.JsonConvert.SerializeObject(Content);
                    break;
                case AttachmentType.Text:
                    text = Content.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            await writer.WriteAsync(text );
            await writer.FlushAsync();
            stream.Position = 0;

            return stream;
        }
    }


}
