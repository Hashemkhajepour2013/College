using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.Common;
using College.Common.Exceptions;
using College.Data.Lessons.Contracts;
using College.Data.Lessons.Contracts.Dtos;
using College.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Services.Lessons
{
    public class LessonAppService : ILessonService, IScopedDependency
    {
        private readonly ILessonRepository _repository;
        private readonly IMapper _mapper;
        public LessonAppService(
            ILessonRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(AddLessonDto dto, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(dto.ToEntity(_mapper), cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
           var lesson = await StopIfLessonNotFound(id, cancellationToken);

            await _repository.DeleteAsync(lesson, cancellationToken);

        }

        public async Task Edit(int id, EditLessonDto dto, CancellationToken cancellationToken)
        {
            var lesson = await StopIfLessonNotFound(id, cancellationToken);

            await _repository.UpdateAsync(dto.ToEntity(_mapper, lesson), cancellationToken);
        }

        public async Task<List<GetAllLessonDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking.ProjectTo<GetAllLessonDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task<GetLessonById> GetById(int id, CancellationToken cancellationToken)
        {
            var lesson = await StopIfLessonNotFound(id, cancellationToken);

            return GetLessonById.FromEntity(_mapper, lesson);
        }

        private async Task<Lesson> StopIfLessonNotFound(int id, CancellationToken cancellationToken)
        {
            var lesson = await _repository.GetByIdAsync(cancellationToken, id);
            if (lesson == null)
                throw new NotFoundException("درس یافت نشد.");
            return lesson;
        }
    }
}
