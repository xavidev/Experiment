public interface IDeserializer<T> where T : new()
{
    T Deserialize();
}