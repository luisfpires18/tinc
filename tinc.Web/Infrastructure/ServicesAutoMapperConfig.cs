using AutoMapper;

namespace tinc.Web.Infrastructure
{
    public class ServicesAutoMapperConfig
    {
        private static IMapper _mapped;

        public static IMapper Mapped
        {
            get
            {
                if (_mapped != null) return _mapped;
                CreateMaps();
                return _mapped;
            }
            set { _mapped = value; }
        }

      


        private static void CreateMaps()
        {

            var config = new MapperConfiguration(cfg =>
            {

                // CANDIDATE MAPPING
                //cfg.CreateMap<tinc.Web.Models.Candidate.NewCandidateInput, tinc.Dto.Candidate>();
                //cfg.CreateMap<tinc.Dto.Candidate, tinc.Web.Models.Candidate.NewCandidateInput>();
                //cfg.CreateMap<tinc.Web.Models.Candidate.CandidateInList, tinc.Dto.Candidate>();
                //cfg.CreateMap<tinc.Dto.Candidate, tinc.Web.Models.Candidate.CandidateInList>();

                //cfg.CreateMap<tinc.Web.Models.CandidateDocuments.CandidateDocumentsInput, tinc.Dto.CandidateDocument>();
                //cfg.CreateMap<tinc.Dto.CandidateDocument, tinc.Web.Models.CandidateDocuments.CandidateDocumentsInput>();

                //cfg.CreateMap<tinc.Dto.CandidateDocument, tinc.Domain.Entities.CandidateDocument>();
                //cfg.CreateMap<tinc.Domain.Entities.CandidateDocument, tinc.Dto.CandidateDocument>();
                //cfg.CreateMap<Domain.Entities.QuickAccessMenu, sc.Models.Services.QuickAccessMenu>();
                //cfg.CreateMap<sc.Models.Services.QuickAccessMenu, Domain.Entities.QuickAccessMenu>();
                //cfg.CreateMap<Domain.Entities.Brand, sc.Models.Services.Brand>();
                //cfg.CreateMap<sc.Models.Services.Brand, Domain.Entities.Brand>();


                // Skills Mapping;
                //cfg.CreateMap<Models.Skills.SoftSkills, tinc.Dto.SoftSkills>();
                //cfg.CreateMap<Models.Skills.TechnicalSkills, tinc.Dto.TechnicalSkills>();

                //cfg.CreateMap<tinc.Dto.SoftSkills, Models.Skills.SoftSkills>();
                //cfg.CreateMap<tinc.Dto.TechnicalSkills, Models.Skills.TechnicalSkills>();

                ////CandidateMapping
                //cfg.CreateMap<tinc.Web.Models.Candidate.NewCandidateInput, tinc.Dto.Candidate>();
                //cfg.CreateMap<tinc.Dto.Candidate, Models.Candidate.NewCandidateInput>();

                ////CandidateDocuments Mapping
                //cfg.CreateMap<tinc.Web.Models.CandidateDocuments.CandidateDocumentsInput, tinc.Dto.Candidate>();
                //cfg.CreateMap<tinc.Dto.CandidateDocument, Models.CandidateDocuments.CandidateDocumentsInput>();

                //cfg.CreateMap<Models.CandidateDocuments.CandidateDocumentsInput, tinc.Dto.CandidateDocument>();
                //cfg.CreateMap<tinc.Dto.CandidateDocument, Models.CandidateDocuments.CandidateDocumentsInput>();

                //cfg.CreateMap<tinc.Domain.Entities.CandidateDocument, tinc.Dto.CandidateDocument>();
                //cfg.CreateMap<tinc.Dto.CandidateDocument, tinc.Domain.Entities.CandidateDocument>();

                //// tinc.Web.Models - tinc.Dto; PONTUATION
                //cfg.CreateMap<tinc.Web.Models.EvaluationPontuation.SkillsPontuation, tinc.Dto.EvaluationSoftSkillsPontuation>();
                //cfg.CreateMap<tinc.Dto.EvaluationSoftSkillsPontuation, tinc.Web.Models.EvaluationPontuation.SkillsPontuation>();

                //// Skills;
                //cfg.CreateMap<tinc.Dto.SoftSkills, Domain.Entities.SoftSkills>();
                //cfg.CreateMap<Domain.Entities.SoftSkills, tinc.Dto.SoftSkills>();

                //// Recruiter;
                //cfg.CreateMap<tinc.Dto.Recruiter, Domain.Entities.Recruiter>();
                //cfg.CreateMap<Domain.Entities.Recruiter, tinc.Dto.Recruiter>();

                //cfg.CreateMap<Models.Recruiter.NewRecruiterInput, tinc.Dto.Recruiter>();
                //cfg.CreateMap<tinc.Dto.Recruiter, Models.Recruiter.NewRecruiterInput>();

                //cfg.CreateMap<tinc.Dto.Recruiter, Models.Recruiter.RecruiterInList>();
                //cfg.CreateMap<Models.Recruiter.RecruiterInList, tinc.Dto.Recruiter>();

                // Evaluation;
                //cfg.CreateMap<tinc.Dto.EvaluationSoftSkills, tinc.Web.Models.EvaluationPontuation.Evaluation>();
                //cfg.CreateMap<tinc.Web.Models.EvaluationPontuation.Evaluation, tinc.Dto.EvaluationSoftSkills>();

                //cfg.CreateMap<tinc.Dto.EvaluationTechnicalSkills, tinc.Web.Models.EvaluationPontuation.Evaluation>();
                //cfg.CreateMap<tinc.Web.Models.EvaluationPontuation.Evaluation, tinc.Dto.EvaluationTechnicalSkills>();


                //cfg.CreateMap<tinc.Web.Models.EvaluationPontuation.SkillsPontuation, tinc.Dto.EvaluationSoftSkillsPontuation>();
                //cfg.CreateMap<tinc.Dto.EvaluationSoftSkillsPontuation, tinc.Web.Models.EvaluationPontuation.SkillsPontuation>();


                //cfg.CreateMap<tinc.Web.Models.EvaluationPontuation.SkillsPontuation, tinc.Dto.EvaluationTechnicalSkillsPontuation>();
                //cfg.CreateMap<tinc.Dto.EvaluationTechnicalSkillsPontuation, tinc.Web.Models.EvaluationPontuation.SkillsPontuation>();

            });

            Mapped = config.CreateMapper();
        }
    }
}
