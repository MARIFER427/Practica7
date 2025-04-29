using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
[ApiController]
[Route("api/eq")]
public class EqController : Controller{
    [HttpGet("listar-avion")]
    public IActionResult ListarAvion(string tipoavion){

         MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,tipoavion);

        var lista = collection.Find(filtro).ToList();
        return Ok(lista);

    }
}
