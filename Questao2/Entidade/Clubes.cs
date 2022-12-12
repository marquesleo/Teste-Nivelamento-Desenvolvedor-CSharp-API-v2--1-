using System;
namespace Questao2.Entidade
{
    
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Datum
        {
            public string competition { get; set; }
            public int year { get; set; }
            public string round { get; set; }
            public string team1 { get; set; }
            public string team2 { get; set; }
            public int team1goals { get; set; }
            public int team2goals { get; set; }
        }

        public class Root
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<Datum> data { get; set; }
        }


    
}

