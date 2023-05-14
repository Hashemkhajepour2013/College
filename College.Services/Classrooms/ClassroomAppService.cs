using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.Common;
using College.Common.Exceptions;
using College.Data.Classrooms.Contracts;
using College.Data.Classrooms.Contracts.Dtos;
using College.Data.Lessons.Contracts;
using College.Data.Lessons.Contracts.Dtos;
using College.Data.Terms.Contracts;
using College.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace College.Services.Classrooms
{
    public class ClassroomAppService : IClassroomService, IScopedDependency
    {
        private readonly IClassroomRepository _repository;
        private readonly ILessonRepository _lessonRepository;
        private readonly ITermRepository _termRepository;
        private readonly UserManager<User> _usermanager;
        private readonly IMapper _mapper;

        public ClassroomAppService(
            IClassroomRepository repository,
            ILessonRepository lessonRepository,
            ITermRepository termRepository,
            UserManager<User> usermanager,
            IMapper mapper)
        {
            _repository = repository;
            _lessonRepository = lessonRepository;
            _termRepository = termRepository;
            _usermanager = usermanager;
            _mapper = mapper;
        }

        public async Task Add(AddClassroomDto dto, CancellationToken cancellationToken)
        {
            StopIfLessonNotFound(dto, cancellationToken);

            StopIfTermNotFound(dto, cancellationToken);

            StopIfProfessorNotFound(dto);

            await _repository.AddAsync(dto.ToEntity(_mapper), cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            Classroom classroom = await StopIfClassroomNotFound(id, cancellationToken);

            await _repository.DeleteAsync(classroom, cancellationToken);
        }

        public async Task<List<GetAllClassroomDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking
                .ProjectTo<GetAllClassroomDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task<GetClassroomById?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking
                .Where(_ => _.Id == id)
                .ProjectTo<GetClassroomById>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        private async Task<Classroom> StopIfClassroomNotFound(int id, CancellationToken cancellationToken)
        {
            var classroom = await _repository.GetByIdAsync(cancellationToken, id);
            if (classroom == null)
                throw new NotFoundException("کلاس مورد نظر یافت نشد");
            return classroom;
        }

        private void StopIfProfessorNotFound(AddClassroomDto dto)
        {
            var professor = _usermanager.FindByIdAsync(dto.ProfessorId.ToString());
            if (professor == null)
                throw new NotFoundException("استاد با این مشخصات یافت نشد");
        }

        private void StopIfTermNotFound(AddClassroomDto dto, CancellationToken cancellationToken)
        {
            var term = _termRepository.GetByIdAsync(cancellationToken, dto.TermId);
            if (term == null)
                throw new NotFoundException("ترم مورد نظر یافت نشد");
        }

        private void StopIfLessonNotFound(AddClassroomDto dto, CancellationToken cancellationToken)
        {
            var lesson = _lessonRepository.GetByIdAsync(cancellationToken, dto.LessonId);
            if (lesson == null)
                throw new NotFoundException("درس مورد نظر یافت نشد");
        }
    }
}
