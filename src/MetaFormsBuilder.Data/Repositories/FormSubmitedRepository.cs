using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Data.Repositories;

public class FormSubmitedRepository (MetaFormsBuilderDbContext ctx): GenericRepository<FormSubmited>(ctx), IFormSubmitedRepository;