﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IgiCore.Core.Extensions;
using IgiCore.Core.Models.Economy.Banking;

namespace IgiCore.Server.Models.Economy.Banking
{
	public class Bank : IBank
	{
		public Guid Id { get; set; }
	    [Index(IsUnique = true)]
	    [StringLength(50)]
        public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Deleted { get; set; }

		public virtual List<BankBranch> Branches { get; set; }
		public virtual List<BankAtm> Atms { get; set; }
		public virtual List<BankAccount> Accounts { get; set; }

		public Bank()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();
			this.Name = string.Empty;
			this.Created = DateTime.UtcNow;
		}
	}
}
