using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BBT_EstablecimientosDeSalud.Models
{
    public class EstablecimientoResponse
    {
        public int establecimiento_id { get; set; }
        public string clasfreal { get; set; }
        private readonly HttpClient httpClient;

        public EstablecimientoResponse()
        {
            httpClient = new HttpClient();
        }
        public async Task<EstablecimientoResponse> ObtenerEstablecimiento(int id)
        {
            // URL del endpoint de tu API
            string apiUrl = $"http://localhost:5000/api/establecimiento?id={id}";

            // Realizar la solicitud GET y obtener la respuesta
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            EstablecimientoResponse objEstResp = new EstablecimientoResponse();
            // Verificar si la respuesta es exitosa (código de estado 200)
            if (response.IsSuccessStatusCode)
            {
                // Leer la respuesta como una cadena de texto
                string responseContent = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON a un objeto
                var responseData = JsonConvert.DeserializeObject<EstablecimientoResponse>(responseContent);

                // Utilizar los datos obtenidos
                var establecimientoId = responseData.establecimiento_id;
                var clasfreal = responseData.clasfreal;

                // Resto del código para trabajar con los datos obtenidos

                return responseData; // O devuelve la vista correspondiente
            }
            else
            {
                // Manejar el caso de error en la respuesta

                return objEstResp;
            }
        }
    }
}
