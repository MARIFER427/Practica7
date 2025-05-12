using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[Route("api/vuelos")]
public class VuelosController : Controller{

    [HttpGet("ciudades-origen")]
    public IActionResult CiudadesOrigen(){
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelos>("Vuelos");

        var lista = collection.Distinct<string>("CiudadOrigen", FilterDefinition<Vuelos>.Empty).ToList();
        return Ok(lista);
    }

     [HttpGet("ciudad-destino")]
    public IActionResult CiudadDestino(){
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelos>("Vuelos");

        var lista = collection.Distinct<string>("CiudadDestino", FilterDefinition<Vuelos>.Empty).ToList();
        return Ok(lista);
    }
 [HttpGet("estatus")]
    public IActionResult ListarEstatus(){
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelos>("Vuelos");

        var lista = collection.Distinct<string>("EstatusVuelo", FilterDefinition<Vuelos>.Empty).ToList();
        return Ok(lista);
    }

    [HttpGet("listar-vuelos")]
    public IActionResult  ListarVuelos(string? estatus, string? origen, string? destino, string? fechainicial, string? fechafinal){
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelos>("Vuelos");

        List<FilterDefinition<Vuelos>> filters = new List<FilterDefinition<Vuelos>>();

        if(!string.IsNullOrWhiteSpace(estatus)){
            var filterEstatus = Builders<Vuelos>.Filter.Eq(x => x.EstatusVuelo, estatus);
            filters.Add(filterEstatus);
        }

        if(!string.IsNullOrWhiteSpace(origen)){
            var filterOrigen = Builders<Vuelos>.Filter.Eq(x => x.CiudadOrigen, origen);
            filters.Add(filterOrigen);
        }

        if(!string.IsNullOrWhiteSpace(destino)){
            var filterDestino = Builders<Vuelos>.Filter.Eq(x => x.CiudadDestino, destino);
            filters.Add(filterDestino);
        }

        if(!string.IsNullOrWhiteSpace(fechainicial)){
            if(DateTime.TryParse(fechainicial, out DateTime fecha)){
            var filtrofechaIni = Builders<Vuelos>.Filter.Gte(x => x.FechaHoraSalida, fecha);
            filters.Add(filtrofechaIni);
        }

        }
        if(!string.IsNullOrWhiteSpace(fechafinal)){
            if(DateTime.TryParse(fechafinal,out DateTime fecha )){
           var filtroFechaFIni= Builders<Vuelos>.Filter.Lte(x => x.FechaHoraSalida, fecha);
            filters.Add(filtroFechaFIni);
         }
        }
        List<Vuelos> vuelos;
        if(filters.Count > 0) {
          var filter = Builders<Vuelos>.Filter.And(filters);
          vuelos = collection.Find(filter).ToList();
        }
        else {
            vuelos = collection.Find(FilterDefinition<Vuelos>.Empty).ToList();
        }
        return Ok(vuelos);
    }
}