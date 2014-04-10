namespace ChromeBookmarksDeserializer.JsonModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ChromeBookmarksJSONToHTML.Enums;
    using Newtonsoft.Json;

    public class BookMarkItem
    {
        #region Properties
        [JsonProperty(PropertyName = "children")]
        public List<BookMarkItem> Children { get; set; } 

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "type")]
        public BookmarkItemType Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "date_added")]
        public long DateAdded { get; set; }

        [JsonProperty(PropertyName = "date_modified")]
        public long DateModified { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Type.Equals(BookmarkItemType.folder))
            {
                sb.AppendFormat(
                    @"<DT><H3 ADD_DATE=""{0}"" LAST_MODIFIED=""{1}"">{2}</H3>",
                    this.DateAdded,
                    this.DateModified,
                    this.Name);
                sb.Append(Environment.NewLine);
                sb.Append("<DL><p>");
                sb.Append(Environment.NewLine);

                if (null != this.Children)
                {
                    this.Children.ForEach(c => sb.Append(c));
                }
                sb.Append("</DL><p>");
                sb.Append(Environment.NewLine);
            }
            else if (this.Type.Equals(BookmarkItemType.url))
            {
                sb.AppendFormat(@"<DT><A HREF=""{0}"" ADD_DATE=""{1}"">{2}</A>", this.Url, this.DateAdded, this.Name);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
        #endregion
    }
}
