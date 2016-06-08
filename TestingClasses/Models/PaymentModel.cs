using Newtonsoft.Json;

namespace TestingClasses.Models
{
    public class PaymentModel : BaseModel
    {
        private long _participantId;

        [JsonProperty("participantId")]
        public long ParticipantId
        {
            get { return _participantId; }
            set
            {
                _participantId = value;
                RaisePropertyChanged(nameof(ParticipantId));
            }
        }

        private long _voucherTemplateId;

        [JsonProperty("voucherTemplateId")]
        public long VoucherTemplateId
        {
            get { return _voucherTemplateId; }
            set
            {
                _voucherTemplateId = value;
                RaisePropertyChanged(nameof(VoucherTemplateId));
            }
        }

    }
}
