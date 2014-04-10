namespace ChromeBookmarksDeserializer.JsonModels
{
    using System;
    using System.Text;

    using Newtonsoft.Json;

    public class BookmarkRoot
    {
        #region Properties
        [JsonProperty(PropertyName = "checksum")]
        public string ChecksumItem { get; set; }

        [JsonProperty(PropertyName = "roots")]
        public Root Roots { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE NETSCAPE-Bookmark-file-1>");
            sb.Append(Environment.NewLine);
            sb.Append(@"<!-- This is an automatically generated file.");
            sb.Append(Environment.NewLine);
            sb.Append(@"It will be read and overwritten.");
            sb.Append(Environment.NewLine);
            sb.Append(@"DO NOT EDIT! -->");
            sb.Append(Environment.NewLine);
            sb.Append(@"<META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=UTF-8"">");
            sb.Append(Environment.NewLine);
            sb.Append(@"<TITLE>Bookmarks</TITLE>");
            sb.Append(Environment.NewLine);
            sb.Append(@"<H1>Bookmarks</H1>");
            sb.Append(Environment.NewLine);
            sb.Append(@"<DL><p>");
            sb.Append(Environment.NewLine);
            sb.Append(this.Roots);
            sb.Append(@"</DL><p>");
            sb.Append(Environment.NewLine);
            

            return sb.ToString();
        }
        #endregion
    }
}
