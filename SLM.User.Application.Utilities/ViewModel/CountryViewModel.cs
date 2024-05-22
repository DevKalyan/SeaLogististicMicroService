using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.ViewModel
{
    public class CountryViewModel
    {
        public string name { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string numericCode { get; set; }
        public string phoneCode { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string currencyName { get; set; }
        public string currencySymbol { get; set; }
        public string tld { get; set; }
        public string native { get; set; }
        public string region { get; set; }
        public string regionId { get; set; }
        public string subregion { get; set; }
        public string subregionId { get; set; }
        public string nationality { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string emoji { get; set; }
        public string emojiU { get; set; }
        public List<StateViewModel> states { get; set; }
    }

    public class StateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public object Type { get; set; } // Assuming type can be of any data type
    }
}
