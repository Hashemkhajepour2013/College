using AutoMapper;
using College.Common;
using College.Common.Exceptions;
using College.Data.Terms.Contracts;
using College.Data.Terms.Contracts.Dtos;

namespace College.Services.Terms
{
    public class TermAppService : ITermService, IScopedDependency
    {
        private readonly ITermRepository _termRepository;
        private readonly IMapper _mapper;

        public TermAppService(
            ITermRepository termRepository,
            IMapper mapper)
        {
            _termRepository = termRepository;
            _mapper = mapper;
        }

        public async Task Add(AddTermDto dto, CancellationToken cancellationToken)
        {
            await _termRepository.AddAsync(dto.ToEntity(_mapper), cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var term = await StopIfTermNotFound(id, cancellationToken);

            await _termRepository.DeleteAsync(term, cancellationToken);
        }

        public async Task Edit(int id, EditTermDto dto, CancellationToken cancellationToken)
        {
            Entities.Term term = await StopIfTermNotFound(id, cancellationToken);

            await _termRepository.UpdateAsync(dto.ToEntity(_mapper, term), cancellationToken);

        }

        public async Task<GetTermByIdDto> GetById(int id, CancellationToken cancellationToken)
        {
            var term = await StopIfTermNotFound(id, cancellationToken);

            return GetTermByIdDto.FromEntity(_mapper, term);
        }

        private async Task<Entities.Term> StopIfTermNotFound(int id, CancellationToken cancellationToken)
        {
            var term = await _termRepository.GetByIdAsync(cancellationToken, id);
            if (term == null)
                throw new NotFoundException("ترم یافت نشد.");
            return term;
        }
    }
}
