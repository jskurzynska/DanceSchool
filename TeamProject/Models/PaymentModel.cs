using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace TeamProject.Models
{
    public class PaymentModel: BaseModel
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

        [JsonProperty("trainerId")]
        public int TrainerId
        {
            get { return _trainerId; }
            set { _trainerId = value; }
        }
        [JsonProperty("voucherType")]
        public VoucherType VoucherType
        {
            get { return _voucherType; }
            set { _voucherType = value; }
        }

        private int _trainerId;

        private VoucherType _voucherType;


    }
}
