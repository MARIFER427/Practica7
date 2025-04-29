using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
[ApiController]
[Route("conexion")]
public class Conexion : Controller{
    [HttpGet("mongo")]
    public IActionResult ListarAviones(){
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var Lista = collection.Find(FilterDefinition<Aeropuerto>.Empty).ToList();
        return Ok(Lista);
    }
}