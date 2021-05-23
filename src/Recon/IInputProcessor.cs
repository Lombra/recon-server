﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recon {
	public interface IInputProcessor {
		InputType InputType { get; }
		void Process(InputMessageConverter inputMessage);
	}
}
