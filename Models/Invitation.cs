public class Invitation : IDeserializerModel
{
    [Field("Usuario")]
    public string Username { get; set; }
    [Field("Nombre")]
    public string Name { get; set; }
    [Field("Apellidos")]
    public string Lastname { get; set; }
}