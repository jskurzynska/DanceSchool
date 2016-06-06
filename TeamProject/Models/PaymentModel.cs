﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace TeamProject.Models
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
