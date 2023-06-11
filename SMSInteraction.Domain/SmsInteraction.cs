using SMSInteraction.Enums;

namespace SMSInteraction.Domain
{
    public abstract class SmsInteraction
    {
        protected SmsInteraction()
        {
            Enabled = true;
            EnabledUtcDateTime = DateTime.UtcNow;
            CreationUtcDateTime = DateTime.UtcNow;
            Answers = new List<Answer>();
            UserAnswers = new List<UserAnswer>();
        }

        protected SmsInteraction(long id, string title) : this()
        {
            Title = title;
            Id = id;
        }

        public long Id { get; private set; }
        public InteractionType InteractionType { get; protected set; }
        public string Title { get; private set; }
        public DateTime CreationUtcDateTime { get; private set; }
        public bool Enabled { get; private set; }
        public DateTime? EnabledUtcDateTime { get; private set; }
        public DateTime? DisabledUtcDateTime { get; private set; }
        public long? LotteryId { get; private set; }
        public Lottery? Lottery { get; private set; }
        public IEnumerable<Answer> Answers { get; private set; }
        public IEnumerable<UserAnswer> UserAnswers { get; set; }

        public void Enable()
        {
            Enabled = true;
            EnabledUtcDateTime = DateTime.UtcNow;
        }

        public void Disable()
        {
            Enabled = false;
            DisabledUtcDateTime = DateTime.UtcNow;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetLottery(long lotteryId)
        {
            LotteryId = lotteryId;
        }
    }
}