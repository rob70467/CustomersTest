namespace RepositoryLayer
{
    using Mapping;
    using Mapping.Imp;

    public class BaseRepository
    {
        internal IMapper Mapper = new Mapper();
    }
}
