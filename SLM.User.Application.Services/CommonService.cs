using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLM.User.Application.Services
{
    public class CommonService : ICommonService
    {

        public async Task<List<CountryViewModel>> GetCountryListAsync()
        {
            try
            {
                // Read the JSON file containing country data
                string fileName = "countries.json"; // Replace with the actual file name
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\Json", fileName);
                string jsonData = await File.ReadAllTextAsync(jsonFilePath);
                // Check if jsonData is null or empty
                if (string.IsNullOrWhiteSpace(jsonData))
                {
                    throw new Exception("JSON data is null or empty.");
                }
                // Deserialize the JSON data into a list of CountryViewModel objects
                List<CountryViewModel> countries = JsonSerializer.Deserialize<List<CountryViewModel>>(jsonData);

                return countries;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error occurred while reading JSON file: {ex.Message}");
                throw;
            }
        }
    }
}
