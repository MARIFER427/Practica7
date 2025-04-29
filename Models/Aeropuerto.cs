using MongoDB.Bson.Serialization.Attributes;

public class Aeropuerto{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id {set; get;}
     [BsonElement("pais_origen")]

    public string PaisOrigen {set; get;} = string.Empty;
    [BsonElement("ciudad_origen")]

    public string CiudadOrigen {set; get;} = string.Empty;
    [BsonElement("aeropuerto_origen")]

    public string AeropuertoOrigen {set; get;} = string.Empty;
    [BsonElement("pais_destino")]

    public string PaisDestino {set; get;} = string.Empty;
    [BsonElement("ciudad_destino")]

    public string CiudadDestino {set; get;} = string.Empty;
    [BsonElement("aeropuerto_destino")]

     public string AeropuertoDestino {set; get;} = string.Empty;
     [BsonElement("cupo_avion")]

     public string TipoAvion {set; get;} = string.Empty;
     [BsonElement("tipo_avio")]

     public decimal CupoAvion {set; get;} 
     [BsonElement("pasajeros_actuales")]

     public decimal PasajerosActuales {set; get;}
     [BsonElement("fecha_hora_salida")]

    public DateTime FechaHoraSalida {set; get;}
    [BsonElement("fecha_hora_llegada_aproximada")]

    public DateTime FechaHoraLlegadaAproximada {set; get;}
    [BsonElement("nombre_piloto")]

    public string NombrePiloto {set; get;} = string.Empty;
    [BsonElement("estatus_vuelo")]
    
     public string EstatusVuelo {set; get;} = string.Empty;













    

}