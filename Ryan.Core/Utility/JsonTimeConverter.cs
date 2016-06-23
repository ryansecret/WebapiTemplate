using Newtonsoft.Json.Converters;

namespace Ryan.Core.Utility
{
    /// <summary>
    ///  
    /// </summary>
    public class JsonTimeConverter:IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTimeConverter"/> class.
        /// </summary>
        public JsonTimeConverter()
        {
            this.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}