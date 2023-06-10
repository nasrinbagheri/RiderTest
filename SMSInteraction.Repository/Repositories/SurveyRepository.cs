using IdGen;
using SMSInteraction.Domain;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.Repository.Repositories;

public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
{
    public SurveyRepository(SmsInteractionDbContext context,IIdGenerator<long> idGenerator) : base(context,idGenerator)
    {
    }
}