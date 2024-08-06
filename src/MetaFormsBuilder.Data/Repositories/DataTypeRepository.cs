using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Data.Repositories;

public class DataTypeRepository (MetaFormsBuilderDbContext ctx) : GenericRepository<DataType>(ctx), IDataTypeRepository;