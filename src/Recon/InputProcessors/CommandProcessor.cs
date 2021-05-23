﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Recon {
	class CommandMessage {
		public string Command { get; set; }
		public string Args { get; set; }
	}

	class CommandProcessor : IInputProcessor {
		public InputType InputType { get; } = InputType.Command;
		private readonly ILogger _logger;

		public CommandProcessor(ILogger<InputHub> logger) {
			_logger = logger;
		}

		public void Process(InputMessageConverter inputMessage) {
			var input = inputMessage.GetInputDescriptor<CommandMessage>();

			var startInfo = new ProcessStartInfo {
				FileName = input.Command,
				Arguments = input.Args,
				UseShellExecute = true,
			};
			System.Diagnostics.Process.Start(startInfo);
			_logger.LogInformation($"Command: {input.Command} {input.Args}");
		}
	}
}
