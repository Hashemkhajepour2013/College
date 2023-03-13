using College.EFDataAccessLayer.Terms.Contracts;
using College.EFDataAccessLayer.Terms.Contracts.Dtos;
using College.Entities;

namespace College.Services.Terms
{
    public class TermAppService : ITermService
    {
        private readonly ITermRepository _repository;
        public TermAppService(ITermRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(AddTermDto dto, CancellationToken cancellationToken)
        {
            Term term = PrototypingOfTerm(dto);

            await _repository.AddAsync(term, cancellationToken);
            return term.Id;
        }

        private static Term PrototypingOfTerm(AddTermDto dto)
        {
            return new Term
            {
                Title = dto.Title,
                UnitCount = dto.UnitCount
            };
        }
    }
}
