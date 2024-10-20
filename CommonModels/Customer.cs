namespace CommonModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class Customer
    {
        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonInclude]
        [JsonPropertyName("name")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [JsonInclude]
        [JsonPropertyName("reference")]
        [Display(Name = "Reference")]
        public string Reference { get; set; }
    }
}
