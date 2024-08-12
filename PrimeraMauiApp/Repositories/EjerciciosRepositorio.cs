using PrimeraMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Util.EventLogTags;

namespace PrimeraMauiApp.Repositories
{
    public class ejerciciosRepositorio
    {
        string urlApi = "https://biblioip20-8c17.restdb.io/rest/libros";
        HttpClient client = new HttpClient();

        public ejerciciosRepositorio()
        {
            // Configuramos que trabajará con respuestas JSON
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("apikey", "d57db9d7572d74af31b5445f5fe19b4f5f007");
        }

        public async Task<ObservableCollection<Ejercicio>?> ObtenerejerciciosAsync()
        {
            var response = await client.GetStringAsync(urlApi);
            return JsonConvert.DeserializeObject<ObservableCollection<Ejercicio>>(response);
        }

        public async Task<Ejercicio?> AgregarAsync(string nombre, string portada_url, string descripcion, string numerodeseries, string id)
        {
            // Creamos un objeto del tipo ejercicio con los parámetros que llegan
            Ejercicio ejercicio = new Ejercicio()
            {
                nombre = nombre,
                portadaUrl = portada_url,
                descripcion = descripcion,
                numerodeseries = numerodeseries
            };

            // Enviamos por POST el objeto que creamos a la URL de la API
            var ejercicioJson = new StringContent(
                    JsonConvert.SerializeObject(ejercicio),
                    Encoding.UTF8, "application/json");
            var response = await client.PostAsync(urlApi,
                new StringContent(
                    JsonConvert.SerializeObject(ejercicio),
                    Encoding.UTF8, "application/json"));

            // Retorna el objeto que se agregó en la API ya con su ID generado por la base de datos
            return JsonConvert.DeserializeObject<Ejercicio>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Ejercicio?> ActualizarAsync(string nombre, string portada_url, string descripcion, string numerodeseries, string id)
        {
            //creamos un objeto del tipo ejercicio con los parámetros que llegan
            Ejercicio ejercicio = new Ejercicio()
            {
                nombre = nombre,
                portadaUrl = portada_url,
                descripcion = descripcion,
                numerodeseries = numerodeseries
            };

            //enviamos por PUT el objeto que creamos a la URL de la API
            var ejerciciojson = new StringContent(
                    JsonConvert.SerializeObject(ejercicio),
                    Encoding.UTF8, "application/json");

            var response = await client.PutAsync(urlApi + "/" + id, ejerciciojson);

            //retorna el objeto que se agregó en la API ya con su ID generado por la base de datos
            return JsonConvert.DeserializeObject<Ejercicio>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Ejercicio?> ObtenerPorIdAsync(string id)
        {
            var response = await client.GetStringAsync($"{urlApi}/{id}");
            return JsonConvert.DeserializeObject<Ejercicio>(response);
        }

        public async Task<bool> EliminarAsync(string id)
        {
            var response = await client.DeleteAsync(urlApi + "/" + id);
            return response.IsSuccessStatusCode;
        }
    }
}
