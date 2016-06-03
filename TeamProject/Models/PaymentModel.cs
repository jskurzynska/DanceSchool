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
        private int _trainerId;

        [JsonProperty("trainerId")]
        public int TrainerId
        {
            get { return _trainerId; }
            set
            {
                _trainerId = value;
                RaisePropertyChanged(nameof(TrainerId));
            }
        }

        private int _participantId;

        [JsonProperty("participantId")]
        public int ParticipantId
        {
            get { return _participantId; }
            set
            {
                _participantId = value;
                RaisePropertyChanged(nameof(ParticipantId));
            }
        }

        private int _voucherTemplateId;
        [JsonProperty("voucherTemplateId")]
        public int VoucherTemplateId
        {
            get { return _voucherTemplateId; }
            set
            {
                _voucherTemplateId = value; 
                RaisePropertyChanged(nameof(VoucherTemplateId));
            }
        }

        private VoucherType _voucherType;
        [JsonProperty("voucherType")]
        public VoucherType VoucherType
        {
            get { return _voucherType; }
            set
            {
                _voucherType = value;
                RaisePropertyChanged(nameof(VoucherType));
            }
        }
    }
}
