using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Service
{
    class Note
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Subj")]
        public string Subj { get; set; }
        [JsonProperty("Note1")]
        public decimal Note1 { get; set; }
        [JsonProperty("StudentId")]
        public int StudentId { get; set; }
    }

    class NoteResponse
    {
        public Note[] Value { get; set; }

    }
}
